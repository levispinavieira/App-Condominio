using System;
using System.Threading.Tasks;
using App.Application.Pessoas.Commands;
using App.Application.Pessoas.Queries;
using App.Application.Pessoas.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace App.Api.Controllers
{
    [Route("api/v1/pessoas")]
    [Produces("application/json")]
    public class PessoasController: ApiController
    {
        public PessoasController(IMediator mediator) : base(mediator)
        {
        }

        
        /// <summary>
        /// Método responsável por retornar um pessoa
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <response code="200">Retorna um pessoa</response>    
        /// <response code="400">Retorna erro ao tentar obter o pessoa</response>
        /// <response code="404">Retorna pessoa não encontrado</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{id:guid}")]
        public async Task<ActionResult<PessoaViewModel>> ObterPorId(Guid id)
        {
            return await Task.FromResult(Ok(await _mediator.Send(new ObterPessoaPorIdQuery(id))));
        }
        
        /// <summary>
        /// Método responsável por retornar todos os pessoas cadastrados
        /// </summary>
        /// <returns></returns>
        /// <param name="frase">Frase a ser pesquisada no campo nome</param>
        /// <response code="200">Retorna uma lista de pessoas </response>
        /// <response code="400">Retorna algum erro ao tentar obter uma lista de pessoas</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet]
        public async Task<IActionResult> Buscar([FromQuery(Name = "frase")] string frase)
        {
            return await Task.FromResult(Ok(await _mediator.Send(new ObterPessoasQuery(frase))));
        }
        
        /// <summary>
        /// Método responsável por deletar um pessoa
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <response code="204">Retorna No Content para o pessoa deletado com sucesso</response>
        /// <response code="400">Retorna algum erro ao tentar deletar o pessoa</response>
        [HttpDelete("{id:guid}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Deletar(Guid id)
        {
            var result = await _mediator.Send(new DeletarPessoaCommand(id));
            
            if (!result.IsSuccess)
                return await Task.FromResult(BadRequest());

            return NoContent();
        }
        
        /// <summary>
        ///     Método responsável por atualizar uma pessoa
        /// </summary>
        /// <param name="command"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <response code="200">Retorna registro atualizado com sucesso</response>
        /// <response code="400">Retorna algum erro ao tentar atualizar</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPut("{id}")]
        public async Task<ActionResult<PessoaViewModel>> Atualizar(
            Guid id,
            [FromBody] AtualizarPessoaCommand command)
        {
            command.AtribuirPessoaId(id);
            var result = await _mediator.Send(command);
            
            if (!result.IsSuccess)
                return await Task.FromResult(BadRequest());

            return await Task.FromResult(Ok(result));
        }
    }
}