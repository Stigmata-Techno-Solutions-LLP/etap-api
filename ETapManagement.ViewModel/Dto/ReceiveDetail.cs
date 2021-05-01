using System;

namespace ETapManagement.ViewModel.Dto
{
    public class ReceiveDetail
    {
        public int ProjectStructId {get;set;}
        public int DispatchRequirementId { get; set; }
        public string DispatchNumber { get; set; }
        public string ProjectName { get; set; }
        public int ProjectId { get; set; }
        public string StructureName { get; set; }
        public string ProjectStructureCode { get; set; }
        public string StructureAttributesValue { get; set; }
        public int? ComponentsCount { get; set; }
        public int DispatchStructureId { get; set; }
        public int CountEarned { get; set; }

    }

    public class ReceiveComponentDetail
    {
        public int DispatchStructureComponentId { get; set; }
        public int DispatchComponentId { get; set; }
        public string ComponentName { get; set; }
        public string ComponentId { get; set; }
        public int DispatchStructureId { get; set; }
        public DateTime? LastScanDate { get; set; }
        public string ComponentStatus { get; set; }
        public string Remarks { get; set; }
        public int ScannedBy { get; set; }

    }

    public class ReceiveComponentPayload
    {
        public int DispatchStructureComponentId { get; set; }
        public int DispatchComponentId { get; set; }
        public int ScannedBy { get; set; }
        public DateTime ScanDate { get; set; }
        public string Remarks { get; set; }
        public string QRCode { get; set; }

    }

}