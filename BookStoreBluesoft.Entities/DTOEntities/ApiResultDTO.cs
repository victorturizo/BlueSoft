using System;
using System.Collections.Generic;
using System.Text;

namespace BookStoreBluesoft.Entities.DTOEntities
{
    public class ApiResultDTO
    {
        public string Mensaje { get; set; }

        public bool isError { get; set; }

        public object Resultado { get; set; }
    }
}
