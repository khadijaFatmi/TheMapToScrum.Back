using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using TheMapToScrum.Back.BLL.Interfaces;
using TheMapToScrum.Back.DTO;

namespace UserStoryWebAPI2.Controllers
{

    //[Authorize]    
    [Produces("application/json")]
    [EnableCors("CorsPolicy")]
    [Route("api/[controller]")]
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
            retour = _logic.ListActive();
            return retour;
        }


        [HttpGet("{id}")]
        public DeveloperDTO GetById(int id)
        {
            DeveloperDTO retour = new DeveloperDTO();
            retour = _logic.GetById(id);
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
        //modification d'entité avec fourniture de l'Id obligatoire
        public ActionResult<DeveloperDTO> Put([FromBody] DeveloperDTO objet)
        {
            if (ModelState.IsValid && objet.Id.HasValue)
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
