using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InterfaceBuilder.Model;
using Microsoft.AspNetCore.Mvc;

namespace InterfaceBuilder.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class TemplateBuilderController : Controller
    {
        // POST api/values
        [HttpPost]
        public string Post([FromBody]Window window)
        {
            try
            {
                Engine.Builder builder = new Engine.Builder();
                return builder.Build(window);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}