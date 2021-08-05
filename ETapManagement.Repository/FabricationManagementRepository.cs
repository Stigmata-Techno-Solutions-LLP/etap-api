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
                string strQuery = string.Format("select dr.dispatch_no as DispatchNo,st.name as StructureFamily,sc.name as VendorName,drs.id as DispReqStructId, dr.status Status, dr.status_internal StatusInternal ,drs.proj_struct_id ProjectStructureId,dr.id DispatchRequirementId,dr.quantity Quantity,dr.to_projectid projectId,ps.structure_id StructureId,ps.struct_code StructureCode,s.name StructrueName,p.name ProjectName,ps.structure_attributes_val StructureAttValue, ps.components_count as RequiredComponenentCount,(select sum(weight) from component c2  where proj_struct_id =ps.id) ComponentWeight , (select count(*) from component c2  where proj_struct_id =ps.id) as CurrentComponentsCount from dispatch_requirement dr inner join disp_req_structure drs on dr.id = drs.dispreq_id  inner join  project_structure ps on ps.id=drs.proj_struct_id inner join  structures s on ps.structure_id =s.id inner join structure_type st on st.id=s.structure_type_id inner join  project p on p.id =dr.to_projectid inner join dispatchreq_subcont ds on ds.dispreq_id =dr.id inner join sub_contractor sc on sc.id =ds.subcon_id  where (dr.servicetype_id = 1 or dr.servicetype_id = 2 or (dr.servicetype_id = 1 and drs.is_modification=1))and ps.structure_status ='{1}' and ps.current_status ='{2}' and  dr.to_projectid ={0} ORDER BY dr.id DESC", projectId, Util.GetDescription(commonEnum.StructureStatus.NOTAVAILABLE).ToString(), Util.GetDescription(commonEnum.StructureInternalStatus.INUSE).ToString());
                result = _context.Query<AsBuildStructure>().FromSqlRaw(strQuery).ToList();
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
           

          }
           public List<AsBuildStructureCost> GetAsBuildStructureCost(int projectId)
          {
               try
            {
                List<AsBuildStructureCost> result = new List<AsBuildStructureCost>();
                string strQuery = string.Format("select dr.dispatch_no as DispatchNo,drs.id as DispReqStructId, dr.status Status, dr.status_internal StatusInternal ,drs.proj_struct_id ProjectStructureId,dr.id DispatchRequirementId,dr.quantity Quantity,dr.to_projectid projectId,ps.structure_id StructureId,ps.struct_code StructureCode,s.name StructrueName,p.name ProjectName,ps.structure_attributes_val StructureAttValue, ps.components_count as RequiredComponenentCount, (select count(*) from component c2  where proj_struct_id =ps.id) as CurrentComponentsCount from dispatch_requirement dr inner join disp_req_structure drs on dr.id = drs.dispreq_id   inner join  project_structure ps on ps.id=drs.proj_struct_id inner join  structures s on ps.structure_id =s.id inner join  project p on p.id =dr.to_projectid where dr.servicetype_id = 1 or dr.servicetype_id = 2 or (dr.servicetype_id = 1 and drs.is_modification=1) and dr.status ='{1}' and  dr.to_projectid ={0} ORDER BY dr.id DESC", projectId,Util.GetDescription(commonEnum.SiteDispStructureStatus.FABRICATIONCOMPLETED).ToString());
                result = _context.Query<AsBuildStructureCost>().FromSqlRaw(strQuery).ToList();
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
           

          } 

           public List<CostComponentDetailsDto> GetStructrueFabraiationComponent (int id ) {
            
                try {
                List<CostComponentDetailsDto> result = new List<CostComponentDetailsDto> ();
                string strQuery = string.Format ("select dsc.id DispstructCompId,dsc.fabriacation_cost Cost, dsc.disp_structure_id DispStructureId,dmsc.id ModStageCompId,dmsc.leng ModStageLength,dmsc.weight ModStageWeight,dmsc.height ModStageHeight,dmsc.thickness ModStageThikness,dmsc.breath ModStagebreath,c.comp_name ComponentName,c.comp_id CompId,ct.name ComponentType,c.comp_id ComponentNo,c.is_group IsGroup,c.drawing_no DrawingNo,c.leng Leng,c.breath Breath,c.height Height,c.thickness Thickness,c.weight Weight,c.make_type MakeType,c.is_tag IsTag from disp_structure_comp dsc inner join  component c  on  dsc.disp_comp_id  = c.id left outer join disp_mod_stage_component dmsc on dmsc.dispstruct_comp_id =dsc.id inner join component_type ct on c.comp_type_id =ct.id where dsc.disp_structure_id ={0}",id);
                result = _context.Query<CostComponentDetailsDto> ().FromSqlRaw (strQuery).ToList ();
                return result;
            } catch (Exception ex) {
                throw ex;
            }
        }
		  
            
    }
}