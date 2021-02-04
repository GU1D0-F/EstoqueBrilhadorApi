using EstoqueBrilhador.Dominio._Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace EstoqueBrilhador.Dominio.Produtos
{
    public class Produto : Entidade
    {
        public string Nome { get; private set; }
        public string Codigo { get; private set; }
        public int Valor { get; private set; }
        public int Quantidade { get; private set; }

        private Produto() { }

        public Produto(string nome, string codigo, int valor, int quantidade)
        {
            ValidadorDeRegra.Novo()
                .Quando(string.IsNullOrEmpty(nome), Resource.NomeProdutoInvalido)
                .Quando(string.IsNullOrEmpty(codigo), Resource.CodigoProdutoInvalido)
                .DispararExcecaoSeExistir();

            Nome = nome;
            Codigo = codigo;
            Valor = valor;
            Quantidade = quantidade;
        }

        public void AlterarNome(string nome)
        {
            Nome = nome;
        }
    }
}
