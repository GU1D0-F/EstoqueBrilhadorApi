using Bogus;
using EstoqueBrilhador.Dominio.Produtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace EstoqueBrilhdor.DominioTest._Builders
{
    public class ProdutoBuilder
    {
        protected int Id;
        protected string Nome;
        protected string Codigo;
        protected int Valor;
        protected int Quantidade;

        public static ProdutoBuilder Novo()
        {
            var faker = new Faker();

            return new ProdutoBuilder
            {
                Nome = faker.Name.Random.String(),
                Codigo = faker.Random.Number(0).ToString(),
                Valor = faker.Random.Int(0, 5000),
                Quantidade = faker.Random.Int(0, 100)
            };
        }

        public ProdutoBuilder ComNome(string nome)
        {
            Nome = nome;
            return this;
        }

        public ProdutoBuilder ComCodigo(string codigo)
        {
            Codigo = codigo;
            return this;
        }

        public ProdutoBuilder ComValor(int valor)
        {
            Valor = valor;
            return this;
        }

        public ProdutoBuilder ComQuantidade(int quantidade)
        {
            Quantidade = quantidade;
            return this;
        }

        public ProdutoBuilder ComId(int id)
        {
            Id = id;
            return this;
        }

        public Produto Build()
        {
            var produto = new Produto(Nome, Codigo, Valor, Quantidade);

            if (Id <= 0) return produto;

            var propertyInfo = produto.GetType().GetProperty("Id");
            propertyInfo.SetValue(produto, Convert.ChangeType(Id, propertyInfo.PropertyType), null);

            return produto;
        }


    }
}
