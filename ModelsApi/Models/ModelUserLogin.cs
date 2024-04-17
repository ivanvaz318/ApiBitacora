using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsApi.Models
{
    public class ModelUserLogin
    {
        public string UserName { get; set; }
        public string UserPassword { get; set; }
    }

    public class ModelResLogin
    {
        public string token { get; set;}
        public Int64 IdUser { get; set;}
    }
}
