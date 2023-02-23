using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Intrinsics.X86;
using Microsoft.EntityFrameworkCore;

namespace R4_4_API.Models.EntityFramework
{
    [Table("utilisateur", Schema = "r41_4")]
    public partial class Utilisateur
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("utl_id")]
        public int Id { get; set; }

        [Column("utl_nom")]
        [StringLength(50)]
        public string? Nom { get; set; }

        [Column("utl_prenom")]
        [StringLength(50)]
        public string? Prenom { get; set; }

        [Column("utl_mobile", TypeName="char(10)")]
        [Phone]
        [RegularExpression(@"^0[0-9]{9}$", ErrorMessage = "La longueur d’un téléphone doit être de 10 caractères.")]        
        public string? Mobile { get; set; }

        [Required]
        [Column("utl_mail")]
        [EmailAddress(ErrorMessage = "La longueur d’un email doit être comprise entre 6 et 100 caractères.")]
        public string? Mail { get; set; }

        [Column("utl_pwd")]
        [StringLength(64, MinimumLength = 12, ErrorMessage = "La longueur d’un email doit être comprise entre 6 et 100 caractères.")]

        [RegularExpression(@"^(?=.[A-Z])(?=.\d)(?=.*[^\w\s]).{12,20}$", ErrorMessage = "La longueur d’un téléphone doit être de 10 caractères.")]
        public string? Pwd { get; set; }

        [Column("utl_rue")]
        [StringLength(200)]
        public string? Rue { get; set; }

        [Column("utl_cp", TypeName = "char(5)")]
        [RegularExpression(@"^[0-9]{5}$", ErrorMessage = "Le code postal doit faire 5 carctere")]
        public string? Cp { get; set; }

        [Column("utl_ville")]
        [StringLength(50)]
        public string? Ville { get; set; }

        [Column("utl_pays")]
        [StringLength(50)]
        public string? Pays { get; set; }

        [Column("utl_latitude")]        
        public float? Latitude { get; set; }

        [Column("utl_longitude")]
        public float? Longitude { get; set; }

        [Column("utl_datecreation", TypeName = "date")]
        public DateTime? Datecreation { get; set; }

        [InverseProperty("UtilisateurNotation")]
        public virtual ICollection<Notation>? NotationUtilisateur { get; set; } = new List<Notation>();
        
    }
}
