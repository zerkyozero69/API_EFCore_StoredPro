using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_EFCore_StoredPro.Model
{
    public class Employee
    {
        public int ID { get; set; } = 0;
        public string EMP_Name { get; set; } = "";
        public string EMP_Email { get; set; } = "";
        public string Type { get; set; } = "";
    }
}
