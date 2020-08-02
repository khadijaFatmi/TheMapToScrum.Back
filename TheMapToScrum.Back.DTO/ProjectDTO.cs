namespace TheMapToScrum.Back.DTO
{
    public class ProjectDTO : BaseEntityDTO
    {
        public string Label { get; set; }
        public int? BusinessManagerId { get; set; }       

        public int? TeamId { get; set; }

        public int? DepartmentId { get; set; }

    }
}
