using EstoqueBrilhador.Dominio._Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace EstoqueBrilhador.Dominio.Produtos
{
    public class Produto : Entidade<Produto, long>
    {
        public string Nome { get; set; }
        public string Codigo { get; set; }
        public double Valor { get; set; }
        public int Quantidade { get; set; }
        public long IdFornecedor { get; set; }

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
