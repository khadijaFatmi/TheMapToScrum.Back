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
    public class BusinessManagerController : Controller
    {
        //injections dependances
        private readonly IBusinessManagerLogic _logic;

        public BusinessManagerController(IBusinessManagerLogic logic)
        {
            _logic = logic;

        }

        [HttpGet]
        [Produces(typeof(List<BusinessManagerDTO>))]
        public List<BusinessManagerDTO> get()
        {
            List<BusinessManagerDTO> retour = new List<BusinessManagerDTO>();
            retour = _logic.ListActive();
            return retour;
        }

        [HttpGet("All")]
        [Produces(typeof(List<BusinessManagerDTO>))]
        public List<BusinessManagerDTO> getAll()
        {
            List<BusinessManagerDTO> retour = new List<BusinessManagerDTO>();
            retour = _logic.List();
            return retour;
        }

        [HttpGet("{id}")]
        public BusinessManagerDTO GetById(int id)
        {
            BusinessManagerDTO retour = new BusinessManagerDTO();
            retour = _logic.GetById(id);
            return retour;
        }


        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]

        public ActionResult<BusinessManagerDTO> Post([FromBody] BusinessManagerDTO objet)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    BusinessManagerDTO resultat = _logic.Create(objet);
                    return resultat;
                }
                catch
                {
                    return null;
                }
            }
            else
            {
                return BadRequest("BusinessManagerDTO invalide");
            }
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        //modification d'entité avec fourniture de l'Id obligatoire
        public ActionResult<BusinessManagerDTO> Put([FromBody] BusinessManagerDTO objet)
        {
            if (ModelState.IsValid && objet.Id.HasValue)
            {
                try
                {
                    BusinessManagerDTO resultat = _logic.Update(objet);
                    return resultat;
                }
                catch
                {
                    return null;
                }
            }
            else
            {
                return BadRequest("BusinessManagerDTO invalide");
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

