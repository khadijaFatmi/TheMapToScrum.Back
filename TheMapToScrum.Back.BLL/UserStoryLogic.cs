using System;
using System.Collections.Generic;
using TheMapToScrum.Back.DTO;
using TheMapToScrum.Back.BLL.Interfaces;
using TheMapToScrum.Back.BLL.Mapping;
using TheMapToScrum.Back.DAL.Entities;
using TheMapToScrum.Back.Repositories.Contract;

namespace TheMapToScrum.Back.BLL
{
  public class UserStoryLogic : IUserStoryLogic
  {
    private readonly IUserStoryRepository _repo;

    public UserStoryLogic(IUserStoryRepository repo)
    {
      _repo = repo;
    }

    public List<UserStoryDTO> getByProjectId(int id)
    {
      List<UserStoryDTO> retour = new List<UserStoryDTO>();
      List<UserStory> objet = _repo.getByProjectId(id);
      retour = MapUserStoryDTO.ToDto(objet);
      return retour;
    }


    public UserStoryDTO GetById(int Id)
    {
      UserStoryDTO retour = new UserStoryDTO();
      UserStory objet = _repo.Get(Id);
      retour = MapUserStoryDTO.ToDto(objet);
      return retour;

    }

    public List<UserStoryDTO> list()
    {
      List<UserStoryDTO> retour = new List<UserStoryDTO>();
      List<UserStory> liste = _repo.GetAll();
      retour = MapUserStoryDTO.ToDto(liste);
      return retour;
    }
    public List<UserStoryDTO> listActive()
    {
      List<UserStoryDTO> retour = new List<UserStoryDTO>();
      List<UserStory> liste = _repo.GetAllActive();
      retour = MapUserStoryDTO.ToDto(liste);
      return retour;
    }
    public UserStoryDTO Create(UserStoryDTO objet)
    {
      UserStory entite = MapUserStory.ToEntity(objet, true);
      UserStory resultat = _repo.Create(entite);

      objet = MapUserStoryDTO.ToDto(resultat);
      return objet;
    }

    public UserStoryDTO Update(UserStoryDTO objet)
    {
      UserStory entity = MapUserStory.ToEntity(objet, false);
      UserStory resultat = _repo.Update(entity);
      UserStoryDTO retour = MapUserStoryDTO.ToDto(resultat);
      return retour;
    }

    public bool Delete(int Id)
    {

      bool resultat = _repo.Delete(Id);
      return resultat;
    }


  }
}
