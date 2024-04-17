using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsApi.Models
{
    public class ModelFaseProspectos
    {
        public Int32 fase1ActualizarInf {  get; set; }
        public Int32 fase2CambioMult {  get; set; }
        public Int32 fase3AuthCon {  get; set; }
        public Int32 fase4Score {  get; set; }
        public Int32 totalIdProspect { get; set; }
        public decimal porcentajeFase1 { get; set; }
        public decimal porcentajeFase2 { get; set; }
        public decimal porcentajeFase3 { get; set; }
        public decimal porcentajeFase4 { get; set; }

    }
}
