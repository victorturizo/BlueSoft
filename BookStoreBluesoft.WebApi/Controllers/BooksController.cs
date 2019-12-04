using System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStoreBluesoft.Core;
using BookStoreBluesoft.Entities.DTOEntities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreBluesoft.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class BooksController : ControllerBase
    {
        private readonly BooksCore _Library;

 
        public BooksController(BooksCore _Library)
        {
            this._Library = _Library;
        }


        [HttpGet]
        public ApiResultDTO Get()
        {
            return _Library.Listado();
        }

        [Route("GetParametros")]
        [HttpGet]
        public ApiResultDTO GetParametros(string libro, int? autor, int? categoria)
        {
            return _Library.BusquedaBook(libro, (int)autor, (int)categoria);
        }

        // POST: api/Books
        [HttpPost]
        public ApiResultDTO Post([FromBody] LibraryDTO entity)
        {
            return _Library.Adicionar(entity);
        }

        // PUT: api/Books/5
        [HttpPut("{id}")]
        public ApiResultDTO Put(int id, [FromBody] LibraryDTO entity)
        {
            return _Library.Editar(id, entity);
        }

        // DELETE: api/Books/5
        [HttpDelete("{id}")]
        public ApiResultDTO Delete(int id)
        {
            return _Library.Eliminar(id);
        }
    }
}
