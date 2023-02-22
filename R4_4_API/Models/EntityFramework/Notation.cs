using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace R4_4_API.Models.EntityFramework
{
    [Table("notation", Schema = "r41_4")]
    public partial class Notation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("utl_id")]
        public int Utl_id { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("flm_id")]
        public int Flm_id { get; set; }

        [Column("not_note")]
        public int note { get; set; }


        [InverseProperty("NotationFilm")]
        public virtual Film FilmNotation { get; set; } = null!;

        [InverseProperty("NotationUtilisateur")]
        public virtual Utilisateur UtilisateurNotation { get; set; } = null!;

    }
}


