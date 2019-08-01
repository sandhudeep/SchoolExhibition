using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolExhibition.Models
{
    public class StudentMaster
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int ClassMasterID { get; set; }

        public ClassMaster ClassMaster { get; set; }
    }
}
