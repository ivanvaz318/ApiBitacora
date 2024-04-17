using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsApi.Models
{
    public class ModelProspecto
    {
        public Int64 Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string SecondLastName { get; set; }
        public Int16 GenderId { get; set; }
        public Int16 NationalityId { get; set; }
        public Int16 StateId { get; set; }
        public Int16 TaxRegimeTypeId { get; set; }
        public string Rfc { get; set; }
        public Int16 PersonalId { get; set; }
        public string Phone { get; set; }
        public bool IsActive { get; set; }
        public bool Visible { get; set; }
        public Int32 InsertUserId { get; set; }
        public Int16 SystemStatusId { get; set; }
        public Int16 SystemPhasesId { get; set; }
        public bool IsAval { get; set; }
        public Int64 ProspectCetelemId { get; set; }
        public string SecondName { get; set; }
        public Int16 CountrysId { get; set; }
    }

    public class ModelConListProspectos
    {
        public Int64 IdProspectCetelem { get; set; }
        public Int64 IdProspect { get; set; }
        public Int64 IdTaxRegimeType { get; set; }  
        public string NameTaxRegimeType { get; set; }
        public Int64 IdBrand {  get; set; } 
        public string NameBrand {  get; set; }
        public string Prospecto {  get; set; }
        public string Rfc { get; set; }


    }
}
