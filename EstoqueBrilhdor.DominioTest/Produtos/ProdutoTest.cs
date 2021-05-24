using Bogus;
using EstoqueBrilhador.Dominio._Base;
using EstoqueBrilhador.Dominio.Produtos;
using EstoqueBrilhdor.DominioTest._Builders;
using EstoqueBrilhdor.DominioTest._Util;
using ExpectedObjects;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace EstoqueBrilhdor.DominioTest.Produtos
{
    public class ProdutoTest
    {
        private readonly Faker _faker;

        public ProdutoTest()
        {
            _faker = new Faker();
        }

        [Fact]
        public void DeveCriarProduto()
        {
            var produtoEsperado = new
            {
                Nome = _faker.Name.Random.String(),
                Codigo = _faker.Random.Number(0).ToString(),
                Valor = _faker.Random.Int(0, 5000),
                Quantidade = _faker.Random.Int(0, 100)
            };

            var produto = new Produto(produtoEsperado.Nome, produtoEsperado.Codigo, produtoEsperado.Valor, produtoEsperado.Quantidade);

            produtoEsperado.ToExpectedObject().ShouldMatch(produto); 
        }

        [Fact]
        public void DeveAlterarNome()
        {
            var novoNomeEsperado = _faker.Name.Random.String();
            var produto = ProdutoBuilder.Novo().Build();

            produto.AlterarNome(novoNomeEsperado);

            Assert.Equal(novoNomeEsperado, produto.Nome);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void NaoDeveCriarComNomeInvalido(string nomeInvalido)
        {
            Assert.Throws<ExcecaoDeDominio>(() =>
                ProdutoBuilder.Novo().ComNome(nomeInvalido).Build())
                .ComMensagem(Resource.NomeProdutoInvalido);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        [InlineData("jdpasjdpasd")]
        [InlineData("Codigo Invalido")]
        public void NaoDeveCriarComCodigoInvalido(string codigoInvalido)
        {
            Assert.Throws<ExcecaoDeDominio>(() =>
                ProdutoBuilder.Novo().ComCodigo(codigoInvalido).Build())
                .ComMensagem(Resource.CodigoProdutoInvalido);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void NaoDeveCriarComValorInvalido(int valorInvalido)
        {
            Assert.Throws<ExcecaoDeDominio>(() =>
                ProdutoBuilder.Novo().ComValor(valorInvalido).Build())
                .ComMensagem(Resource.ValorProdutoInvalido);
        }
    }
}
