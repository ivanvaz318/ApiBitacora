using ModelsApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesApi.InterfaceApi
{
    public interface IAuthServices
    {
        public string auth(ModelUserLogin user);
        public ModelApiResponse authlogin(ModelUserLogin usuario);
        public string login(ModelUserLogin usuario);
    }
}
