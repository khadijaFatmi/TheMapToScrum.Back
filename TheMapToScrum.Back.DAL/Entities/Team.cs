using System.Collections.Generic;

namespace TheMapToScrum.Back.DAL.Entities
{
    public class Team : EntityBase
    {
        public string Label { get; set; }

        public List<Developer> developers { get; set; }
    }
}
