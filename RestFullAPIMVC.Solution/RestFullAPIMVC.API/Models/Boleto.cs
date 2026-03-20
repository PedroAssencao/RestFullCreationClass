using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace RestFullAPIMVC.API.Models
{
    [Table("Boleto")]
    public partial class Boleto
    {
        [Key]
        public int IdBoleto { get; set; }
        public int IdMatricula { get; set; }
        [Column(TypeName = "decimal(10, 2)")]
        public decimal Valor { get; set; }
        [Column(TypeName = "date")]
        public DateTime DataVencimento { get; set; }
        [StringLength(50)]
        [Unicode(false)]
        public string? Status { get; set; }

        [ForeignKey("IdMatricula")]
        [InverseProperty("Boletos")]
        public virtual Matricula IdMatriculaNavigation { get; set; } = null!;
    }
}
