using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace ServicioREST
{
    [DataContract]
    public class ClienteEntidad
    {
        [DataMember]
        public int Cod_Cliente { get; set; }
        [DataMember]
        public string Nom_Cliente { get; set; }
        [DataMember]
        public string Ape_Cliente { get; set; }
        [DataMember]
        public string Dir_Cliente { get; set; }
        [DataMember]
        public string Tel_Cliente { get; set; }
        [DataMember]
        public string Sexo { get; set; }
        [DataMember]
        public short Edad { get; set; }
        [DataMember]
        public string Email { get; set; }
    }
}