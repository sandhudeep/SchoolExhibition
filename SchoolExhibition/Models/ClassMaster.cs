using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolExhibition.Models
{
    public class ClassMaster
    {
        public int ID { get; set; }
        public string ClassName { get; set; }
        public string Section { get; set; }
        public int NumberOfStudents { get; set; }

        public List<StudentMaster> StudentMasters { get; set; }
        public List<ExhibitionCoordinatorMaster> ExhibitionCoordinatorMasters { get; set; }
    }
}
