using Microsoft.EntityFrameworkCore;
namespace R4_4_API.Models.EntityFramework
{
    public partial class Film
    {
        public override bool Equals(object? obj)
        {
            return obj is Film film &&
                   Id == film.Id &&
                   Titre == film.Titre &&
                   Resume == film.Resume &&
                   Datesortie == film.Datesortie &&
                   Duree == film.Duree &&
                   Genre == film.Genre &&
                   EqualityComparer<ICollection<Notation>>.Default.Equals(NotationFilm, film.NotationFilm);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Titre, Resume, Datesortie, Duree, Genre, NotationFilm);
        }
    }
}
