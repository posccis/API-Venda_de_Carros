using System;
using System.Collections.Generic;

namespace Sistema_Vendas.API.Models
{
    public class Motocicleta
    {

        public Motocicleta(int usuarioId, string marca, string modelo, float valor,int ano, string cor, string combustivel, int cilindradas, int marchas, string partida, string motor, int quilometragem, bool troca)
        {
            this.UsuarioId = usuarioId;
            this.Marca = marca;
            this.Modelo = modelo;
            this.Valor = valor;
            this.Ano = ano;
            this.Cor = cor;
            this.Combustivel = combustivel;
            this.Cilindradas = cilindradas;
            this.Marchas = marchas;
            this.Partida = partida;
            this.Motor = motor;
            this.Quilometragem = quilometragem;
            this.Troca = troca;
 
        }
        public int UsuarioId { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public float Valor { get; set; }
        public int Ano { get; set; }
        public string Cor { get; set; }
        public string Combustivel { get; set; }
        public int Cilindradas { get; set; }
        public int Marchas { get; set; }
        public string Partida { get; set; }
        public string Motor { get; set; }
        public int Quilometragem { get; set; }
        public bool Troca { get; set; }
        public string[] Itens { get; set; }
        public DateTime Data_Anuncio { get; set; } = DateTime.Now;
        public bool Ativo { get; set; }
    }
}