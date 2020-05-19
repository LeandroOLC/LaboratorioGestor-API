using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LaboratorioGestor.Services.Api.ViewModels
{
    public class LaboratorioViewModel
    {
        public string Nome { get; set; }
        public string Proprietario { get; set; }
        public string TPO { get; set; }
        public string Documento { get; set; }
        public int TipoPessoa { get; set; }
        public DateTime? DataDoCadastro { get; set; }
    }
}
