using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using ETapManagement.Common;
using ETapManagement.Domain.Models;
using ETapManagement.ViewModel.Dto;

namespace ETapManagement.Repository {

    public class ComponentRepository : IComponentRepository {
        private readonly ETapManagementContext _context;
        private readonly IMapper _mapper;
        private readonly ICommonRepository _commonRepo;

        public ComponentRepository (ETapManagementContext context, IMapper mapper, ICommonRepository commonRepo) {
            _context = context;
            _mapper = mapper;
            _commonRepo = commonRepo;
        }

        public List<ComponentDetails> GetComponent () {
            List<ComponentDetails> response = new List<ComponentDetails> ();
            var responsedb = _context.Component.Where (x => x.IsDelete == false).OrderByDescending(x=>x.CreatedAt).ToList ();
            response = _mapper.Map<List<ComponentDetails>> (responsedb);
            return response;
        }

        public ComponentDetails GetComponentById (int id) {
            ComponentDetails response = new ComponentDetails ();
            var responsedb = _context.Component.Where (x => x.Id == id && x.IsDelete == false).FirstOrDefault ();

            if (responsedb != null)
                response = _mapper.Map<ComponentDetails> (responsedb);

            return response;
        }

        public List<ComponentDetails> GetComponentHistoryByCode (string compCode) {
            try {
                List<ComponentDetails> response = new List<ComponentDetails> ();
                List<ComponentHistory> responsedb = _context.ComponentHistory.Where (x => x.CompId == compCode && x.IsDelete == false).ToList ();

                if (responsedb != null)
                    response = _mapper.Map<List<ComponentDetails>> (responsedb);
                return response;
            } catch (Exception ex) {
                throw ex;
            }
        }

        public ResponseMessage AddComponents (AddComponents request) {
            ResponseMessage response = new ResponseMessage ();
            response.Message = "Components added succusfully";
            List<dispatchedStrucCount> result = new List<dispatchedStrucCount>();
                 int count = _context.Component.Where(s =>s.ProjStructId==request.ProjStructId).Count();
              int Quantity=request.Components.Where(x=>x.CompId==null).Count();
                int excedCout= count+Quantity;
                int totalcount =_context.ProjectStructure.Single(s =>s.Id==request.ProjStructId).ComponentsCount??0;
                  if (totalcount<excedCout) throw new ValueNotFoundException ("Dispatch Components should match the required quantity.");

            try {
                //	using (var transaction = _context.Database.BeginTransaction ())                 
                    try {
                        var isUpdate = false;
                        var projectStructureID = 0;
                        ProjectStructure projectStructure = _context.ProjectStructure.Where (x => x.Id == request.ProjStructId && x.IsDelete == false).FirstOrDefault ();
                       int compCount = _context.Component.Where(x=>x.ProjStructId==request.ProjStructId).Count();
                       int payLoadeCompCount= request.Components.Where(x=>x.CompId==null).Count();
                       int excedcout=payLoadeCompCount + compCount;
                        if (projectStructure.ComponentsCount < excedcout) throw new ValueNotFoundException ("Component limit exceed");
                        if (projectStructure == null) throw new ValueNotFoundException ("Project Structure not yet assigned");
                        projectStructureID = projectStructure.Id;
                        if (request.Components?.Count > 0) {

                            List<Component> componentls = new List<Component> ();
                            List<ComponentHistory> componentHistls = new List<ComponentHistory> ();
                            foreach (var comp in request.Components) {
                                ComponentType compTypeDB = _context.ComponentType.Where (x => x.Name == comp.CompTypeName && x.IsDelete == false).FirstOrDefault ();
                                if (compTypeDB == null) throw new ValueNotFoundException ("Component Type Name doesn't exist");
                            }
                            foreach (var comp in request.Components) {
                                var compdb = _context.Component.Where (x => x.CompId == comp.CompId && x.IsDelete == false).FirstOrDefault ();
                                ComponentType compTypeDB = _context.ComponentType.Where (x => x.Name == comp.CompTypeName && x.IsDelete == false).FirstOrDefault ();

                                if (compTypeDB == null) throw new ValueNotFoundException ("Component Type Name doesn't exist");
                                if (compdb != null) {
                                    compdb = ConstructComponent (projectStructureID, comp, compdb, compTypeDB);
                                    _context.SaveChanges ();
                                } else {
                                    Component component = null;
                                    comp.CompStatus = "O";
                                    component = ConstructComponent (projectStructureID, comp, component, compTypeDB);
                                    _context.Component.Add (component);
                                    _context.SaveChanges ();
                                }
                            }
                           // projectStructure.ComponentsCount = request.Components.Count ();
                            _context.SaveChanges ();
                        }
                        return response;
                    } catch (Exception ex) {
                        //	transaction.Rollback ();
                        throw ex;
                    }
                
            } catch (Exception ex) {
                throw ex;
            }
        }


