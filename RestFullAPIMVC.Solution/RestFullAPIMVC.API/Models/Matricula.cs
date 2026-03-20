using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace RestFullAPIMVC.API.Models
{
    [Table("Matricula")]
    public partial class Matricula
    {
        public Matricula()
        {
            Boletos = new HashSet<Boleto>();
        }

        [Key]
        public int IdMatricula { get; set; }
        public int IdAluno { get; set; }
        public int IdCurso { get; set; }
        [Column(TypeName = "date")]
        public DateTime DataMatricula { get; set; }
        [StringLength(50)]
        [Unicode(false)]
        public string? Status { get; set; }

        [ForeignKey("IdAluno")]
        [InverseProperty("Matriculas")]
        public virtual Aluno IdAlunoNavigation { get; set; } = null!;
        [ForeignKey("IdCurso")]
        [InverseProperty("Matriculas")]
        public virtual Curso IdCursoNavigation { get; set; } = null!;
        [InverseProperty("IdMatriculaNavigation")]
        public virtual ICollection<Boleto> Boletos { get; set; }
    }
}
