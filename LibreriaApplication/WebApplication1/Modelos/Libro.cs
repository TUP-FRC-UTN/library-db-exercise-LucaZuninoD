namespace Libreria.Modelos
{
    public class Libro
    {
        public int Id { get; set; }
        public int ISBN { get; set; }
        public string Titulo { get; set; }
        public DateTime FechaPublicacion { get; set; }

        public int? AutorId { get; set; }
        public Autor Autor { get; set; }

        public int? GeneroId { get; set; }
        public Genero Genero { get; set; }
    }
}
