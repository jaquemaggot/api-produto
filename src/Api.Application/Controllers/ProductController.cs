using System;
using System.Net;
using System.Threading.Tasks;
using Api.Domain.Dtos.Product;
using Api.Domain.Exceptions;
using Api.Domain.Interfaces.Services.Product;
using Api.Domain.Validations;
using Microsoft.AspNetCore.Mvc;

namespace Api.Application.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        public IProductService _service { get; set; }
        public ProductController(IProductService service)
        {
            _service = service;
        }

        [HttpGet]
        [ProducesResponseType(typeof(ProductDto), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.InternalServerError)]
        public async Task<ActionResult> GetAll()
        {
            try
            {
                var results = await _service.GetAll();
                return Ok(results);
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpGet]
        [Route("{id}", Name = "GetWithIdProduct")]
        [ProducesResponseType(typeof(ProductDto), (int)HttpStatusCode.OK)]
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
        [ProducesResponseType(typeof(ProductDtoCreateResult), (int)HttpStatusCode.Created)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult> Post([FromBody] ProductDtoCreate product)
        {
            try
            {
                var result = await _service.Post(product);
                if (result != null)
                {
                    return Created(new Uri(Url.Link("GetWithIdProduct", new { id = result.Id })), result);
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

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(ProductDtoUpdateResult), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult> Put([FromBody] ProductDtoUpdate product, [FromRoute] Guid id)
        {
            try
            {
                var result = await _service.Put(product, id);

                if (result is null)
                {
                    return StatusCode((int)HttpStatusCode.NotFound, "Item não encontrado para alteração");
                }
                else
                {
                    return Ok(result);
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
                var result = await _service.Delete(id);
                if (result != false)
                {
                    return Ok(result);
                }
                else
                {
                    return StatusCode((int)HttpStatusCode.NotFound, "Item não encontrado para exclusão");
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

    }
}
