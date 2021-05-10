using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using App.Application.Apartamentos.Commands;
using App.Application.Apartamentos.Queries;
using App.Application.Apartamentos.ViewModels;
using App.Application.Blocos.Commands;
using App.Application.Blocos.Queries;
using App.Application.Pessoas.Commands;
using App.Application.Pessoas.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace App.Api.Controllers
{
    [Route("api/v1/apartamentos")]
    [Produces("application/json")]
    public class ApartamentosController: ApiController
    {
        public ApartamentosController(IMediator mediator) : base(mediator)
        {
        }
        
        /// <summary>
        /// Método responsável por retornar um apartamento
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <response code="200">Retorna um apartamento</response>    
        /// <response code="400">Retorna erro ao tentar obter o apartamento</response>
        /// <response code="404">Retorna apartamento não encontrado</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{id:guid}")]
        public async Task<ActionResult<ApartamentoViewModel>> ObterPorId(Guid id)
        {
            return await Task.FromResult(Ok(await _mediator.Send(new ObterApartamentoPorIdQuery(id))));
        }
        
        /// <summary>
        /// Método responsável por retornar todos os apartamentos cadastrados
        /// </summary>
        /// <returns></returns>
        /// <response code="200">Retorna uma lista de apartamentos </response>
        /// <response code="400">Retorna algum erro ao tentar obter uma lista de apartamentos</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet]
        public async Task<ActionResult<List<ApartamentoViewModel>>> Buscar()
        {
            return await Task.FromResult(Ok(await _mediator.Send(new ObterApartamentosQuery())));
        }
        
        /// <summary>
        /// Método responsável por deletar um apartamento
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <response code="204">Retorna No Content para o apartamento deletado com sucesso</response>
        /// <response code="400">Retorna algum erro ao tentar deletar o apartamento</response>
        [HttpDelete("{id:guid}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Deletar(Guid id)
        {
            var result = await _mediator.Send(new DeletarApartamentoCommand(id));
            
            if (!result.IsSuccess)
                return await Task.FromResult(BadRequest());

            return NoContent();
        }
        
        /// <summary>
        ///     Método responsável por atualizar uma apartamento
        /// </summary>
        /// <param name="command"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <response code="200">Retorna registro atualizado com sucesso</response>
        /// <response code="400">Retorna algum erro ao tentar atualizar</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPut("{id}")]
        public async Task<ActionResult<ApartamentoViewModel>> Atualizar(
            Guid id,
            [FromBody] AtualizarApartamentoCommand command)
        {
            command.AtribuirApartamentoId(id);
            var result = await _mediator.Send(command);
            
            if (!result.IsSuccess)
                return await Task.FromResult(BadRequest());

            return await Task.FromResult(Ok(result));
        }
        
        /// <summary>
        /// Método responsável por cadastrar um morador do apartamento
        /// </summary>
        /// <param name="id"></param>
        /// <param name="command"></param>
        /// <returns></returns>
        /// <response code="201">Retorna morador cadastrado com sucesso</response>
        /// <response code="400">Retorna algum erro ao cadastrar um morador</response>
        [HttpPost("{id:guid}/pessoas")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ApartamentoViewModel>> CadastrarPessoa(
            Guid id,
            [FromBody] CadastrarPessoaCommand command)
        {
            command.AtribuirApartamentoId(id);
            var commandResult = await _mediator.Send(command);

            if (!commandResult.IsSuccess) return await Task.FromResult(BadRequest());
            
            return await Task.FromResult(CreatedAtAction(nameof(CadastrarPessoa), new { id = command.Id}, commandResult.Result));
        }
        
        /// <summary>
        /// Método responsável por retornar todos os moradores do apartamento cadastrado
        /// </summary>
        /// <returns></returns>
        /// <param name="id"></param>
        /// <param name="frase">Frase a ser pesquisada no campo nome da pessoa</param>
        /// <response code="200">Retorna uma lista de moradores do apartamento</response>
        /// <response code="400">Retorna algum erro ao tentar obter uma lista de moradores do apartamento</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet("{id:guid}/pessoas")]
        public async Task<IActionResult> BuscarMoradoresApartamento(
            Guid id,
            [FromQuery(Name = "frase")] string frase)
        {
            return await Task.FromResult(Ok(await _mediator.Send(new ObterPessoasPorApartamentoIdQuery(id, frase))));
        }
    }
}