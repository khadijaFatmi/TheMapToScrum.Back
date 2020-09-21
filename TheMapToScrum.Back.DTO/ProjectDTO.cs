namespace TheMapToScrum.Back.DTO
{
    public class ProjectDTO : BaseEntityDTO
    {
        public string Label { get; set; }

        public int? ProductOwnerId { get; set; }       
        public int? ScrumMasterId { get; set; }
        public int? TeamId { get; set; }
        public int? DepartmentId { get; set; }

        public DepartmentDTO Department { get; set; }
        public ScrumMasterDTO ScrumMaster { get; set; }
        public ProductOwnerDTO ProductOwner { get; set; }
        public TeamDTO Team { get; set; }

        public int ProjectStatus { get; set; }
        public string strProjectStatus { get; set; }
    }
}
