using BookStoreBluesoft.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookStoreBluesoft.Core.Util
{
    public static class Utilidades
    {
        public static string MensajesResult<T>(List<T> listobject)
        {
            var mensajeResultado = string.Empty;
            if (!listobject.Any())
            {
                mensajeResultado = Messages.SinResultados;
            }

            return mensajeResultado;
        }
    }
}
