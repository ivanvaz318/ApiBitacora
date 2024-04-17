using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsApi
{
    public class Constants
    {
        public const string schema = "Auditoria";
        public const string schemaAuditoria = "Auditoria";
        public const string peticionSinDatos = "Consulta Vacia";
        public const string shemaUsers = "Users";
        public const string schemaProspects = "Prospects";
        public const string peticionExitosa = "Peticion Exitosa";

    }

    public class ListStoreProducers
    {
        public const string SPConConsultaHistorialProspecto = ".SPConConsultaHistorialProspecto";
        public const string SPConUsuarioExistente = ".SPConUsuarioExistente";
        public const string SPConUsuario = ".SPConUsuario";
        public const string SPConFaseProspectos = ".SPConFaseProspectos";
        public const string SPConProspects = ".SPConProspects";
        public const string SPConProspectsLista = ".SPConProspectsLista";
        public const string SPConRegistrosBitacora = ".SPConRegistrosBitacora";
        public const string Spconconsultahistorialprospectoid = ".Spconconsultahistorialprospectoid";
    }
}
