using System.ComponentModel.DataAnnotations;

namespace TheMapToScrum.Back.DTO
{
    public class UserStoryDTO : BaseEntityDTO
    {
        [Required]
        public int ProjectId { get; set; }
       
        [Required]
        public string Version { get; set; }

        [Required]
        public string Label { get; set; }
        public string Role { get; set; }
        public string Function1 { get; set; }
        public string Function2 { get; set; }
        public string Notes { get; set; }
        public string Priority { get; set; }
        [Required]
        public int StoryPoints { get; set; }
        [Required]
        public bool EpicStory { get; set; }

        [Required]
        public int usStatus { get; set; }

        public string strUsStatus { get; set; }
        public ProjectDTO Project { get; set; }

    }
}
