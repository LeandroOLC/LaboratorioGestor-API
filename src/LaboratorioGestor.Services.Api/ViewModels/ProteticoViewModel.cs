using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LaboratorioGestor.Services.Api.ViewModels
{
    public class ProteticoViewModel
    {
        public string Nome { get; set; }
        public double PercentualDaComissao { get; set; }
        public DateTime? DataDoCadastro { get; set; }
        public string CPF { get; set; }
        public Guid? IDContato { get; set; }
    }
}
