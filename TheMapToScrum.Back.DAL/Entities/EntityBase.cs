using System;

namespace TheMapToScrum.Back.DAL.Entities
{
    public abstract class EntityBase
    {
        public int? Id { get; set; }
        
        //suppression logique
        public bool IsDeleted { get; set; }

        public DateTime DateModification { get; set; }

        public DateTime DateCreation { get; set; }


    }
}
