using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BookStoreBluesoft.Entities
{
    public class Book
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdLibro { get; set; }
        public string NombreLibro { get; set; }
        public string ISBN { get; set; }
        public int AutoresIdAutor { get; set; }
        public int CategoriasIdCategoria { get; set; }

        public virtual Author Autores { get; set; }
        public virtual Category Categorias { get; set; }
    }
}
