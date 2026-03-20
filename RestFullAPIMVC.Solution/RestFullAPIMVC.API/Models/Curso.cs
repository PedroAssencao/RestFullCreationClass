using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace RestFullAPIMVC.API.Models
{
    [Table("Curso")]
    public partial class Curso
    {
        public Curso()
        {
            Matriculas = new HashSet<Matricula>();
        }

        [Key]
        public int IdCurso { get; set; }
        [StringLength(100)]
        [Unicode(false)]
        public string Nome { get; set; } = null!;
        public int DuracaoSemestres { get; set; }

        [InverseProperty("IdCursoNavigation")]
        public virtual ICollection<Matricula> Matriculas { get; set; }
    }
}
