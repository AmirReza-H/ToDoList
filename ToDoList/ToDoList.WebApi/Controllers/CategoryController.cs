using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using ToDoList.Application.Features.Categorys.Commands;

namespace ToDoList.WebApi.Controllers
{
    [ApiController]

    public class CategoryController : BaseApiController
    {



        [HttpPost("create-category")]
        public async Task<IActionResult> CreateCategory(CreateCategoryCommand request)
        {
            // check user nameNmae in token
            return Ok( await Mediator.Send(request));
        }
    }
}
