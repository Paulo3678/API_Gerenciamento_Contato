﻿namespace GerenciamentoContatos.Models
{
    public class Usuario
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime DateOfCreation { get; private set; } = DateTime.Now;

    }
}
