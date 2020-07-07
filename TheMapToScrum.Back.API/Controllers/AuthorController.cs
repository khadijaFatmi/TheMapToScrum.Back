using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TheMapToScrum.Back.BLL.Interfaces;
using TheMapToScrum.Back.DTO;

namespace TheMapToScrum.Back.Controllers
{

    [Route("api/[controller]")]
        [Produces("application/json")]
        [ApiController]
        public class AuthorController : Controller
        {
            //injections dependances
            private readonly IAuthorLogic _logic;

            public AuthorController(IAuthorLogic logic)
            {
                _logic = logic;

            }

            [HttpGet]
            [Produces(typeof(List<AuthorDTO>))]
            public List<AuthorDTO> get()
            {
                List<AuthorDTO> retour = new List<AuthorDTO>();
                retour = _logic.Liste();
                return retour;
            }


            [HttpPost]
            [ProducesResponseType(StatusCodes.Status201Created)]

            public ActionResult<AuthorDTO> Post([FromBody] AuthorDTO objet)
            {
                if (ModelState.IsValid)
                {
                    try
                    {
                        AuthorDTO resultat = _logic.Create(objet);
                        return resultat;
                    }
                    catch
                    {
                     return null;
                    }
                }
                else
                {
                    return BadRequest("AuthorDTO invalide");
                }
            }

            [HttpPut]
            [ProducesResponseType(StatusCodes.Status202Accepted)]

            public ActionResult<AuthorDTO> Put([FromBody] AuthorDTO objet)
            {
                if (ModelState.IsValid)
                {
                    try
                    {
                        AuthorDTO resultat = _logic.Update(objet);
                        return resultat;
                    }
                    catch
                    {
                        return null;
                    }
                }
                else
                {
                    return BadRequest("AuthorDTO invalide");
                }
            }

    }
}

