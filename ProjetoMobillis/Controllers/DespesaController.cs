using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoMobills.Data.Models;
using ProjetoMobills.Data.Respository;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public IActionResult GetAll()
        {
            return new ObjectResult(_unitOfWork.Despesa.List());
        }

        [HttpGet("{id:Guid}", Name = "GetDespesaById")]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetById([FromRoute] int id)
        {
            Task<Despesa> Despesa = _unitOfWork.Despesa.GeyById(id);
            if(Despesa.IsCompleted)
            {
                return new OkObjectResult(Despesa);
            }
            return new NotFoundResult();
        }

        [HttpPost]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult Save([FromBody] Despesa despesa)
        {
            Task<int> despesValid = _unitOfWork.Despesa.Add(despesa);
            if (ModelState.IsValid)
            {
                return new OkObjectResult(despesValid);
            }
            return new BadRequestObjectResult(despesa);
        }

        [HttpPut]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status406NotAcceptable)]
        public IActionResult Update([FromBody] Despesa despesa)
        {
            Task<int> UpdateEnfermeiro = _unitOfWork.Despesa.Update(despesa);
            return new OkObjectResult(UpdateEnfermeiro);
        }

        [HttpDelete("{id:Guid}")]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Delete([FromRoute] int Id)
        {
            _unitOfWork.Despesa.Delete(Id);
            return new NoContentResult();
        }

    }
}
