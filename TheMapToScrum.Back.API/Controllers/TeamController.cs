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
    public class TeamController : Controller
    {
        private readonly ITeamLogic _logic;

        public TeamController(ITeamLogic logic) 
        {
            _logic = logic;
        }

        [HttpGet]
        [Produces(typeof(List<TeamDTO>))]
        public List<TeamDTO> Get() 
        {
            List<TeamDTO> retour = new List<TeamDTO>();
            retour = _logic.List();
            return retour;
        }
    }
}
