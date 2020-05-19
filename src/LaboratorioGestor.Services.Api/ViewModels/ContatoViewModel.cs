using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LaboratorioGestor.Services.Api.ViewModels
{
    public class ContatoViewModel
    {
        public string Fone1 { get; private set; }
        public string Fone2 { get; private set; }
        public string Celular { get; private set; }
        public string CelularWhatApp { get; private set; }
        public DateTime DataDoCadastro { get; private set; }
        public int TipoContato { get; private set; }
        public string Email { get; private set; }
    }
}
