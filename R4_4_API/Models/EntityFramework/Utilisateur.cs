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
        [Column("utl_id")]
        public int Id { get; set; }

        [Column("utl_nom")]
        [StringLength(50)]
        public string? Nom { get; set; }

        [Column("utl_prenom")]
        [StringLength(50)]
        public string? Prenom { get; set; }

        [Column("utl_mobile", TypeName="char(10)")]
        public string? Mobile { get; set; }

        [Column("utl_mail")]        
        [StringLength(100)]        
        public string? Mail { get; set; }

        [Column("utl_pwd")]
        [StringLength(64)]
        public string? Pwd { get; set; }

        [Column("utl_rue")]
        [StringLength(200)]
        public string? Rue { get; set; }

        [Column("utl_cp", TypeName = "char(5)")]
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

        [Column("utl_datecreation")]
        public DateTime Datecreation { get; set; }

        [InverseProperty("UtilisateurNotation")]
        public virtual ICollection<Notation> NotationUtilisateur { get; } = new List<Notation>();
    }
}
