using EstoqueBrilhador.Dominio._Base;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace EstoqueBrilhdor.DominioTest._Util
{
    public static class AssertExtension
    {
        public static void ComMensagem(this ExcecaoDeDominio exception, string mensagem)
        {
            if (exception.MensagensDeErro.Contains(mensagem))
                Assert.True(true);
            else
                Assert.False(true, $"Esperava a mensagem '{mensagem}'");
        }
    }
}
