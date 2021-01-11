using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EvaluacionSarahi.Models
{
    public class DatosSubmarca
    {
        public int iIdSubMarca { get; set; }

        public string sSubMarca { get; set; }
    }
    public class Submarca
    {
        public DatosSubmarca[] CatalogoJsonString { get; set; }
        public string Error { get; set; }
    }
}