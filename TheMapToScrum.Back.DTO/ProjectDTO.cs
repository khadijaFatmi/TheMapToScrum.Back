namespace TheMapToScrum.Back.DTO
{
    public class ProjectDTO : BaseEntityDTO
    {
        public string Label { get; set; }

        public int? BusinessManagerId { get; set; }       
        public int? TechnicalManagerId { get; set; }
        public int? TeamId { get; set; }
        public int? DepartmentId { get; set; }

        public DepartmentDTO Department { get; set; }
        public TechnicalManagerDTO TechnicalManager { get; set; }
        public BusinessManagerDTO BusinessManager { get; set; }
        public TeamDTO Team { get; set; }
        public DeveloperDTO Developer { get; set; }

    }
}
