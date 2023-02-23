namespace R4_4_API.Models.EntityFramework
{
    public partial class Utilisateur
    {
        public override bool Equals(object? obj)
        {
            return obj is Utilisateur utilisateur &&
                   Id == utilisateur.Id &&
                   Nom == utilisateur.Nom &&
                   Prenom == utilisateur.Prenom &&
                   Mobile == utilisateur.Mobile &&
                   Mail == utilisateur.Mail &&
                   Pwd == utilisateur.Pwd &&
                   Rue == utilisateur.Rue &&
                   Cp == utilisateur.Cp &&
                   Ville == utilisateur.Ville &&
                   Pays == utilisateur.Pays &&
                   Latitude == utilisateur.Latitude &&
                   Longitude == utilisateur.Longitude &&
                   Datecreation == utilisateur.Datecreation &&
                   EqualityComparer<ICollection<Notation>?>.Default.Equals(NotationUtilisateur, utilisateur.NotationUtilisateur);
        }

        public override int GetHashCode()
        {
            HashCode hash = new HashCode();
            hash.Add(Id);
            hash.Add(Nom);
            hash.Add(Prenom);
            hash.Add(Mobile);
            hash.Add(Mail);
            hash.Add(Pwd);
            hash.Add(Rue);
            hash.Add(Cp);
            hash.Add(Ville);
            hash.Add(Pays);
            hash.Add(Latitude);
            hash.Add(Longitude);
            hash.Add(Datecreation);
            hash.Add(NotationUtilisateur);
            return hash.ToHashCode();
        }
    }
}
