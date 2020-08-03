using System;
using System.Collections.Generic;
using System.Text;

namespace TheMapToScrum.Back.DAL.Entities
{
    public class TechnicalManager : EntityBase
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public List<Project> Projects { get; set; }
    }
}
