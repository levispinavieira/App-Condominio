using System;

namespace App.Application.Abstractions
{
    public abstract class BaseViewModel
    {
        public Guid Id { get; set; }
        
        public DateTime CadastradoEm { get; set; }
        
        public DateTime? DeletadoEm { get; set; }
        
        public DateTime AtualizadoEm { get; set; }
        
        public bool Ativo { get; set; }
    }
}