        public ResponseMessage AddComponentsDisaptch (DispatchAddComponents request) {
            ResponseMessage response = new ResponseMessage ();
            response.Message = "Components added succusfully";
            // if (request?.ProjectStructureDetail == null)
            // 	throw new ValueNotFoundException ("ProjectStructureDetail Request cannot be empty.");
             ProjectStructure projectStructure = _context.ProjectStructure.Where (x => x.Id == _context.DispReqStructure.Where(x=>x.Id == request.DispStructureId).FirstOrDefault().ProjStructId && x.IsDelete == false).FirstOrDefault ();
              List<dispatchedStrucCount> result = new List<dispatchedStrucCount>();
                 int count = _context.Component.Where(s =>s.ProjStructId==projectStructure.Id).Count();
             int Quantity=request.Components.Where(x=>x.CompId==null).Count();
                int excedCout= count+Quantity;
               // int totalcount =_context.ProjectStructure.Single(s =>s.Id==projectStructure.Id).ComponentsCount??0;
                  if (projectStructure.ComponentsCount<excedCout) throw new ValueNotFoundException ("Dispatch Components should match the required quantity.");

            try {
                //	using (var transaction = _context.Database.BeginTransaction ()) 
                {
                    try {
                        var isUpdate = false;
                        var projectStructureID = 0;
                         projectStructure = _context.ProjectStructure.Where (x => x.Id == _context.DispReqStructure.Where(x=>x.Id == request.DispStructureId).FirstOrDefault().ProjStructId && x.IsDelete == false).FirstOrDefault ();
                        if (projectStructure == null) throw new ValueNotFoundException ("Project Structure not yet assigned");
                        projectStructureID = projectStructure.Id;
                        if (request.Components?.Count > 0) {

                            List<Component> componentls = new List<Component> ();
                            List<ComponentHistory> componentHistls = new List<ComponentHistory> ();
                            foreach (var comp in request.Components) {
                            
                                ComponentType compTypeDB = _context.ComponentType.Where (x => x.Name == comp.CompTypeName && x.IsDelete == false).FirstOrDefault ();
                                if (compTypeDB == null) throw new ValueNotFoundException ("Component Type Name doesn't exist");
                            }
                            foreach (var comp in request.Components) {
                                var compdb = _context.Component.Where (x => x.CompId == comp.CompId && x.IsDelete == false).FirstOrDefault ();
                                ComponentType compTypeDB = _context.ComponentType.Where (x => x.Name == comp.CompTypeName && x.IsDelete == false).FirstOrDefault();

                                if (compTypeDB == null) throw new ValueNotFoundException ("Component Type Name doesn't exist");
                                if (compdb != null) {
                                  var dispCompDB = _context.DispStructureComp.Where(x=>x.DispCompId == compdb.Id && x.DispStructureId == request.DispStructureId).FirstOrDefault();
                                 if ( dispCompDB != null) {

                                 
                                  
                                    compdb = ConstructComponent (projectStructureID, comp, compdb, compTypeDB);
                                //     DispStructureComp dsc = new DispStructureComp();
                                //     dsc.DispCompId  =  compdb.Id;
                                //     dsc.DispStructureId = request.DispStructureId;

                                //    // _context.Add(compdb);
                                //     _context.Add(dsc);
                                    _context.SaveChanges ();
                                 } else {
                                     throw new ValueNotFoundException ("Dispatch Component ID doesnt exists");

                                 }
                                } else {
                                    Component component = null;
                                    comp.CompStatus = "O";
                                    component = ConstructComponent (projectStructureID, comp, component, compTypeDB);
                                    _context.Component.Add (component);
                                    _context.SaveChanges ();
                                     DispStructureComp dsc = new DispStructureComp();
                                    dsc.DispCompId  = component.Id;
                                    dsc.DispStructureId = request.DispStructureId;
                                    _context.DispStructureComp.Add(dsc);
                                    _context.SaveChanges ();
                                }
                                

                            }
                          //  projectStructure.ComponentsCount = request.Components.Count ();
                           // _context.SaveChanges ();
                        }

                        return response;
                    } catch (Exception ex) {
                        //	transaction.Rollback ();
                        throw ex;
                    }
                }
            } catch (Exception ex) {
                throw ex;
            }
        }

