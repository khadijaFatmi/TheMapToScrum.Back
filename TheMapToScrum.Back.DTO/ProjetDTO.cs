namespace TheMapToScrum.Back.DTO
{
    public class ProjetDTO : BaseEntityDTO
    {
        public string Name { get; set; }
        public int AuthorId { get; set; }

        public string Auteur { get; set; }

        public string Equipe { get; set; }

        public string Pole { get; set; }

    }
}
