using netimoveis.Net.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace netimoveis.Net.Controllers
{
    public class ImovelController : Controller
    {
        private string _endpointnetimoveisImoveis = WebConfigurationManager.AppSettings["endpointnetimoveisImoveis"].ToString();

        // GET: Imovel
        public ActionResult Index()
        {
            IList<Imovel> model = new List<Imovel>();

            using (var client = new WebClient())
            {
                var jsonReturnnetimoveisImoveis= client.DownloadString(_endpointnetimoveisImoveis);
                model = new JavaScriptSerializer().Deserialize<IList<Imovel>>(jsonReturnnetimoveisImoveis);
            }

            return View(model);
        }

        public ActionResult FormularioAddImovel()
        {
            Imovel model = new Imovel();

            return View(model);
        }

        [HttpPost]
        public ActionResult SaveImovel(Imovel imovel)
        {
            if (ModelState.IsValid && imovel.Id < 1)
            {
                using (HttpClient client = new HttpClient())
                {
                    imovel.Id = GerarIdRandomico();
                    string json = new JavaScriptSerializer().Serialize(imovel);
                    client.BaseAddress = new Uri(_endpointnetimoveisImoveis);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");
                    var result = client.PostAsync(_endpointnetimoveisImoveis, content).Result;
                    Task<string> resultContent = result.Content.ReadAsStringAsync();
                    var codigoRetorno = (int)result.StatusCode;
                    var JsonRetorno = resultContent.Result;

                    return RedirectToRoute(new { contoller = "Imovel", action = "Index" });
                }
            }

            return View("FormularioAddImovel", imovel);
        }

        private int GerarIdRandomico()
        {
            Random r = new Random();
            return r.Next(1, 100);
        }

        public ActionResult Deletar(string id)
        {
            using (HttpClient client = new HttpClient())
            {
                var response = client.DeleteAsync(string.Format(_endpointnetimoveisImoveis + "/{0}", id)).Result;
                
                //Redireciona para a listagem de imoveis 
                return RedirectToRoute(new { contoller = "Imovel", action = "Index" });
            }
        }
    }
}