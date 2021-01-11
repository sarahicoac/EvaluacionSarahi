using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EvaluacionSarahi.Models
{
    public class DatosDescripcion
    {
        public int iIdDescripcionModelo { get; set; }

        public string sDescripcion { get; set; }
    }

    public class Descripcion
    {
        public DatosDescripcion[] CatalogoJsonString { get; set; }
        public string Error { get; set; }
    }
}