using System;
using System.Linq;
using System.Threading.Tasks;

namespace App.Domain.Abstractions.Interfaces
{
    public interface IRepository<TEntity> : IDisposable
        where TEntity : class
    {
        /// <summary>
        ///     Obtem assincronamente uma entidade por Id
        /// </summary>
        /// <param name="id">Id da entidade</param>
        /// <returns>Retorna uma Task com a entidade requerida</returns>
        Task<TEntity> ObterPorId(Guid id);

        /// <summary>
        ///     Adiciona uma entidade no banco de dados
        /// </summary>
        /// <param name="obj">Novo objeto que deverá ser persistido</param>
        /// <returns>Task</returns>
        Task Adicionar(TEntity obj);

        // Atualizar
        /// <summary>
        ///     Atualiza uma entidade
        /// </summary>
        /// <param name="obj">Instância da entidade que deverá ser atualizado atualizado</param>
        void Atualizar(TEntity obj);

        /// <summary>
        ///     Remove (Logicamente) a entidade do banco de dados
        /// </summary>
        /// <param name="entity">Entidade que deverá ser deletada (logicamente)</param>
        /// <param name="destroy">Se TRUE, remove o regitro permanentemente do banco de dados</param>
        void Remover(
            TEntity entity,
            bool destroy = false
        );
        
        /// <summary>
        ///     Obtem um objeto IQueryable, com os filtros padrões, para leitura, se executada retorna
        ///     todos os registros da entidade especificada
        /// </summary>
        /// <returns>Retorna uma interface IQueryable da entidade especificada</returns>
        IQueryable<TEntity> ObterTodos();
    }
}