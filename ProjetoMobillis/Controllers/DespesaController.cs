using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoMobills.Data.Models;
using ProjetoMobills.Data.Respository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Mime;
using System.Threading.Tasks;

namespace ProjetoMobills.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class DespesaController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public DespesaController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        [Consumes(MediaTypeNames.Application.Json)]
        public async Task<IActionResult> GetAll()
        {
            var data = await _unitOfWork.Despesa.List();
            return Ok(data);
        }

        [HttpGet("{id:Guid}", Name = "GetDespesaById")]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var data = await _unitOfWork.Despesa.GeyById(id);
            if(data != null)
            {
                return Ok(data);
            }
            return new NotFoundResult();
        }

        [HttpPost]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Save([FromBody] Despesa despesa)
        {
            var data = await _unitOfWork.Despesa.Add(despesa);
            if (ModelState.IsValid)
            {
                return Ok(data);
            }
            return new BadRequestObjectResult(despesa);
        }

        [HttpPut]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status406NotAcceptable)]
        public async Task<IActionResult> Update([FromBody] Despesa despesa)
        {
            var data = await _unitOfWork.Despesa.Update(despesa);
            return Ok(data);
        }

        [HttpDelete("{id:Guid}")]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Delete([FromRoute] int Id)
        {
          var data = _unitOfWork.Despesa.Delete(Id);
            return Ok(data);
        }

    }
}
