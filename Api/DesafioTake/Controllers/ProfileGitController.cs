using DesafioTake.Models;
using DesafioTake.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace DesafioTake.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfileGitController : ControllerBase
    {
        private readonly ILogger _logger;

        public ProfileGitController (ILogger<ProfileGitController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
    
        public async Task<ActionResult<List<ProfileGitModel>>> getUser()
        {
            // task responsavel por consultar a api do gtithub, pegar o resultado e filtrar conforme pedido no desafio
          
            List<ProfileGitModel> profile;
            var url = "https://api.github.com/orgs/takenet/repos";
            try
            {
                string data = await SendWebrequestService.SendGetRequest(url);
                profile = JsonConvert.DeserializeObject<List<ProfileGitModel>>(data);
                var result = profile.Where(x => x.Language == "C#").OrderBy(y => y.Created_at).Take(5);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "error querying github API");
                return StatusCode(500);
            }
           
        }

    }
}
