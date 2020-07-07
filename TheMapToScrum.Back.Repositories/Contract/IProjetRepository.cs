using System.Collections.Generic;
using TheMapToScrum.Back.DAL.Entities;

namespace TheMapToScrum.Back.Repositories.Contract
{
    public interface IProjetRepository 
    {
        Projet Get(int id);



        List<Projet> GetAll();

        List<Projet> GetAllActive();

        Projet Create(Projet objet);

        Projet Update(Projet objet);

        bool Delete(int Id);
    }
}
