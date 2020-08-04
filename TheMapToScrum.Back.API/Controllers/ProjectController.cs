using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TheMapToScrum.Back.BLL.Interfaces;
using TheMapToScrum.Back.DTO;

namespace TheMapToScrum.Back.Controllers
{
    //[Authorize]    
    [Produces("application/json")]
    [EnableCors("CorsPolicy")]
    [Route("api/[controller]")]
    public class ProjectController : Controller
    {
        //injections dependances
        private readonly IProjectLogic _logic;

        public ProjectController(IProjectLogic logic)
        {
            _logic = logic;

        }

        [HttpGet]
        [Produces(typeof(List<ProjectDTO>))]
        public List<ProjectDTO> get()
        {
            List<ProjectDTO> retour = new List<ProjectDTO>();
            retour = _logic.List();
            return retour;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]

        public ActionResult<ProjectDTO> Post([FromBody] ProjectDTO objet)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    ProjectDTO resultat = _logic.Create(objet);
                    return resultat;
                }
                catch
                {
                    return null;
                }
            }
            else
            {
                return BadRequest("ProjectDTO invalide");
            }
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status202Accepted)]

        public ActionResult<ProjectDTO> Put([FromBody] ProjectDTO objet)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    ProjectDTO resultat = _logic.Update(objet);
                    return resultat;
                }
                catch
                {
                    return null;
                }
            }
            else
            {
                return BadRequest("ProjectDTO invalide");
            }
        }

    }
}
