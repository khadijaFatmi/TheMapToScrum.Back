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


        // Statuscode 500 = erreur serveur
        // les exceptions seront loggees
        [HttpGet]
        [Produces(typeof(DepartmentDTO))]
        public ActionResult<List<DepartmentDTO>> Get()
        {
            List<DepartmentDTO> retour = new List<DepartmentDTO>();
            try 
            {
                retour = _logic.ListActive();
                return retour;
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            
            }
        }



        [HttpGet("{id}")]
        public ActionResult<DepartmentDTO> GetById(int id)
        {
            try
            {
                DepartmentDTO retour = new DepartmentDTO();

                retour = _logic.GetById(id);
                if(retour == null) 
                {
                    return StatusCode(404, "object not found");
                }
                return retour;
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
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
                catch (Exception ex)
                {
                    return StatusCode(500, ex);
                }
            }
            else
            {
                return BadRequest("Invalid DepartmentDTO ModelState: failed to POST ");
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
                catch (Exception ex)
                {
                    return StatusCode(500, ex);
                }
            }
            else
            {
                return BadRequest("Invalid DepartmentDTO ModelState: failed to PUT");
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
                    return StatusCode(500, ex); 
                }
            }
            else
            {
                return BadRequest("Invalid DepartmentDTO ModelState: failed to DELETE");
            }
        }

    }
}
