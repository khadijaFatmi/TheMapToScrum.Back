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

    public class PoleController : Controller
    {
        private readonly IPoleLogic _logic;

        public PoleController(IPoleLogic logic)
        {
            _logic = logic;
        }

        [HttpGet]
        [Produces(typeof(List<PoleDTO>))]
        public List<PoleDTO> get()
        {
            List<PoleDTO> retour = new List<PoleDTO>();
            retour = _logic.Liste();
            return retour;
        }

        [HttpGet]
        [Produces(typeof(PoleDTO))]
        public List<PoleDTO> Get()
        {
            List<PoleDTO> retour = new List<PoleDTO>();
            retour = _logic.Liste();
            return retour;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]

        public ActionResult<PoleDTO> Post([FromBody] PoleDTO objet)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    PoleDTO resultat = _logic.Create(objet);
                    return resultat;
                }
                catch
                {
                    return null;
                }
            }
            else
            {
                return BadRequest("UserStoryContentDTO invalide");
            }
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status202Accepted)]

        public ActionResult<PoleDTO> Put([FromBody] PoleDTO objet)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    PoleDTO resultat = _logic.Update(objet);
                    return resultat;
                }
                catch
                {
                    return null;
                }
            }
            else
            {
                return BadRequest("PoleDTO invalide");
            }
        }



    }
}
