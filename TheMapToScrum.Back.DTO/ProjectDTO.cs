namespace TheMapToScrum.Back.DTO
{
    public class ProjectDTO : BaseEntityDTO
    {
        public string Name { get; set; }
        public int BusinessManagerId { get; set; }

        public string Auteur { get; set; }

        public string Equipe { get; set; }

        public string Department { get; set; }

    }
}
