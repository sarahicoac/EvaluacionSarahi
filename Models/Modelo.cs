using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EvaluacionSarahi.Models
{
    public class DatosModelo
    {
        public int iIdModelo { get; set; }

        public string sModelo { get; set; }
    }
    
    public class Modelo
    {
        public DatosModelo[] CatalogoJsonString { get; set; }
        public string Error { get; set; }
    }
}