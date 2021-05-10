using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using App.Application.Blocos.Commands;
using App.Application.Blocos.Queries;
using App.Application.Condominios.Commands;
using App.Application.Condominios.Queries;
using App.Application.Condominios.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace App.Api.Controllers
{
    [Route("api/v1/condominios")]
    [Produces("application/json")]
    public class CondominiosController: ApiController
    {
        public CondominiosController(IMediator mediator) : base(mediator)
        {
        }

        /// <summary>
        /// Método responsável por cadastrar um condominio
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        /// <response code="201">Retorna condominio cadastrado com sucesso</response>
        /// <response code="400">Retorna algum erro ao cadastrar um condominio</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<CondominioViewModel>> Cadastrar([FromBody] CadastrarCondominioCommand command)
        {
            var commandResult = await _mediator.Send(command);

            if (!commandResult.IsSuccess) return await Task.FromResult(BadRequest());
            
            return await Task.FromResult(CreatedAtAction(nameof(Cadastrar), new { id = command.Id}, await _mediator.Send(new ObterCondominioPorIdQuery(command.Id))));
        }
        
        /// <summary>
        /// Método responsável por retornar um condominio
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <response code="200">Retorna um condominio</response>    
        /// <response code="400">Retorna erro ao tentar obter o condominio</response>
        /// <response code="404">Retorna condominio não encontrado</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{id:guid}")]
        public async Task<ActionResult<CondominioViewModel>> ObterPorId(Guid id)
        {
            return await Task.FromResult(Ok(await _mediator.Send(new ObterCondominioPorIdQuery(id))));
        }
        
        /// <summary>
        /// Método responsável por retornar todos os condominios cadastrados
        /// </summary>
        /// <returns></returns>
        /// <param name="frase">Frase a ser pesquisada no campo nome</param>
        /// <response code="200">Retorna uma lista de condominios </response>
        /// <response code="400">Retorna algum erro ao tentar obter uma lista de condominios</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet]
        public async Task<ActionResult<List<CondominioViewModel>>> Buscar([FromQuery(Name = "frase")] string frase)
        {
            return await Task.FromResult(Ok(await _mediator.Send(new ObterCondominiosQuery(frase))));
        }
        
        /// <summary>
        /// Método responsável por deletar um condominio
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <response code="204">Retorna No Content para o condominio deletado com sucesso</response>
        /// <response code="400">Retorna algum erro ao tentar deletar o condominio</response>
        [HttpDelete("{id:guid}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Deletar(Guid id)
        {
            var result = await _mediator.Send(new DeletarCondominioCommand(id));
            
            if (!result.IsSuccess)
                return await Task.FromResult(BadRequest());

            return NoContent();
        }
        
        /// <summary>
        ///     Método responsável por atualizar uma condominio
        /// </summary>
        /// <param name="command"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <response code="200">Retorna registro atualizado com sucesso</response>
        /// <response code="400">Retorna algum erro ao tentar atualizar</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPut("{id}")]
        public async Task<ActionResult<CondominioViewModel>> Atualizar(
            Guid id,
            [FromBody] AtualizarCondominioCommand command)
        {
            command.AtribuirCondominioId(id);
            var result = await _mediator.Send(command);
            
            if (!result.IsSuccess)
                return await Task.FromResult(BadRequest());

            return await Task.FromResult(Ok(result));
        }
        
        /// <summary>
        /// Método responsável por cadastrar um bloco do condomio
        /// </summary>
        /// <param name="id"></param>
        /// <param name="command"></param>
        /// <returns></returns>
        /// <response code="201">Retorna condominio cadastrado com sucesso</response>
        /// <response code="400">Retorna algum erro ao cadastrar um condominio</response>
        [HttpPost("{id:guid}/blocos")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<CondominioViewModel>> CadastrarBloco(
            Guid id,
            [FromBody] CadastrarBlocoCommand command)
        {
            command.AtribuirCondominioId(id);
            var commandResult = await _mediator.Send(command);

            if (!commandResult.IsSuccess) return await Task.FromResult(BadRequest());
            
            return await Task.FromResult(CreatedAtAction(nameof(CadastrarBloco), new { id = command.Id}, commandResult.Result));
        }
        
        /// <summary>
        /// Método responsável por retornar todos os blocos do condominio cadastrados
        /// </summary>
        /// <returns></returns>
        /// <param name="id"></param>
        /// <param name="frase">Frase a ser pesquisada no campo nome do bloco</param>
        /// <response code="200">Retorna uma lista de blocos do condominio</response>
        /// <response code="400">Retorna algum erro ao tentar obter uma lista de blocos do condominio</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet("{id:guid}/blocos")]
        public async Task<IActionResult> BuscarBlocosCondominio(
            Guid id,
            [FromQuery(Name = "frase")] string frase)
        {
            return await Task.FromResult(Ok(await _mediator.Send(new ObterBlocosPorCondominioIdQuery(id, frase))));
        }
    }
}