namespace TheMapToScrum.Back.DAL.Entities
{
    public class UserStory : EntityBase
    {
        public int ProjectId { get; set; }
        
        public string Label { get; set; }
        public string Version { get; set; }
        public string Role { get; set; }
        public string Function1 { get; set; }
        public string Function2 { get; set; }
        public string Notes { get; set; }
        public string Priority { get; set; }
        public int StoryPoints { get; set; }
        public bool EpicStory { get; set; }

        public Project Project { get; set; }
    }
}
