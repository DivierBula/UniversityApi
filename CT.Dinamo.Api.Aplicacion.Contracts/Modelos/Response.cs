using System;
using System.Collections.Generic;
using System.Text;

namespace CT.Dinamo.Api.Aplicacion.Contracts.Modelos
{
    public class Response
    {
        public TypeCodice Codigo { get; set; }
        public string Mensaje { get; set; }
        public dynamic Result { get; set; }
    }

    public enum TypeCodice
    {
        SUCESS = 0,
        ERROR = 1,
        WARNING = 2
    }
    
}
