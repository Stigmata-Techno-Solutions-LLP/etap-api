using System;
using System.Collections.Generic;
using System.Text;

namespace ETapManagement.ViewModel.Dto {
    public class Code {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ServiceTypeId { get; set; }
          public int Buid { get; set; }
    }

    public class CodeList {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ServiceTypeId { get; set; }
        
    }
}