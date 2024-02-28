namespace Scarpe.Models
{
    public class Articolo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Prezzo { get; set; }
        public string Description { get; set; }
        public string ImgCover { get; set; }
        public List<string> ImgDetails { get; set; }
        public bool Deleted { get; set; }


    }
}
