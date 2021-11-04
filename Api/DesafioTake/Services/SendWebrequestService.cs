using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace DesafioTake.Services
{  
    public static class SendWebrequestService
    {
        //Serviço que envia requisições get e devolve a resposta para o controller solicitante
        public static async Task<string> SendGetRequest(string url)
        {
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("User-Agent", "C# App");
            try
            {
                var response = await httpClient.GetAsync(url);

               if(response.IsSuccessStatusCode)
                {
                  var data = await response.Content.ReadAsStringAsync();
                  return data;

                }

                else
                {
                    throw new Exception((int)response.StatusCode + " - " + response.ReasonPhrase);
                }
                    
                
            }

            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
