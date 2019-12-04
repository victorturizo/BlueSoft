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
    public class CategoriesCore
    {
     
        private readonly BookStoreContext bookStoreContext;
        public CategoriesCore(BookStoreContext _bookStoreContext)
        {
            this.bookStoreContext = _bookStoreContext;
        }


        public ApiResultDTO Adicionar(LibraryDTO entity)
        {
            var Apiresult = new ApiResultDTO();
            var categoria = new Category { Nombre = entity.Nombres, Descripcion = entity.Descripcion };
            bookStoreContext.Categories.Add(categoria);
            bookStoreContext.SaveChanges();
            Apiresult.Mensaje = Messages.RegistrosExitoso;
            return Apiresult;

        }

        public ApiResultDTO Editar(int id, LibraryDTO entity)
        {
            var Apiresult = new ApiResultDTO();
            var editarcategoria = bookStoreContext.Categories.FirstOrDefault(t => t.IdCategoria == id);
            if (editarcategoria != null)
            {
                editarcategoria.Descripcion = entity.Descripcion;
                editarcategoria.Nombre = entity.Nombres;
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
            var editarcategoria = bookStoreContext.Categories.AsNoTracking().FirstOrDefault(t => t.IdCategoria == id);
            if (editarcategoria != null)
            {
                bookStoreContext.Categories.Remove(new Category{ IdCategoria = id });
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
            var listcategoriaresultado = this.bookStoreContext.Categories.Select(t => new CategoriesDTO
            {
                Descripcion = t.Descripcion,
                Nombre = t.Nombre,
                IdCategoria = t.IdCategoria
            }).ToList();

            Apiresult.Mensaje = Utilidades.MensajesResult(listcategoriaresultado);
            Apiresult.Resultado = listcategoriaresultado;
            return Apiresult;
        }
    }
}
