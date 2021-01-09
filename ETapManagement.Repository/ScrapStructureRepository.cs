using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using ETapManagement.Common;
using ETapManagement.Domain;
using ETapManagement.Domain.Models;
using ETapManagement.ViewModel.Dto;
using Microsoft.EntityFrameworkCore; 

namespace ETapManagement.Repository {
    public class ScrapStructureRepository : IScrapStructureRepository {
        private readonly ETapManagementContext _context;
        private readonly IMapper _mapper;
        private readonly ICommonRepository _commonRepo;

        public ScrapStructureRepository(ETapManagementContext context, IMapper mapper, ICommonRepository commonRepo) {
            _context = context;
            _mapper = mapper;
            _commonRepo = commonRepo;
        } 
        public ResponseMessage CreateScrapStructure(AddScrapStructure scrapStructure)
        {
            try
            { 
                ResponseMessage responseMessage = new ResponseMessage();
                ScrapStructure scrapStructureDB = _mapper.Map<ScrapStructure>(scrapStructure);

                scrapStructureDB.CreatedBy = 1; //TODO
                scrapStructureDB.CreatedAt = DateTime.Now;
                scrapStructureDB.Status = "SCRAPPED";
                _context.ScrapStructure.Add(scrapStructureDB);
                _context.SaveChanges(); 

                responseMessage.Message = "Scrap Structure created sucessfully";
                return responseMessage;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        } 

        public ResponseMessage DeleteScrapStructure(int id)
        {
            ResponseMessage responseMessage = new ResponseMessage();
            try
            {

                var scrapStructure = _context.ScrapStructure.Where(x => x.Id == id && x.IsDelete == false).FirstOrDefault();
                if (scrapStructure == null) throw new ValueNotFoundException("Scrap Structre Id doesnt exist.");
                scrapStructure.IsDelete = true;
                _context.SaveChanges();
                AuditLogs audit = new AuditLogs()
                {
                    Action = "Scrap Structure",
                    Message = string.Format("Scrap Structure Deleted  Successfully {0}", scrapStructure.Id),
                    CreatedAt = DateTime.Now,
                };
                _commonRepo.AuditLog(audit);
                return responseMessage = new ResponseMessage()
                {
                    Message = "Scrap Structure deleted successfully."
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }  
        public List<ScrapStructureDetail> GetScrapStructureDetails()
        {
            try
            {
                List<ScrapStructureDetail> result = new List<ScrapStructureDetail>();
                var scrapStructures = _context.ScrapStructure.Include(c=>c.Subcon).Include(x=>x.Struct).Where(x => x.IsDelete == false).OrderByDescending(x=>x.CreatedAt).ToList();
                result = _mapper.Map<List<ScrapStructureDetail>>(scrapStructures);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ScrapStructureDetail GetScrapStructureDetailsById(int id)
        {
            try
            {
                ScrapStructureDetail result = new ScrapStructureDetail();
                var scrapStructure = _context.ScrapStructure.Where(x => x.Id == id && x.IsDelete == false).FirstOrDefault();
                result = _mapper.Map<ScrapStructureDetail>(scrapStructure);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        } 

        public ResponseMessage UpdateScrapStructure(AddScrapStructure scrapStructure, int id)
        {
            ResponseMessage responseMessage = new ResponseMessage();
            try
            {
                var scrapStructureDB= _context.ScrapStructure.Where(x => x.Id == id && x.IsDelete == false).FirstOrDefault();
                if (scrapStructureDB != null)
                {
                        scrapStructureDB.SubconId = scrapStructure.SubconId;
                        scrapStructureDB.StructId = scrapStructure.StructId;
                        scrapStructureDB.ScrapRate = scrapStructure.ScrapRate;
                        scrapStructureDB.AuctionId = scrapStructure.AuctionId;
                        scrapStructureDB.Status = "SCRAPPED";
                        scrapStructureDB.UpdatedBy = 1; //TODO
                        scrapStructureDB.UpdatedAt = DateTime.Now;                          
                        _context.SaveChanges();

                        AuditLogs audit = new AuditLogs()
                        {
                            Action = "Scrap Structure",
                            Message = string.Format("Scrap Structure Updated Successfully {0}", id),
                            CreatedAt = DateTime.Now,
                            CreatedBy = 1 //TODO
                        };
                        _commonRepo.AuditLog(audit);
                        return responseMessage = new ResponseMessage()
                        {
                            Message = "Scrap Structure updated successfully.",

                        }; 
                }
                else
                {
                    throw new ValueNotFoundException("Scrap Structure not available.");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}