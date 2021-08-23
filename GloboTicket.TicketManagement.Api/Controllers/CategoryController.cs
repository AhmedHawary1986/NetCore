using GloboTicket.Ticketmanagement.Application.Features.Category.Command.CreateCategory;
using GloboTicket.Ticketmanagement.Application.Features.Category.Queries.GetCategoryList;
using GloboTicket.Ticketmanagement.Application.Features.Category.Queries.GetCategoryListWithEvents;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GloboTicket.TicketManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CategoryController(IMediator Mediator)
        {
            _mediator = Mediator;
        }

        [HttpGet("all",Name = "GetAllCategories")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<CategoryListVM>>> GetAllCategories()
        {
            var categories = await _mediator.Send(new GetCategoryListQuery());

            return Ok(categories);
        }

        [HttpGet("allWithEvents",Name = "GetAllCategoriesWithEvent")]
        [ProducesDefaultResponseType]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<CategoryEventListVM>>> GetAllCategoriesWithEvent()
        {
            var categoriesWithEvents = await _mediator.Send(new GetCategoryListWithEventQuery() { IncludeHistory = true });
            return Ok(categoriesWithEvents);
        }

        [HttpPost("AddCategory")]
        public async Task<ActionResult<CreateCategoryCommandResponse>> Create([FromBody]CreateCategoryCommand request)
        {
           var response = await _mediator.Send(request);
            return Ok(response);
        }


    }
}
