using System;

namespace App.Domain.Abstractions.Entities
{
    public class BaseEntity
    {
        private DateTime? _cadastradoEm;
        
        public Guid Id { get; set; }
        public DateTime? DeletadoEm { get; set; }

        public DateTime CadastradoEm
        {
            get => _cadastradoEm ??= DateTime.UtcNow; 
            set => _cadastradoEm = value;
        }
    }
}