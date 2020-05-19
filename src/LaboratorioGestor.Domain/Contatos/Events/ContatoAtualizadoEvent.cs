using System;
using System.Collections.Generic;
using System.Text;

namespace LaboratorioGestor.Domain.Contatos.Events
{
    public class ContatoAtualizadoEvent : BaseContatoEvent
    {
        public ContatoAtualizadoEvent(
            Guid id,
            string fone1,
            string fone2,
            string celular,
            string celularWhatApp,
            DateTime dataDoCadastro,
            int tipoContato,
            string email)
        {
            Id = id;
            Fone1 = fone1;
            Fone2 = fone2;
            Celular = celular;
            CelularWhatApp = celularWhatApp;
            DataDoCadastro = dataDoCadastro;
            TipoContato = tipoContato;
            Email = email;

        }
    }
}
