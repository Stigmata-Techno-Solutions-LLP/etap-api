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
            EHS = 6,
            FAA = 7,
            VENDOR = 8,
            BU = 9,
            IC = 10,
            PROJECTS = 11,
            QA=12
        }
           public enum SurplusRolename {
            ADMIN = 1,
            SITE = 2,
            CMPC = 3,
            TWCC = 4,
            PROCUREMENT = 5,
            EHS = 6,
            BU = 9,
            IC = 10,
            PROJECTS = 11,
            QA=12
        }
        public enum SurPlusDeclSatus {
            NEW = 1,
            EHSAPPROVED = 2,
            QAAPPROVED = 3,
            READYTODISPATCH = 4,
            EHSREJECTED = 5,
            QAREJECTED = 6,
            DISPATCHED = 7,
        }
        public enum SiteDispatchSatus {
            NEW = 1,
            PARTIALDELIVERED=2,
           DELIVERED=3,
           PARTIALLYSCANNED=4,
            CMPCAPPROVED=5,
           FAAAPPROVED=6,
           FROMSITEAPPROVED=7,
           TOSITEAPPROVED=8,
           REJECT=9,
           PROCAPPROVED=10,
           PARTIALLYDISPATCHED=11,
           DISPATCHED =12,
           READYTODELIVER=13,
           CMPCPARTIALLYAPPROVED=14,
           CMPCMODIFIED=15,
           CMPCPARTIALLYMODIFIED=16,
           TWCCPARIALLYMODIFYAPRD=17,
           TWCCMODIFYAPRD=18,

           
        

          
        }

          public enum SiteDispStructureStatus {
            NEW = 1,
            PARTIALDELIVERED=2,
            DELIVERED=3,
            PARTIALLYSCANNED=4,
            CMPCAPPROVED=5,
            CMPCPARTIALLYAPRD =15,
            FAAAPPROVED=6,
           FROMSITEAPPROVED=7,
           TOSITEAPPROVED=8,
           REJECT=9,
           PROCAPPROVED=10,
           PARTIALLYDISPATCHED=11,
           READYTODELIVER=13,
           DISPATCHED =12
        }
        public enum ComponentStatus {
            NEW =1,
           USABLE =2,
            SCRAP =3
        }
        public enum ScrapStatus {
            NEW =1,
            EHSAPPROVED =2,
            QAAPPROVED =3,
            TWCCAPPROVED=4,
            SCRAPPED=5,
            REJECTED=6,
            
        }        

           public enum ComponentInternalStatus {
            NEW = 1,
            INUSE = 2,
            SCANNINGFAILED = 3,
            IDLE=4
        }

        public enum ServiceType {
            Fabrication=1,
            OutSourcing=2,
            Scrap=3,
            Reuse=4 
        }
        public enum StructureInternalStatus {
            NEW=1,
            DISPATCHINPROGRESS=2,
            INUSE=3,
            PARTIALLYSCANNED=4,
            SURPLUSINITIATED=5,
            READYTOREUSE=6,
            SCRAPPED=7
        }

        public enum StructureStatus {
            NEW=1,
            AVAILABLE=2,
            NOTAVAILABLE=3,       
        }
        public enum SiteRequiremntStatus{
            NEW=1,
            PARTIALLYDISPATCHED=2,
            DISPATCHED=2
        }

        public enum TWCCDispatchReleaseDate{
            ONEMONTH=1,
            THREEMONTHS=2,
            SIXMONTHS=3
        }
    }

}