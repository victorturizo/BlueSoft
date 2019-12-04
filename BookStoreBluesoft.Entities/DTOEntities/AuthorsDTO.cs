using System;
using System.Collections.Generic;
using System.Text;

namespace BookStoreBluesoft.Entities.DTOEntities
{
    public class AuthorsDTO
    {
        public int IdAutor { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public DateTime FechaNacimiento { get; set; }
    }
}
