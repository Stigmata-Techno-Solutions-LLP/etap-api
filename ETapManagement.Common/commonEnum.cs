using System.ComponentModel;

namespace ETapManagement.Common {
    public class commonEnum {
        public enum RolesLevel {
            Level1 = 1,
            Level2 = 2,
            Level3 = 3,
            Level4 = 4
        }
        public enum WorkFlowMode {
            Approval = 1,
            Rejection = 2,
        }
        public enum Rolename {
            ADMIN = 1,
            SITE = 2,
            CMPC = 3,
            TWCC = 4,
            PROCUREMENT = 5,
            PM = 6,
            FAA = 7,
            VENDOR = 8,
            BU = 9,
            IC = 10,
            PROJECTS = 11,
            QA = 12
        }
        public enum SurplusRolename {
            ADMIN = 1,
            SITE = 2,
            CMPC = 3,
            TWCC = 4,
            PROCUREMENT = 5,
            PM = 6,
            BU = 9,
            IC = 10,
            PROJECTS = 11,
            QA = 12,
            FAA=13
        }
        public enum SurPlusDeclSatus {
            [Description ("NEW")]
            NEW = 1, [Description ("PM APPROVED")]
            PMAPPROVED = 2, [Description ("QAA PPROVED")]
            QAAPPROVED = 3, [Description ("READY TO DISPATCH")]
            READYTODISPATCH = 4, [Description ("PM REJECTED")]
            PMREJECTED = 5, [Description ("QA REJECTED")]
            QAREJECTED = 6, [Description ("DISPATCHED")]
            DISPATCHED = 7,
        }
        public enum SiteDispatchSatus {

            [Description ("NEW")]
            NEW = 1, [Description ("PARIALLY DELIVERED")]
            PARTIALDELIVERED = 2, [Description ("DELIVERED")]
            DELIVERED = 3, [Description ("PARTIALLY SCANNED")]
            PARTIALLYSCANNED = 4, [Description ("CMPC APPROVED")]
            CMPCAPPROVED = 5, [Description ("FAA APPROVED")]
            FAAAPPROVED = 6, [Description ("FROM SITE APPROVED")]
            FROMSITEAPPROVED = 7, [Description ("TO SITE APPROVED")]
            TOSITEAPPROVED = 8, [Description ("REJECTED")]
            REJECT = 9, [Description ("PROCUREMENT APPROVED")]
            PROCAPPROVED = 10, [Description ("PARTIALLY DISPATCHED")]
            PARTIALLYDISPATCHED = 11, [Description ("DISPATCHED")]
            DISPATCHED = 12, [Description ("READY TO DELIVER")]
            READYTODELIVER = 13,

            [Description ("CMPC PARTIALLY APPROVED")]
            CMPCPARTIALLYAPPROVED = 14, [Description ("CMPC MODIFIED")]
            CMPCMODIFIED = 15, [Description ("CMPC PARTIALLY MODIFIED")]
            CMPCPARTIALLYMODIFIED = 16, [Description ("TWCC PARTIALLY MODIFIED APPROVED")]
            TWCCPARIALLYMODIFYAPRD = 17, [Description ("TWCC MODIFIED APPROVED")]
            TWCCMODIFYAPRD = 18, [Description ("READY TO DELIVER PARTIALLY")]

            TWCCAPPROVED = 20, [Description ("TWCC APPROVED")]
            READYTODELIVERPARTIALLY = 19,
        }

        public enum SiteDispStructureStatus {
            [Description ("NEW")]
            NEW = 1, [Description ("PARIALLY DELIVERED")]
            PARTIALDELIVERED = 2, [Description ("DELIVERED")]
            DELIVERED = 3, [Description ("PARTIALLY SCANNED")]
            PARTIALLYSCANNED = 4, [Description ("CMPC APPROVED")]
            CMPCAPPROVED = 5, [Description ("FAA APPROVED")]
            FAAAPPROVED = 6, [Description ("FROM SITE APPROVED")]
            FROMSITEAPPROVED = 7, [Description ("TO SITE APPROVED")]
            TOSITEAPPROVED = 8, [Description ("REJECTED")]
            REJECT = 9, [Description ("PROCUREMENT APPROVED")]
            PROCAPPROVED = 10, [Description ("PARTIALLY DISPATCHED")]
            PARTIALLYDISPATCHED = 11, [Description ("DISPATCHED")]
            DISPATCHED = 12, [Description ("READY TO DELIVER")]
            READYTODELIVER = 13,

            [Description ("CMPC PARTIALLY APPROVED")]
            CMPCPARTIALLYAPPROVED = 14, [Description ("CMPC MODIFIED")]
            CMPCMODIFIED = 15, [Description ("CMPC PARTIALLY MODIFIED")]
            CMPCPARTIALLYMODIFIED = 16, [Description ("TWCC PARTIALLY MODIFIED APPROVED")]
            TWCCPARIALLYMODIFYAPRD = 17, [Description ("TWCC MODIFIED APPROVED")]
            TWCCMODIFYAPRD = 18, [Description ("READY TO DELIVER PARTIALLY")]
            READYTODELIVERPARTIALLY = 19, [Description ("FABRICATION COMPLETED")]
            FABRICATIONCOMPLETED = 20,
            SCANNED = 21,
            [Description ("DISPATCH COMPLETED")]
            DISPATCHCOMPLETED = 20,

        }
        public enum ComponentStatus {
            NEW = 1,
            USABLE = 2,
            SCRAP = 3
        }
        public enum ScrapStatus {
            NEW = 1,
            PMAPPROVED = 2,
            QAAPPROVED = 3,
            TWCCAPPROVED = 4,
            SCRAPPED = 5,
            REJECTED = 6,

        }

        public enum ComponentInternalStatus {
            NEW = 1,
            INUSE = 2,
            SCANNINGFAILED = 3,
            IDLE = 4
        }

        public enum ServiceType {
            Fabrication = 1,
            OutSourcing = 2,
            Scrap = 3,
            Reuse = 4
        }
        public enum StructureInternalStatus {
            [Description ("NEW")] NEW = 1, 
            
            [Description ("DISPATCH IN PROGRESS")]
            DISPATCHINPROGRESS = 2, [Description ("IN USE")]
            INUSE = 3, [Description ("PARTIALLY SCANNED")]
            PARTIALLYSCANNED = 4, [Description ("SURPLUS INITIATED")]
            SURPLUSINITIATED = 5, [Description ("READY TO REUSE")]

            READYTOREUSE = 6, 
            [Description ("READY TO DISPATCH")]
            READYTODISPATCH = 7, 
            
            [Description ("PARTIALLY DISPATCHED")]
            PARTIALLYDISPATCHED = 8,  
            [Description ("SCRAPPED")]
            SCRAPPED = 9
        }

        public enum StructureStatus {
            [Description ("NEW")]
            NEW = 1, [Description ("AVAILABLE")]
            AVAILABLE = 2, [Description ("NOT AVAILABLE")]
            NOTAVAILABLE = 3
        }
        public enum SiteRequiremntStatus {
            [Description("NEW")]
            NEW = 1,
            [Description("PARTIALLY DISPATCHED")]
            PARTIALLYDISPATCHED = 2,
            [Description("DISPATCHED")]
            DISPATCHED = 3
        }

        public enum TWCCDispatchReleaseDate {
            ONEMONTH = 1,
            THREEMONTHS = 2,
            SIXMONTHS = 3,

        }
    }

}