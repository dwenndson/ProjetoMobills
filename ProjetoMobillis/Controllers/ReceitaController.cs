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
    public class ReceitaController : ControllerBase
    {
        private readonly IReceitaRepository _receitaRepository;

        public ReceitaController(IReceitaRepository receitaRepository)
        {
            _receitaRepository = receitaRepository;
        }

        [HttpGet]
        [Consumes(MediaTypeNames.Application.Json)]
        public IActionResult GetAll()
        {
            return new ObjectResult(_receitaRepository.List());
        }

        [HttpGet("{id:Guid}", Name = "GetReceitaById")]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetById([FromRoute] int id)
        {
            Task<Receita> receita = _receitaRepository.GeyById(id);
            if(receita.IsCompleted)
            {
                return new OkObjectResult(receita);
            }
            return new NotFoundResult();
        }

        [HttpPost]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult Save([FromBody] Receita receita)
        {
            Task<int> despesValid = _receitaRepository.Add(receita);
            if (ModelState.IsValid)
            {
                return new OkObjectResult(despesValid);
            }
            return new BadRequestObjectResult(receita);
        }

        [HttpPut]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status406NotAcceptable)]
        public IActionResult Update([FromBody] Receita receita)
        {
            Task<int> UpdateEnfermeiro = _receitaRepository.Update(receita);
            return new OkObjectResult(UpdateEnfermeiro);
        }

        [HttpDelete("{id:Guid}")]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Delete([FromRoute] int Id)
        {
            _receitaRepository.Delete(Id);
            return new NoContentResult();
        }

    }
}
