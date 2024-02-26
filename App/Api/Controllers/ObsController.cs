using Microsoft.AspNetCore.Mvc;
using Services;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ObsController : ControllerBase
    {
        private readonly Lazy<IStreamService> _streamService;

        public ObsController(Lazy<IStreamService> streamService)
        {
            _streamService = streamService;
        }


    }
}
