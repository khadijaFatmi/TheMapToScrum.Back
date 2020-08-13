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
    public class ProductOwnerController : Controller
    {
        //injections dependances
        private readonly IProductOwnerLogic _logic;

        public ProductOwnerController(IProductOwnerLogic logic)
        {
            _logic = logic;

        }

        [HttpGet]
        [Produces(typeof(List<ProductOwnerDTO>))]
        public List<ProductOwnerDTO> get()
        {
            List<ProductOwnerDTO> retour = new List<ProductOwnerDTO>();
            retour = _logic.ListActive();
            return retour;
        }

        [HttpGet("All")]
        [Produces(typeof(List<ProductOwnerDTO>))]
        public List<ProductOwnerDTO> getAll()
        {
            List<ProductOwnerDTO> retour = new List<ProductOwnerDTO>();
            retour = _logic.List();
            return retour;
        }

        [HttpGet("{id}")]
        public ProductOwnerDTO GetById(int id)
        {
            ProductOwnerDTO retour = new ProductOwnerDTO();
            retour = _logic.GetById(id);
            return retour;
        }


        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]

        public ActionResult<ProductOwnerDTO> Post([FromBody] ProductOwnerDTO objet)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    ProductOwnerDTO resultat = _logic.Create(objet);
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
        public ActionResult<ProductOwnerDTO> Put([FromBody] ProductOwnerDTO objet)
        {
            if (ModelState.IsValid && objet.Id.HasValue)
            {
                try
                {
                    ProductOwnerDTO resultat = _logic.Update(objet);
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

