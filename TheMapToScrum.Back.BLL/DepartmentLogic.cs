using System.Collections.Generic;
using TheMapToScrum.Back.BLL.Interfaces;
using TheMapToScrum.Back.BLL.Mapping;
using TheMapToScrum.Back.DAL.Entities;
using TheMapToScrum.Back.DTO;
using TheMapToScrum.Back.Repositories.Contract;

namespace TheMapToScrum.Back.BLL
{
    public class DepartmentLogic : IDepartmentLogic
    {
        private readonly IDepartmentRepository _repo;

        public DepartmentLogic(IDepartmentRepository repo)
        {
            _repo = repo;
        }

        public DepartmentDTO Create(DepartmentDTO objet)
        {
            Department entite = MapDepartment.MapToEntity(objet);
            Department resultat = _repo.Create(entite);
            return objet;
        }

        public DepartmentDTO Update(DepartmentDTO objet)
        {
            Department entite = MapDepartment.MapToEntity(objet);
            Department resultat = _repo.Update(entite);
            DepartmentDTO retour = MapDepartmentDTO.ToDto(resultat);
            return retour;
        }
        public List<DepartmentDTO> List()
        {
            List<DepartmentDTO> retour = new List<DepartmentDTO>();
            List<Department> liste = _repo.GetAll();
            retour = MapDepartmentDTO.ToDto(liste);
            return retour;

        }

        public List<DepartmentDTO> ListActive()
        {
            List<DepartmentDTO> retour = new List<DepartmentDTO>();
            List<Department> liste = _repo.GetAllActive();
            retour = MapDepartmentDTO.ToDto(liste);
            return retour;

        }

        public DepartmentDTO GetById(int Id)
        {
            DepartmentDTO retour = new DepartmentDTO();
            Department objet = _repo.Get(Id);
            retour = MapDepartmentDTO.ToDto(objet);
            return retour;
        }

        public bool Delete(int Id)
        {

            bool resultat = _repo.Delete(Id);
            return resultat;
        }
    }
}
