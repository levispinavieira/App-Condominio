using App.Application.Abstractions;

namespace App.Application.Condominios.ViewModels
{
    public class CondominioViewModel : BaseViewModel
    {
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string EmailSindico { get; set; }
    }
}