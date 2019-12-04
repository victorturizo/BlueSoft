using System;
using System.Collections.Generic;
using System.Text;

namespace BookStoreBluesoft.Entities.DTOEntities
{
    public class LibraryDTO
    {
     
        public string Nombres { get; set; }  
        public string Apellidos { get; set; }   
        public DateTime? FechaNacimiento { get; set; }
        public int? IdCategoria { get; set; }
        public int? IdAutor { get; set; }
        public string ISBN { get; set; }
        public string Descripcion { get; set; }

    }
}
