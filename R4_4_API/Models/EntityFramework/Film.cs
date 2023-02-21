using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Intrinsics.X86;

namespace R4_4_API.Models.EntityFramework
{
    [Table("film", Schema = "r41_4")]
    public partial class Film
    {
        [Key]
        [Column("flm_id")]
        public int Id { get; set; }

        [Column("flm_titre")]
        [StringLength(50)]
        public string Titre { get; set; } = null!;

        [Column("flm_resume")]
        public string? Resume { get; set; }

        [Column("flm_datesortie")]
        public DateTime? Datesortie { get; set; }

        [Column("flm_duree", TypeName = "numeric(3,0)")]
        public decimal? Duree{ get; set; }

        [Column("flm_genre")]
        [StringLength(30)]
        public string? Genre { get; set; }

        [InverseProperty("FilmNotation")]
        public virtual ICollection<Notation> NotationFilm { get; } = new List<Notation>();
    }
}
