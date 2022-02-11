using System;
using System.Collections.Generic;

namespace Sistema_Vendas.API.Models
{
    public class Usuario
    {
        public Usuario(int id, string nome, string sobrenome, string email, int telefone, DateTime dataNascimento,Endereco endereco)
        {
            this.Id = id;
            this.Nome = nome;
            this.Sobrenome = sobrenome;
            this.Email = email;
            this.Telefone = telefone;
            this.DataNascimento = dataNascimento;
            this.Endereco = endereco;
        }
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Email { get; set; }
        public int Telefone { get; set; }
        public Endereco Endereco { get; set; }
        public DateTime DataNascimento { get; set; }
        public DateTime DataIni { get; set; } = DateTime.Now;

        public IEnumerable<Automovel> Automoveis { get; set; }
    }
}