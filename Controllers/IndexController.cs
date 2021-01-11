using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using RestSharp;
using EvaluacionSarahi.Models;

namespace EvaluacionSarahi.Controllers
{
    public class IndexController : Controller
    {
        // GET: Index
        public ActionResult Index()
        {
            var json = ConsumoApi("Marca", "1", 2);
            var marcaD = JsonConvert.DeserializeObject<Marca>(json);

            DatosMarca[] listaC = null;
            listaC = marcaD.CatalogoJsonString;


            return View(listaC);
        }
        public String ConsumoApi(string NombreCatalogo, string Filtro, int IdAplicacion)
        {

            var client = new RestClient("https://apitestcotizamatico.azurewebsites.net/api/catalogos");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/json");
            //request.AddHeader("Cookie", "ARRAffinity=d5541f6ca74e10bb0f1ff47b61d5cfaf3bae0db9932687c28209801ef63b23d3; ARRAffinitySameSite=d5541f6ca74e10bb0f1ff47b61d5cfaf3bae0db9932687c28209801ef63b23d3");
            request.AddParameter("application/json", "{\r\n    \"NombreCatalogo\": \"" + NombreCatalogo + "\",\r\n    \"Filtro\": \"" + Filtro + "\",\r\n    \"IdAplicacion\": " + IdAplicacion + "\r\n}", ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);

            var json = response.Content;

            
            int location = json.IndexOf("[");
            if (location >= 0)
            {
                location = location - 1;
                json = json.Remove(location, 1);
            }    
            location = json.IndexOf("]");
            if (location >= 0)
            {
                location = location + 1;
                json = json.Remove(location, 1);
                json = json.Replace("\\", "");
            }
            return json;
        }

     
        public JsonResult Submarca(string IdSubMarca)
        {
            var json = ConsumoApi("Submarca", IdSubMarca, 2);
            try
            {
                var submarcaD = JsonConvert.DeserializeObject<Submarca>(json);

                DatosSubmarca[] listaC = null;
                listaC = submarcaD.CatalogoJsonString;
                return Json(listaC, JsonRequestBehavior.AllowGet);
            }
            catch(Exception e)
            {
                return null;
            }
            

        }

        public JsonResult Modelo(string IdModelo)
        {
         try { 
            var json = ConsumoApi("Modelo", IdModelo, 2);

            var modeloD = JsonConvert.DeserializeObject<Modelo>(json);

            DatosModelo[] listaC = null;
            listaC = modeloD.CatalogoJsonString;

            return Json(listaC, JsonRequestBehavior.AllowGet);
        }
        catch(Exception e)
            {
                return null;
            }

        }

        public JsonResult Descripcion(string IdDescripcion)
        {
         try { 
            var json = ConsumoApi("DescripcionModelo", IdDescripcion, 2);
            var descripcionD = JsonConvert.DeserializeObject<Descripcion>(json);

            DatosDescripcion[] listaC = null;
            listaC = descripcionD.CatalogoJsonString;

            return Json(listaC, JsonRequestBehavior.AllowGet);
            }
            catch(Exception e)
            {
                return null;
            }

        }


        
    }
}