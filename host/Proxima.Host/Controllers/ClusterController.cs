using System.Collections.Generic;
using System.Threading.Tasks;
using k8s;
using Microsoft.AspNetCore.Mvc;
using Proxima.Host.Interfaces;

namespace Proxima.Host.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClusterController : ControllerBase
    {
        private readonly IClusterService _clusterService;

        public ClusterController(IClusterService clusterService)
        {
            _clusterService = clusterService;
        }

        [HttpGet("info")]
        public async Task<IActionResult> GetClusterInfo()
        {
            return Ok(await _clusterService.GetClusterInfo());
        }
    }
}
