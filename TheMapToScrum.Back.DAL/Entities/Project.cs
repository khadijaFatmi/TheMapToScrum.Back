using System.Collections.Generic;

namespace TheMapToScrum.Back.DAL.Entities
{
    public class Project : EntityBase
    {
        public string Label { get; set; }

        public int? ProductOwnerId { get; set; }

        public int? DepartmentId { get; set; }
        public int? ScrumMasterId { get; set; }

        public int? TeamId { get; set; }

        public ProductOwner ProductOwner { get; set; }


        public Department Department { get; set; }
        public ScrumMaster TechnicalManager { get; set; }

        public int ProjectStatus { get; set; }

        public Team Team { get; set; }
        public List<UserStory> UserStories { get; set; }
    }
}