        private Component ConstructComponent (int projectStructureID, ComponentDetails comp, Component compdb, ComponentType compTypeDB) {
            if (compdb == null) {
                compdb = new Component ();
                int count = _context.Component.Count () + 1;
                string id = constantVal.ComponentIdPrefix + count.ToString ().PadLeft (6, '0');
                compdb.CompId = id;
                compdb.CreatedAt = DateTime.Now;
            }
            compdb.ProjStructId = projectStructureID;
            compdb.CompName = comp.ComponentName;
            compdb.IsActive = comp.IsActive;
            compdb.IsDelete = false;
            compdb.DrawingNo = comp.DrawingNo;
            compdb.CompTypeId = compTypeDB.Id;
            compdb.ComponentNo = comp.ComponentNo;
            compdb.IsGroup = comp.IsGroup;
            compdb.Leng = comp.Leng;
            compdb.Breath = comp.Breath;
            compdb.Height = comp.Height;
            compdb.Thickness = comp.Thickness;
            compdb.Weight = comp.Weight;
            compdb.MakeType = comp.MakeType;
            compdb.IsTag = comp.IsTag;
            compdb.QrCode = comp.QrCode;
            compdb.CompStatus = comp.CompStatus;
            compdb.UpdatedAt = DateTime.Now;
            return compdb;
        }

        public ResponseMessage UpdateComponent (ComponentDetails servicedto, int id) {
            ResponseMessage responseMessage = new ResponseMessage ();
            try {
                var component = _context.Component.Where (x => x.Id == id && x.IsDelete == false).FirstOrDefault ();
                if (component != null) {
                    if (_context.Component.Where (x => x.Id == servicedto.Id && x.IsDelete == false).Count () > 0) {
                        throw new ValueNotFoundException ("Component already exist.");
                    } else {
                        //TODO: need to identify attributes
                        _context.SaveChanges ();

                        return responseMessage = new ResponseMessage () {
                            Message = "Component updated successfully.",
                        };
                    }
                } else {
                    throw new ValueNotFoundException ("Component not available.");
                }
            } catch (Exception ex) {
                throw ex;
            }
        }

        public ResponseMessage DeleteComponent (int id) {
            ResponseMessage responseMessage = new ResponseMessage ();
            try {
                var component = _context.Component.Where (x => x.Id == id).FirstOrDefault ();
                if (component == null) throw new ValueNotFoundException ("Component Id doesnt exist.");
                component.IsDelete = true;
                _context.SaveChanges ();
                return responseMessage = new ResponseMessage () {
                    Message = "Component deleted successfully."
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