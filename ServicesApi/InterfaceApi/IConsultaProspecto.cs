using ModelsApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesApi.InterfaceApi
{
    public interface IConsultaProspecto
    {
        public ModelApiResponse ConsProspecto(int idProspect);

        public ModelApiResponse ConsListProspecto();
    }
}
