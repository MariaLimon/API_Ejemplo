using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
namespace API_Ejemplo.Controllers
{
    
        public class ContryController : Controller
        {
            public async Task<IActionResult> GetCountryInfo()
            {
                string baseUrl = "https://restcountries.com/v3.1/name/";
                string countryName = "Brasil";

                using (HttpClient client = new HttpClient())
                {
                    try
                    {
                        HttpResponseMessage response = await client.GetAsync(baseUrl + countryName);

                        if (response.IsSuccessStatusCode)
                        {
                            string data = await response.Content.ReadAsStringAsync();
                            // Aquí puedes deserializar los datos JSON y acceder a la información del país.
                            return Content(data, "application/json");
                        }
                        else
                        {
                            return Content($"Error: {response.StatusCode}");
                        }
                    }
                    catch (Exception ex)
                    {
                        return Content($"Error: {ex.Message}");
                    }
                }
            }
        }
}


