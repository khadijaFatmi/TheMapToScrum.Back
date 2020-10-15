using System;
using System.Collections.Generic;
using TheMapToScrum.Back.DTO;
using TheMapToScrum.Back.BLL.Interfaces;
using TheMapToScrum.Back.BLL.Mapping;
using TheMapToScrum.Back.DAL.Entities;
using TheMapToScrum.Back.Repositories.Contract;

namespace TheMapToScrum.Back.BLL
{
  public class TaaskLogic : ITaaskLogic
  {
    private readonly ITaaskRepository _repo;

    public TaaskLogic(ITaaskRepository repo)
    {
      _repo = repo;
    }

    // transmission du DTO (front) passé en arg, doit correspondre au model DTO (back)
    // Nouvel Obj est ensuite mappé pour la création
    // retour = mappé DTO pour le front sans obliger le client Angular à requêter une nelle liste/objet etc
    public TaaskDTO Create(TaaskDTO entity)
    {
      // int numero = _repo.GetNextNumber(entity.ProjectId, null); ;

      int numero = 0;
      if (entity.UserStoryId.HasValue)
      {

        numero = _repo.GetNextNumberByUsId((int)entity.UserStoryId);
      }
      else
      {
        numero = _repo.GetNextNumberByProjectId((int)entity.ProjectId);
      }

      Taask obj = MapTaask.ToEntity(entity, true);
      obj.Number = numero;
      Taask result = _repo.Create(obj);
      TaaskDTO retour = MapTaaskDTO.ToDto(result);
      return retour;
    }

    public TaaskDTO Update(TaaskDTO entity)
    {
      Taask obj = MapTaask.ToEntity(entity, false);
      Taask result = _repo.Update(obj);
      TaaskDTO retour = MapTaaskDTO.ToDto(result);
      return retour;
    }

    public bool Delete(int Id)
    {
      bool result = _repo.Delete(Id);
      return result;
    }

    public TaaskDTO GetById(int Id)
    {
      TaaskDTO result = new TaaskDTO();
      Taask obj = _repo.Get(Id);
      result = MapTaaskDTO.ToDto(obj);
      return result;
    }
    public List<TaaskDTO> List()
    {
      List<TaaskDTO> result = new List<TaaskDTO>();
      List<Taask> liste = _repo.GetAll();
      result = MapTaaskDTO.ToDto(liste);
      return result;
    }
    public List<TaaskDTO> ListActive()
    {
      List<TaaskDTO> result = new List<TaaskDTO>();
      List<Taask> liste = _repo.GetAllActive();
      result = MapTaaskDTO.ToDto(liste);
      return result;
    }

    public List<TaaskDTO> ListeByUsId(int id)
    {
      List<TaaskDTO> result = new List<TaaskDTO>();
      List<Taask> liste = _repo.GetByUsId(id);
      result = MapTaaskDTO.ToDto(liste);
      return result;

    }
    public List<TaaskDTO> ListeByProjectId(int id)
    {
      List<TaaskDTO> result = new List<TaaskDTO>();
      List<Taask> liste = _repo.GetByProjectId(id);
      result = MapTaaskDTO.ToDto(liste);
      return result;

    }
  }
}


