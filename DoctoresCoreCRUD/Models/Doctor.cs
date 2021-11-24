using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoctoresCoreCRUD.Models
{
    public class Doctor
    {
        public String Apellido { get; set; }
        public String Especialidad { get; set; }
        public int Salario { get; set; }
        public int DoctorNo { get; set; }
    }
}
