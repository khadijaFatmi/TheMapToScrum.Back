using System.Collections.Generic;

namespace TheMapToScrum.Back.DAL.Entities
{
    public class Project : EntityBase
    {
        public string Label { get; set; }

        public int? BusinessManagerId { get; set; }

        public int? DepartmentId { get; set; }

        public BusinessManager BusinessManager { get; set; }

        public Department Department { get; set; }
        public List<UserStoryContent> UserStories { get; set; }
    }
}
