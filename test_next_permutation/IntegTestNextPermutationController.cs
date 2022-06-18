using System;
using Xunit;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Testing;
using NextPermutation.Service;
using NextPermutation.Service.Controllers;
using Microsoft.Extensions.Logging;

namespace TestNextPermutation
{
    public class IntegTestNextPermutationController
    {
        public IntegTestNextPermutationController()
        {

        }

        [Theory]
        [InlineData(new int[] { 0, 2, 1 }, "200")]
        [InlineData(new int[] { 0, 101, 1 }, "Bad Request")]
        public void TestNextPermController(int[] array, string pattern)
        {
            Permutation perm = new();
            var logger = LoggerFactory.Create(config => config.AddConsole()).CreateLogger<NextPermutationController>();

            NextPermutationController controller = new(logger, perm);
            string result = CheckType(controller.Next(array));
            Assert.Equal(pattern, result);
        }

        static public string CheckType(IActionResult result) => result switch
        {
            ConflictResult conflict => "409",
            ConflictObjectResult conflictobj => conflictobj.Value.ToString(),
            CreatedResult created => created.StatusCode.ToString(),
            OkObjectResult okObject => okObject.StatusCode.ToString(),
            OkResult ok => ok.StatusCode.ToString(),
            BadRequestResult bad => "Bad Request",
            NotFoundResult notFound => "Not Found",
            NoContentResult noContent => "No Content",
            _ => "Other"
        };
    }
}
