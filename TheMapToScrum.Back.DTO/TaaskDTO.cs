namespace TheMapToScrum.Back.DTO
{
    public class TaaskDTO : BaseEntityDTO
    {
        public string Label { get; set; }
        public int? Number { get; set; }
        public string Feature { get; set; }
        public int? EstimatedDuration { get; set; }

        public string Assumption { get; set; }
        public string AcceptanceCriteria { get; set; }
        public string Risk { get; set; }
        public int TaskStatus { get; set; }
        public string strTaskStatus { get; set; }
        public int StatusColor { get; set; }
        public string strStatusColor { get; set; }
        public int Priority { get; set; }
        public string strPriority { get; set; }
        public int PriorityColor { get; set; }
        public string strPriorityColor { get; set; }       
        public int ProjectId { get; set; }
        public int DeveloperId { get; set; }
        public int? UserStoryId { get; set; }
        public DeveloperDTO Developer { get; set; }
        public ProjectDTO Project { get; set; }
        public UserStoryDTO UserStory { get; set; }
        public string USLabel { get; set; }
    }
}
