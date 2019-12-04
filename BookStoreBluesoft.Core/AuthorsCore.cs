using BookStoreBluesoft.Common;
using BookStoreBluesoft.Core.Util;
using BookStoreBluesoft.Entities;
using BookStoreBluesoft.Entities.DTOEntities;
using BookStoreBluesoft.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookStoreBluesoft.Core
{
    public class AuthorsCore
    {
        private readonly BookStoreContext bookStoreContext;
        public AuthorsCore(BookStoreContext _bookStoreContext)
        {
            this.bookStoreContext = _bookStoreContext;
        }


        public ApiResultDTO Adicionar(LibraryDTO entity)
        {
            var Apiresult = new ApiResultDTO();
            var Autores = new Author
            {
                Nombre = entity.Nombres,
                Apellidos = entity.Apellidos,
                FechaNacimiento = (DateTime)entity.FechaNacimiento
            };
            bookStoreContext.Authors.Add(Autores);
            bookStoreContext.SaveChanges();
            Apiresult.Mensaje = Messages.RegistrosExitoso;
            return Apiresult;
        }


        public ApiResultDTO Editar(int id, LibraryDTO entity)
        {
            var Apiresult = new ApiResultDTO();
            var editarAutor = bookStoreContext.Authors.FirstOrDefault(t => t.IdAutor == id);
            if (editarAutor != null)
            {
                editarAutor.Nombre = entity.Nombres;
                editarAutor.Apellidos = entity.Apellidos;
                editarAutor.FechaNacimiento = (DateTime)entity.FechaNacimiento;
                bookStoreContext.SaveChanges();
                Apiresult.Mensaje = Messages.EdicionExitosa;
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
            var editarAutor = bookStoreContext.Authors.AsNoTracking().FirstOrDefault(t => t.IdAutor == id);
            if (editarAutor != null)
            {
                bookStoreContext.Authors.Remove(new Author{ IdAutor = id });
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
            var listAutorresultado = this.bookStoreContext.Authors.Select(t => new Author
            {
                Apellidos = t.Apellidos,
                Nombre = t.Nombre,
                FechaNacimiento = t.FechaNacimiento,
                IdAutor = t.IdAutor
            }).ToList();

            Apiresult.Mensaje = Utilidades.MensajesResult(listAutorresultado);
            Apiresult.Resultado = listAutorresultado;
            return Apiresult;
        }
    }
}

