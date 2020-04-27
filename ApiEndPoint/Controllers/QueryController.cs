using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;

using ApiEndPoint.Models;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Cors;

namespace ApiEndPoint.Controllers
{
    [EnableCors("CorsApi")]
    [Route("api/[controller]")]
    [ApiController]
    public class QueryController : ControllerBase
    {
        public string URL_API = "https://itunes.apple.com/search?";
        public string PARAMETERS = "term=";

        public string URL_API2 = "http://api.tvmaze.com/search/shows?";
        public string PARAMETERS2 = "q=";

        public async Task<String> Index()
        {
            RootViewModel lst = new RootViewModel();
            List<object> temp = new List<object>();
            using (var httpClient = new HttpClient())
            {

                using (var response = await httpClient.GetAsync(URL_API+PARAMETERS+"sebastian+yatra"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();

                    lst = JsonConvert.DeserializeObject<RootViewModel>(apiResponse);

                    //var jsonDeserialize = JsonConvert.DeserializeObject(apiResponse);

                }
            }
            return JsonConvert.SerializeObject(lst);
        }

        [HttpPost]
        public async Task<ExportViewModel> getValues([FromBody] UserViewModel model)
        {
            RootViewModel lst = new RootViewModel();
            List<Root2ViewModel> rootlst2 = new List<Root2ViewModel>();
            string lst2 = "";

            using (var httpClient = new HttpClient())
            {
                
                using (var response = await httpClient.GetAsync(URL_API + PARAMETERS + model.Nombre.Replace(" ","+")))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();

                    lst = JsonConvert.DeserializeObject<RootViewModel>(apiResponse);

                }

                using (var response = await httpClient.GetAsync(URL_API2 + PARAMETERS2 + model.Nombre))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();

                    lst2 = apiResponse;
                    rootlst2 = JsonConvert.DeserializeObject<List<Root2ViewModel>>(apiResponse);

                }
            }

            ExportViewModel oExport = new ExportViewModel();
            oExport.source = JsonConvert.SerializeObject(lst);
            oExport.source2 = JsonConvert.SerializeObject(rootlst2);
            return oExport;

        }



    }
}