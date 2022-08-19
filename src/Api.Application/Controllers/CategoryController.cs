using System;
using System.Net;
using System.Threading.Tasks;
using Api.Domain.Dtos.Category;
using Api.Domain.Exceptions;
using Api.Domain.Interfaces.Services.Category;
using Api.Domain.Validations;
using Microsoft.AspNetCore.Mvc;

namespace Api.Application.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
        public ICategoryService _service { get; set; }
        public CategoryController(ICategoryService service)
        {
            _service = service;
        }


        [HttpGet]
        [ProducesResponseType(typeof(CategoryDtoCreateResult), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.InternalServerError)]
        public async Task<ActionResult> GetAll()
        {
            try
            {
                return Ok(await _service.GetAll());
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpGet]
        [Route("{id}", Name = "GetWithIdCategory")]
        [ProducesResponseType(typeof(CategoryDto), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.NotFound)]
        public async Task<ActionResult> Get(Guid id)
        {
            try
            {
                var results = await _service.Get(id);
                if (results is null)
                {
                    return StatusCode((int)HttpStatusCode.NotFound, "Item não encontrado");
                }
                else
                {
                    return Ok(results);
                }
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
            catch (NotFoundException e)
            {
                return StatusCode((int)HttpStatusCode.NotFound, e.Message);
            }
        }

        [HttpPost]
        [ProducesResponseType(typeof(CategoryDtoCreateResult), (int)HttpStatusCode.Created)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult> Post([FromBody] CategoryDtoCreate category)
        {
            try
            {
                var result = await _service.Post(category);
                if (result != null)
                {
                    return Created(new Uri(Url.Link("GetWithIdCategory", new { id = result.Id })), result);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
            catch (FluentValidationException e)
            {
                return StatusCode((int)HttpStatusCode.BadRequest, e.ErrorResponse);
            }
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(CategoryDtoUpdateResult), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult> Put([FromBody] CategoryDtoUpdate category, [FromRoute] Guid id)
        {
            try
            {
                var result = await _service.Put(category, id);
                if (result != null)
                {
                    return Ok(result);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
            catch (NotFoundException e)
            {
                return StatusCode((int)HttpStatusCode.NotFound, e.Message);
            }
            catch (FluentValidationException e)
            {
                return StatusCode((int)HttpStatusCode.BadRequest, e.ErrorResponse);
            }
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.NotFound)]
        public async Task<ActionResult> Delete(Guid id)
        {
            try
            {
                var results = await _service.Delete(id);
                return Ok(results);
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
            catch (NotFoundException e)
            {
                return StatusCode((int)HttpStatusCode.NotFound, e.Message);
            }
        }
    }
}
