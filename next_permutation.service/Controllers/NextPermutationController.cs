using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace NextPermutation.Service.Controllers
{
    [Route("permutation/next")]
    [ApiController]
    public class NextPermutationController : ControllerBase
    {
        readonly ILogger<NextPermutationController> logger;
        readonly IPermutation permutter;

        public NextPermutationController(ILogger<NextPermutationController> _logger, IPermutation _permutter)
        {
            logger = _logger;
            permutter = _permutter;
        }

        public IActionResult Next([FromBody] int[] array)
        {
            logger.LogInformation("Service called for " + array.ToString());
            try
            {
                if ( array.Length < 0 || array.Length > 100 )
                {
                    logger.LogError("Error in length: " + array.Length.ToString());
                    return BadRequest();
                }
                foreach (int item in array)
                {
                    if (item < 0 || item > 100)
                    {
                        logger.LogError("Error in item. Expected between 0 and 100. Got " + item.ToString());
                        return BadRequest();
                    }
                }
                return Ok(permutter.GetNextPermutation(array));
            }
            catch 
            {
                logger.LogError("Some other error.");
                return BadRequest();
            }
        }
    }
}
