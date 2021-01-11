using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EvaluacionSarahi.Models
{
    public class DatosMarca
    {
        public int iIdMarca { get; set; }

        public string sMarca { get; set; }
    }
    public class Marca
    {
        public DatosMarca[] CatalogoJsonString { get; set; }
        public string Error { get; set; }
    }
}