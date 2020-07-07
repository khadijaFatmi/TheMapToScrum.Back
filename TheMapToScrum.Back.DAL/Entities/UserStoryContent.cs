namespace TheMapToScrum.Back.DAL.Entities
{
    public class UserStoryContent : EntityBase
    {
        public int ProjetId { get; set; }
        public string Titre { get; set; }
        public string Name { get; set; }
        public string Version { get; set; }
        public string Role { get; set; }
        public string Function1 { get; set; }
        public string Function2 { get; set; }
        public string Notes { get; set; }
        public string Priority { get; set; }
        public int StoryPoints { get; set; }
        public bool EpicStory { get; set; }

        public Projet Projet { get; set; }
    }
}
