namespace R4_4_API.Models.EntityFramework
{
    public partial class Notation
    {
        public override bool Equals(object? obj)
        {
            return obj is Notation notation &&
                   Utl_id == notation.Utl_id &&
                   Flm_id == notation.Flm_id &&
                   note == notation.note &&
                   EqualityComparer<Film>.Default.Equals(FilmNotation, notation.FilmNotation) &&
                   EqualityComparer<Utilisateur>.Default.Equals(UtilisateurNotation, notation.UtilisateurNotation);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Utl_id, Flm_id, note, FilmNotation, UtilisateurNotation);
        }
    }
}
