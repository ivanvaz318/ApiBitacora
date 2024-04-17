using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsApi.Models
{
    public class ModelApiResponse
    {
        [JsonProperty("Message")]
        public string Message { get; set; } = "Peticion Exitosa";
        [JsonProperty("StatusCode")]
        public int StatusCode { get; set; }
        [JsonProperty("Data")]
        public Object Data { get; set; }
    }
}
