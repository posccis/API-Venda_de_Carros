using System;
using System.Collections.Generic;

namespace Sistema_Vendas.API.Models
{
    public class Carro
    {
        public Carro(int usuarioId, string marca, string modelo, string categoria,float valor,int ano, string cor, string combustivel, int quilometragem, bool troca, bool ativo)
        {
            this.UsuarioId = usuarioId;
            this.Marca = marca;
            this.Modelo = modelo;
            this.Categoria = categoria;
            this.Valor = valor;
            this.Ano = ano;
            this.Cor = cor;
            this.Combustivel = combustivel;
            this.Quilometragem = quilometragem;
            this.Troca = troca;
            this.Ativo = ativo;

        }
        public int UsuarioId { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Categoria { get; set; }
        public float Valor { get; set; }
        public int Ano { get; set; }
        public string Cor { get; set; }
        public string Combustivel { get; set; }
        public string Motor { get; set; }
        public int Quilometragem { get; set; }
        public bool Troca { get; set; }
        public string[] Itens { get; set; }
        public DateTime Data_Anuncio { get; set; } = DateTime.Now;
        public bool Ativo { get; set; }
    }
}