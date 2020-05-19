﻿using System.Threading.Tasks;

namespace LaboratorioGestor.Infra.CrossCutting.Identity.Services
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string email, string subject, string message);
    }
}