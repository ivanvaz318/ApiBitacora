using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsApi.Models
{
    public class ModelHistoricoProspecto
    {
        public Int64 Id { get; set; }
        public Int64 IdProspect { get; set; }
        public string ModuloOrigen { get; set; }
        public string Movimiento { get; set; }
        public string Comentario { get; set; }
        public string ResultadoTransaccion { get; set; }
        public Int64 InsertUserId { get; set; }
        public DateTime InsertDate { get; set; }
    }
}


