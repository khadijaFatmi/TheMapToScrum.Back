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

    public class DepartmentController : Controller
    {
        private readonly IDepartmentLogic _logic;

        public DepartmentController(IDepartmentLogic logic)
        {
            _logic = logic;
        }

        [HttpGet]
        [Produces(typeof(List<DepartmentDTO>))]
        public List<DepartmentDTO> get()
        {
            List<DepartmentDTO> retour = new List<DepartmentDTO>();
            retour = _logic.List();
            return retour;
        }

        [HttpGet]
        [Produces(typeof(DepartmentDTO))]
        public List<DepartmentDTO> Get()
        {
            List<DepartmentDTO> retour = new List<DepartmentDTO>();
            retour = _logic.List();
            return retour;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]

        public ActionResult<DepartmentDTO> Post([FromBody] DepartmentDTO objet)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    DepartmentDTO resultat = _logic.Create(objet);
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

        public ActionResult<DepartmentDTO> Put([FromBody] DepartmentDTO objet)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    DepartmentDTO resultat = _logic.Update(objet);
                    return resultat;
                }
                catch
                {
                    return null;
                }
            }
            else
            {
                return BadRequest("DepartmentDTO invalide");
            }
        }



    }
}
