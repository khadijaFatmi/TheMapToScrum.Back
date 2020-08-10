using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using TheMapToScrum.Back.BLL.Interfaces;
using TheMapToScrum.Back.DTO;

namespace TheMapToScrum.Back.Controllers
{
    //[Authorize]    
    [Produces("application/json")]
    [EnableCors("CorsPolicy")]
    [Route("api/[controller]")]
    public class DepartmentController : Controller
    {
        private readonly IDepartmentLogic _logic;

        public DepartmentController(IDepartmentLogic logic)
        {
            _logic = logic;
        }

        

        [HttpGet]
        [Produces(typeof(DepartmentDTO))]
        public List<DepartmentDTO> Get()
        {
            List<DepartmentDTO> retour = new List<DepartmentDTO>();
            retour = _logic.ListActive();
            return retour;
        }



        [HttpGet("{id}")]
        public DepartmentDTO GetById(int id)
        {
            DepartmentDTO retour = new DepartmentDTO();
            retour = _logic.GetById(id);
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
        //modification d'entité avec fourniture de l'Id obligatoire
        public ActionResult<DepartmentDTO> Put([FromBody] DepartmentDTO objet)
        {
            if (ModelState.IsValid && objet.Id.HasValue)
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

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<bool> Delete(int? Id)
        {
            if (Id.HasValue)
            {
                try
                {
                    bool resultat = _logic.Delete((int)Id);
                    return resultat;
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
            else
            {
                return BadRequest("id invalide");
            }
        }

    }
}
