using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using ETapManagement.Common;
using ETapManagement.Domain.Models;
using ETapManagement.ViewModel.Dto;
using Microsoft.EntityFrameworkCore;
using MimeKit;

namespace ETapManagement.Repository {

    public class ComponentTypeRepository : IComponentTypeRepository {
        private readonly ETapManagementContext _context;
        private readonly IMapper _mapper;
        private readonly ICommonRepository _commonRepo;

        public ComponentTypeRepository (ETapManagementContext context, IMapper mapper, ICommonRepository commonRepo) {
            _context = context;
            _mapper = mapper;
            _commonRepo = commonRepo;
        }

        public List<ComponentTypeDetails> getComponentType () {
            List<ComponentTypeDetails> response = new List<ComponentTypeDetails> ();
            var responsedb = _context.ComponentType.Where (x => x.IsDelete == false).ToList ();
            response = _mapper.Map<List<ComponentTypeDetails>> (responsedb);
            return response;
        }

        public ComponentTypeDetails getComponentTypeById (int id) {
            ComponentTypeDetails response = new ComponentTypeDetails ();
            var responsedb = _context.ComponentType.Where (x => x.Id == id && x.IsDelete == false).FirstOrDefault ();

            if (responsedb != null)
                response = _mapper.Map<ComponentTypeDetails> (responsedb);

            return response;
        }

        public ResponseMessage AddComponentType (ComponentTypeDetails componentTypeDetails) {
            ResponseMessage response = new ResponseMessage ();
            try {
                //TODO: ID auto incremented??
                if (_context.ComponentType.Where (x => x.Id == componentTypeDetails.Id && x.IsDelete == false).Count () > 0) {
                    throw new ValueNotFoundException ("ComponentType Id already exist.");
                } else if (_context.ComponentType.Where (x => x.Name == componentTypeDetails.Name && x.IsDelete == false).Count () > 0) {
                    throw new ValueNotFoundException ("ComponentType Name already exist.");
                } else {
                    var componentType = _mapper.Map<ComponentType> (componentTypeDetails);
                    _context.ComponentType.Add (componentType);
                    _context.SaveChanges ();

                    //TODO: is audit required for componentType?
                    /* AuditLogs audit = new AuditLogs () {
                         Action = "ComponentType",
                         Message = string.Format ("New ComponentType added successfully {0}", componentTypeDetails.Name),
                         CreatedAt = DateTime.Now
                     };                    
                     _commonRepo.AuditLog(audit);
                     */

                    return response = new ResponseMessage () {
                        Message = "ComponentType added successfully."
                    };
                }
            } catch (Exception ex) {
                throw ex;
            }
        }

        public ResponseMessage UpdateComponentType (ComponentTypeDetails componentTypeDetails, int id) {
            ResponseMessage responseMessage = new ResponseMessage ();
            try {
                var componentType = _context.ComponentType.Where (x => x.Id == id && x.IsDelete == false).FirstOrDefault ();
                if (componentType != null) {
                    if (_context.ComponentType.Where (x => x.Name == componentTypeDetails.Name && x.IsDelete == false).Count () > 0) {
                        throw new ValueNotFoundException ("ComponentType Name already exist.");
                    } else {
                        componentType.Name = componentTypeDetails.Name;
                        componentType.Description = componentTypeDetails.Description;
                        componentType.IsActive = componentTypeDetails.isActive;
                        _context.SaveChanges ();

                        /*AuditLogs audit = new AuditLogs () {
                            Action = "ComponentType",
                            Message = string.Format ("Update componentType  successfully {0}", componentTypeDetails.Name),
                            CreatedAt = DateTime.Now
                        };
                        _commonRepo.AuditLog (audit);*/

                        return responseMessage = new ResponseMessage () {
                            Message = "ComponentType updated successfully.",
                        };
                    }
                } else {
                    throw new ValueNotFoundException ("ComponentType not available.");
                }
            } catch (Exception ex) {
                throw ex;
            }
        }

        public ResponseMessage DeleteComponentType (int id) {
            ResponseMessage responseMessage = new ResponseMessage ();
            try {

                var componentType = _context.ComponentType.Where (x => x.Id == id).FirstOrDefault ();
                if (componentType == null) throw new ValueNotFoundException ("ComponentType Id doesnt exist.");

                //_context.ComponentType.Remove(componentType);
                componentType.IsDelete = true;
                _context.SaveChanges ();

                /*
                AuditLogs audit = new AuditLogs () {
                    Action = "ComponentType",
                    Message = string.Format ("Update ComponentType  Succussfully {0}", componentTypeDetails.Name),
                    CreatedAt = DateTime.Now,
                };
                _commonRepo.AuditLog (audit);
                */

                return responseMessage = new ResponseMessage () {
                    Message = "ComponentType deleted successfully."
                };
            } catch (Exception ex) {
                throw ex;
            }
        }

        public void Dispose () {
            Dispose (true);
            GC.SuppressFinalize (this);
        }

        protected virtual void Dispose (bool disposing) {
            if (disposing) {
                _context.Dispose ();
            }
        }
    }
}