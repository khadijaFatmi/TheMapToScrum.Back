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
    public class TechnicalManagerController : Controller
    {
        private readonly ITechnicalManagerLogic _logic;

        public TechnicalManagerController(ITechnicalManagerLogic logic) 
        {
            _logic = logic;
        }

        [HttpGet]
        [Produces(typeof(List<TechnicalManagerDTO>))]
        public List<TechnicalManagerDTO> Get()
        {
            List<TechnicalManagerDTO> retour = new List<TechnicalManagerDTO>();
            retour = _logic.List();
            return retour;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public ActionResult<TechnicalManagerDTO> Post([FromBody] TechnicalManagerDTO objet)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    TechnicalManagerDTO resultat = _logic.Create(objet);
                    return resultat;
                }
                catch 
                {
                    return null;
                }
            }
            else 
            {
                return BadRequest("TechnicalManagerDTO invalide, Is the model Valid???");
            }
        }
    }
}
