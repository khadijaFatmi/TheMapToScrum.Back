using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TheMapToScrum.Back.DTO;
using TheMapToScrum.Back.BLL.Interfaces;
using System;
using Microsoft.AspNetCore.Cors;

namespace TheMapToScrum.Back.Controllers
{
    //[Authorize]    
    [Produces("application/json")]
    [EnableCors("CorsPolicy")]
    [Route("api/[controller]")]
    public class UserStoryController : Controller
    {
        //injection dep
        private readonly IUserStoryLogic _logic;

        public UserStoryController (IUserStoryLogic logic)
        {
            _logic = logic;
        }

        [HttpGet("{id}")]
        public UserStoryDTO GetById(int id)
        {
            UserStoryDTO retour = new UserStoryDTO();
            retour = _logic.GetById(id);
            return retour;
        }

        [HttpGet]
        [Produces(typeof(UserStoryDTO))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public List<UserStoryDTO> Get()
        {
            List<UserStoryDTO> retour = new List<UserStoryDTO>();
            retour = _logic.listActive();
            return retour;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]      
        public ActionResult<UserStoryDTO> Post([FromBody] UserStoryDTO objet)
        {
            if(ModelState.IsValid)
            {
                try
                {
                    UserStoryDTO resultat = _logic.Create(objet);
                    return resultat;
                }
                catch 
                {
                    return null;
                }
            }
            else
            {
                return BadRequest("UserStoryDTO invalide");
            }
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        //modification d'entité avec fourniture de l'Id obligatoire
        public ActionResult<UserStoryDTO> Put([FromBody] UserStoryDTO objet)
        {
            if (ModelState.IsValid && objet.Id.HasValue)
            {
                try
                {
                    UserStoryDTO resultat = _logic.Update(objet);
                    return resultat;
                }
                catch(Exception ex)
                {
                    return null;
                }
            }
            else
            {
                return BadRequest("UserStoryDTO invalide");
            }
        }

        //id in url
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
