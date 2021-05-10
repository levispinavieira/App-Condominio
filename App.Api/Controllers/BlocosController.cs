using System;
using System.Threading.Tasks;
using App.Application.Apartamentos.Commands;
using App.Application.Apartamentos.Queries;
using App.Application.Apartamentos.ViewModels;
using App.Application.Blocos.Commands;
using App.Application.Blocos.Queries;
using App.Application.Blocos.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace App.Api.Controllers
{
    [Route("api/v1/blocos")]
    [Produces("application/json")]
    public class BlocosController: ApiController
    {
        public BlocosController(IMediator mediator) : base(mediator)
        {
        }

        
        /// <summary>
        /// Método responsável por retornar um bloco
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <response code="200">Retorna um bloco</response>    
        /// <response code="400">Retorna erro ao tentar obter o bloco</response>
        /// <response code="404">Retorna bloco não encontrado</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{id:guid}")]
        public async Task<ActionResult<BlocoViewModel>> ObterPorId(Guid id)
        {
            return await Task.FromResult(Ok(await _mediator.Send(new ObterBlocoPorIdQuery(id))));
        }
        
        /// <summary>
        /// Método responsável por retornar todos os blocos cadastrados
        /// </summary>
        /// <returns></returns>
        /// <param name="frase">Frase a ser pesquisada no campo nome</param>
        /// <response code="200">Retorna uma lista de blocos </response>
        /// <response code="400">Retorna algum erro ao tentar obter uma lista de blocos</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet]
        public async Task<IActionResult> Buscar([FromQuery(Name = "frase")] string frase)
        {
            return await Task.FromResult(Ok(await _mediator.Send(new ObterBlocosQuery(frase))));
        }
        
        /// <summary>
        /// Método responsável por deletar um bloco
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <response code="204">Retorna No Content para o bloco deletado com sucesso</response>
        /// <response code="400">Retorna algum erro ao tentar deletar o bloco</response>
        [HttpDelete("{id:guid}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Deletar(Guid id)
        {
            var result = await _mediator.Send(new DeletarBlocoCommand(id));
            
            if (!result.IsSuccess)
                return await Task.FromResult(BadRequest());

            return NoContent();
        }
        
        /// <summary>
        ///     Método responsável por atualizar uma bloco
        /// </summary>
        /// <param name="command"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <response code="200">Retorna registro atualizado com sucesso</response>
        /// <response code="400">Retorna algum erro ao tentar atualizar</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPut("{id}")]
        public async Task<ActionResult<BlocoViewModel>> Atualizar(
            Guid id,
            [FromBody] AtualizarBlocoCommand command)
        {
            command.AtribuirBlocoId(id);
            var result = await _mediator.Send(command);
            
            if (!result.IsSuccess)
                return await Task.FromResult(BadRequest());

            return await Task.FromResult(Ok(result));
        }
        
        /// <summary>
        /// Método responsável por cadastrar um apartamento do bloco
        /// </summary>
        /// <param name="id"></param>
        /// <param name="command"></param>
        /// <returns></returns>
        /// <response code="201">Retorna apartamento cadastrado com sucesso</response>
        /// <response code="400">Retorna algum erro ao cadastrar um apartamento</response>
        [HttpPost("{id:guid}/apartamentos")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ApartamentoViewModel>> CadastrarApartamento(
            Guid id,
            [FromBody] CadastrarApartamentoCommand command)
        {
            command.AtribuirBlocoId(id);
            var commandResult = await _mediator.Send(command);

            if (!commandResult.IsSuccess) return await Task.FromResult(BadRequest());
            
            return await Task.FromResult(CreatedAtAction(nameof(CadastrarApartamento), new { id = command.Id}, commandResult.Result));
        }
        
        /// <summary>
        /// Método responsável por retornar todos os apartamentos do bloco cadastrados
        /// </summary>
        /// <returns></returns>
        /// <param name="id"></param>
        /// <response code="200">Retorna uma lista de apartamentos do bloco</response>
        /// <response code="400">Retorna algum erro ao tentar obter uma lista de apartamentos do bloco</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet("{id:guid}/apartamentos")]
        public async Task<IActionResult> BuscarBlocosBloco(
            Guid id)
        {
            return await Task.FromResult(Ok(await _mediator.Send(new ObterApartamentosPorBlocoIdQuery(id))));
        }
    }
}