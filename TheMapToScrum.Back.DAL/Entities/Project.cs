using System.Collections.Generic;

namespace TheMapToScrum.Back.DAL.Entities
{
    public class Project : EntityBase
    {
        public string Name { get; set; }

        public int BusinessManagerId { get; set; }

        public BusinessManager Auteur { get; set; }
        public List<UserStoryContent> UserStories { get; set; }
    }
}
