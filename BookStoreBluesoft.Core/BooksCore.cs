using BookStoreBluesoft.Common;
using BookStoreBluesoft.Core.Util;
using BookStoreBluesoft.Entities;
using BookStoreBluesoft.Entities.DTOEntities;
using BookStoreBluesoft.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace BookStoreBluesoft.Core
{
    public class BooksCore
    {
        private readonly BookStoreContext bookStoreContext;
        public BooksCore(BookStoreContext _bookStoreContext)
        {
            this.bookStoreContext = _bookStoreContext;
        }

        public ApiResultDTO Adicionar(LibraryDTO entity)
        {
            var Apiresult = new ApiResultDTO();
            var Book = new Book
            {
                NombreLibro = entity.Nombres,
                ISBN = entity.ISBN,
                AutoresIdAutor = (int)entity.IdAutor,
                CategoriasIdCategoria = (int)entity.IdCategoria
            };

            this.bookStoreContext.Books.Add(Book);
            this.bookStoreContext.SaveChanges();
            Apiresult.Mensaje = Messages.RegistrosExitoso;
            return Apiresult;
        }


        public ApiResultDTO BusquedaBook(string libro, int autor, int categoria)
        {
            var Apiresult = new ApiResultDTO();
            var consultalibro = bookStoreContext.Books.Where(t => (categoria == 0 ? true : t.Categorias.IdCategoria == categoria)
            && (autor == 0 ? true : t.Autores.IdAutor == autor) && (String.IsNullOrEmpty(libro) ? true : t.NombreLibro == libro)).
                Select(t => new BooksDTO
                {
                    NombreLibro = t.NombreLibro,
                    ISBN = t.ISBN,
                    Autor = t.Autores.Nombre + " " + t.Autores.Apellidos,
                    Categoria = t.Categorias.Nombre,
                    IdLibro = t.IdLibro,
                    IdCategoria = t.CategoriasIdCategoria,
                    IdAutor = t.AutoresIdAutor

                }).ToList();
            Apiresult.Resultado = consultalibro;
            return Apiresult;
        }


        public ApiResultDTO Editar(int id, LibraryDTO entity)
        {
            var Apiresult = new ApiResultDTO();
            var Book = bookStoreContext.Books.FirstOrDefault(t => t.IdLibro == id);
            if (Book != null)
            {
                Book.NombreLibro = entity.Nombres;
                Book.ISBN = entity.ISBN;
                Book.CategoriasIdCategoria = (int)entity.IdCategoria;
                Book.AutoresIdAutor = (int)entity.IdAutor;
                Apiresult.Mensaje = Messages.EdicionExitosa;
                bookStoreContext.SaveChanges();
            }
            else
            {
                Apiresult.Mensaje = Messages.NoExisteId;
            }
            return Apiresult;
        }

        public ApiResultDTO Eliminar(int id)
        {
            var Apiresult = new ApiResultDTO();
            var editarAutor = bookStoreContext.Books.AsNoTracking().FirstOrDefault(t => t.IdLibro == id);
            if (editarAutor != null)
            {
                bookStoreContext.Books.Remove(new Book { IdLibro = id });
                bookStoreContext.SaveChanges();
                Apiresult.Mensaje = Messages.EliminacionExitosa;
            }
            else
            {
                Apiresult.Mensaje = Messages.NoExisteId;
            }
            return Apiresult;
        }

        public ApiResultDTO Listado()
        {

            var Apiresult = new ApiResultDTO();
            var listBook = this.bookStoreContext.Books.Select(t => new BooksDTO
            {
                NombreLibro = t.NombreLibro,
                ISBN = t.ISBN,
                Autor = t.Autores.Nombre + " " + t.Autores.Apellidos,
                Categoria = t.Categorias.Nombre,
                IdLibro = t.IdLibro,
                IdCategoria = t.CategoriasIdCategoria,
                IdAutor = t.AutoresIdAutor

            }).ToList();

            Apiresult.Mensaje = Utilidades.MensajesResult(listBook);
            Apiresult.Resultado = listBook;
            return Apiresult;
        }
    }
}
