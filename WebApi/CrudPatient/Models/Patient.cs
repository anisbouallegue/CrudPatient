using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CrudPatient.Models
{
    public class Patient
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Column(TypeName ="nvarchar(100)")]
        public string Nom { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string Prenom { get; set; }
        [Required]
        [Column(TypeName = "varchar(8)")]
        public int NumTel { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string Address { get; set; }
        [Required]
        [Column(TypeName = "date")]
        [DataType(DataType.Date)]
        public DateTime BirthDay { get; set; }
        [Required]
        [Column(TypeName = "bit")]
        [DefaultValue(false)]
        public bool IsActive { get; set; }

    }
}
