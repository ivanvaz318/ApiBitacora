using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsApi.Models
{
    public class ModelConBitacora
    {
        public Int64 IdProspect { get; set; }
        public string ModuloOrigen { get; set; }
        public string Movimiento { get; set; }
        public Int64 InsertUserId { get; set; }
        public DateTime InsertDate { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string SecondLastName { get; set; }
        public string Rfc {  get; set; }
        public Int64 TaxRegimeTypeId {  get; set; }
    }

    public class ModelConBitacoraHistorial
    {
        public Int64 Dias {  get; set; }
        public Int64 IdProspect { get; set; }
        public string ModuloOrigen { get; set; }
        public string Movimiento { get; set; }
        public string Comentario { get; set; }
        public string ResultadoTransaccion { get; set; }
        public Int64 InsertUserId { get; set; }
        public DateTime InsertDate { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string SecondLastName { get; set; }
        public string Rfc { get; set; }
        public Int64 TaxRegimeTypeId { get; set; }
    }
}
