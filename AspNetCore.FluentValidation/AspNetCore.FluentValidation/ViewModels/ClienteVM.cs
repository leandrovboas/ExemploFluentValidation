using System;

namespace AspNetCore.FluentValidation.ViewModels
{
    public class ClienteVM
    {
        public string Nome { get; set; }
        public string SobreNome { get; set; }
        public string Email { get; set; }
        public DateTime DataNascimento { get; set; }
    }
}
