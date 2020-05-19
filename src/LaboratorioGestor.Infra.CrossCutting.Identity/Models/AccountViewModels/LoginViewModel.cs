﻿using System.ComponentModel.DataAnnotations;

namespace LaboratorioGestor.Infra.CrossCutting.Identity.Models.AccountViewModels
{
    public class LoginViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Senha { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }
}