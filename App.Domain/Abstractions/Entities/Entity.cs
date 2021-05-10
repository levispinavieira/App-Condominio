using System;

namespace App.Domain.Abstractions.Entities
{
    public abstract class Entity: BaseEntity, IEquatable<Entity>
    {
        private DateTime? _atualizadoEm;
        
        public DateTime AtualizadoEm
        {
            get => _atualizadoEm ??= DateTime.UtcNow;
            set => _atualizadoEm = value;
        }
        
        public bool Ativo { get; set; }
        
        protected Entity()
        {
        }
        
        protected Entity(Guid id)
        {
            Id = id;
            CadastradoEm = DateTime.UtcNow;
            AtualizadoEm = CadastradoEm;
            Ativo = true;
        }

        public bool Equals(Entity other)
        {
            return Id == other?.Id;
        }
    }
}
