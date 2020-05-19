using System.Threading.Tasks;

namespace LaboratorioGestor.Infra.CrossCutting.Identity.Services
{
    public interface ISmsSender
    {
        Task SendSmsAsync(string number, string message);
    }
}
