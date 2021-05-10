using System;
using App.Application.Abstractions;

namespace App.Application.Pessoas.ViewModels
{
    public class PessoaViewModel : BaseViewModel
    {
        public string NomeCompleto { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Telefone { get; set; }
        public string Cpf { get; set; }
        public string Email { get; set; }
        public Guid ApartamentoId { get; set; }
    }
}