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
            PROJECTS = 11
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
           
        }
        public enum ComponentStatus {
            M = 1,
            O = 2,
        }
        public enum ServiceType {
            Fabrication=1,
            OutSourcing=2,
            Scrap=3,
            Reuse=4 
        }
    }

}