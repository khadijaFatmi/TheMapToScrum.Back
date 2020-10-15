using System;

namespace TheMapToScrum.Back.DTO
{
    public abstract class BaseEntityDTO
    {
        public int? Id { get; set; }

             
        //suppression logique ;-)
        public bool? IsDeleted { get; set; }
        public DateTime? DateCreation { get; set; }


        public DateTime? DateModification { get; set; }
    }
}
