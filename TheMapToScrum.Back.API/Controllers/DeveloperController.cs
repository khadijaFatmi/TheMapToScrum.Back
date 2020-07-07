using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TheMapToScrum.Back.BLL.Interfaces;
using TheMapToScrum.Back.DTO;

namespace UserStoryWebAPI2.Controllers
{

    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]


    public class DeveloperController : Controller
    {
        private readonly IDeveloperLogic _logic;

        public DeveloperController(IDeveloperLogic logic)
        {
            _logic = logic;
        }


        [HttpGet]
        [Produces(typeof(List<DeveloperDTO>))]
        public List<DeveloperDTO> get()
        {
            List<DeveloperDTO> retour = new List<DeveloperDTO>();
            retour = _logic.Liste();
            return retour;
        }


        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]

        public ActionResult<DeveloperDTO> Post([FromBody] DeveloperDTO objet)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    DeveloperDTO resultat = _logic.Create(objet);
                    return resultat;
                }
                catch
                {
                    return null;
                }
            }
            else
            {
                return BadRequest("DeveloperDTO invalide");
            }
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status202Accepted)]

        public ActionResult<DeveloperDTO> Put([FromBody] DeveloperDTO objet)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    DeveloperDTO resultat = _logic.Update(objet);
                    return resultat;
                }
                catch
                {
                    return null;
                }
            }
            else
            {
                return BadRequest("DeveloperDTO invalide");
            }
        }




    }
}
