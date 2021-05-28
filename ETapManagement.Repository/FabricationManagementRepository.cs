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
    public class FabricationManagementRepository : IFabricationManagementRepository {
        private readonly ETapManagementContext _context;
        private readonly IMapper _mapper;
        private readonly ICommonRepository _commonRepo;

        public FabricationManagementRepository(ETapManagementContext context, IMapper mapper, ICommonRepository commonRepo) {
            _context = context;
            _mapper = mapper;
            _commonRepo = commonRepo;
        } 
         public List<AsBuildStructure> GetStructureLst(int projectId)
          {
               try
            {
                List<AsBuildStructure> result = new List<AsBuildStructure>();
                string strQuery = string.Format("select dr.dispatch_no as DispatchNo,drs.id as DispReqStructId, dr.status Status, dr.status_internal StatusInternal ,drs.proj_struct_id ProjectStructureId,dr.id DispatchRequirementId,dr.quantity Quantity,dr.to_projectid projectId,ps.structure_id StructureId,ps.struct_code StructureCode,s.name StructrueName,p.name ProjectName,ps.structure_attributes_val StructureAttValue, ps.components_count as RequiredComponenentCount, (select count(*) from component c2  where proj_struct_id =ps.id) as CurrentComponentsCount from dispatch_requirement dr inner join disp_req_structure drs on dr.id = drs.dispreq_id   inner join  project_structure ps on ps.id=drs.proj_struct_id inner join  structures s on ps.structure_id =s.id inner join  project p on p.id =dr.to_projectid where dr.servicetype_id = 1 and dr.status ='PARTIALLYSCANNED' and dr.status_internal ='PARTIALLYSCANNED' and  dr.to_projectid ={0} ORDER BY dr.id DESC", projectId);
                result = _context.Query<AsBuildStructure>().FromSqlRaw(strQuery).ToList();
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
           

          } 
            
    }
}