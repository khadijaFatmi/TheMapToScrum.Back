using System.Collections.Generic;

namespace TheMapToScrum.Back.DAL.Entities
{
    public class Projet : EntityBase
    {
        public string Name { get; set; }

        public int AuthorId { get; set; }

        public Author Auteur { get; set; }
        public List<UserStoryContent> UserStories { get; set; }
    }
}
