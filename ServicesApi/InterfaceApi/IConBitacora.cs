using ModelsApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesApi.InterfaceApi
{
    public interface IConBitacora
    {
        public ModelApiResponse ConRegistrosBitacora();

        public ModelApiResponse ConHistorialProspecto(int id);

    }
}
