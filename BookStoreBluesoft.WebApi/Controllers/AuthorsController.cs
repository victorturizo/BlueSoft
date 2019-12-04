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
    public class AuthorsController : ControllerBase
    {
        private readonly AuthorsCore _Library;

   
        public AuthorsController(AuthorsCore _Library)
        {
            this._Library = _Library;

        }

        // GET: api/Authors
        [HttpGet]
        public ApiResultDTO Get()
        {
            return _Library.Listado();
        }

        // POST: api/Authors
        [HttpPost]
        public ApiResultDTO Post([FromBody] LibraryDTO entity)
        {
            return _Library.Adicionar(entity);
        }

        // PUT: api/Authors/5
        [HttpPut("{id}")]
        public ApiResultDTO Put(int id, [FromBody] LibraryDTO entity)
        {
            return _Library.Editar(id, entity);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public ApiResultDTO Delete(int id)
        {
            return _Library.Eliminar(id);
        }
    }
}
