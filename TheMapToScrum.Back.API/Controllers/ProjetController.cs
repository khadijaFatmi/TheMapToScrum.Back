using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TheMapToScrum.Back.BLL.Interfaces;
using TheMapToScrum.Back.DTO;

namespace TheMapToScrum.Back.Controllers
{
    //decorateurs
    //[EnableCors("CorsPolicy")]
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class ProjetController : Controller
    {
        //injections dependances
        private readonly IProjetLogic _logic;

        public ProjetController(IProjetLogic logic)
        {
            _logic = logic;
            
        }

        [HttpGet]
        [Produces(typeof(List<ProjetDTO>))]
        public List<ProjetDTO> get()
        {
            List<ProjetDTO> retour = new List<ProjetDTO>();
            retour = _logic.Liste();
            return retour;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]

        public ActionResult<ProjetDTO> Post([FromBody] ProjetDTO objet)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    ProjetDTO resultat = _logic.Create(objet);
                    return resultat;
                }
                catch
                {
                    return null;
                }
            }
            else
            {
                return BadRequest("ProjetDTO invalide");
            }
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status202Accepted)]

        public ActionResult<ProjetDTO> Put([FromBody] ProjetDTO objet)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    ProjetDTO resultat = _logic.Update(objet);
                    return resultat;
                }
                catch
                {
                    return null;
                }
            }
            else
            {
                return BadRequest("ProjetDTO invalide");
            }
        }

    }
}
