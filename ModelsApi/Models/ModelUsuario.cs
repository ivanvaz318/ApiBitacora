using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsApi.Models
{
    public class ModelUsuario
    {
        public Int64 Id { get; set; }
        public string ValueEmployee { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public Int16 EmployeeTypeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string SecondName { get; set; }
        public Int16 ProfileId { get; set; }
        public bool IsActive { get; set; }
        public bool Visible { get; set; }

    }
}
