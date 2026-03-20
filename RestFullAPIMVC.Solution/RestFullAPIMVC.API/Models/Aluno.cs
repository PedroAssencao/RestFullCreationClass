using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace RestFullAPIMVC.API.Models
{
    [Table("Aluno")]
    public partial class Aluno
    {
        public Aluno()
        {
            Matriculas = new HashSet<Matricula>();
        }

        [Key]
        public int IdAluno { get; set; }
        [StringLength(150)]
        [Unicode(false)]
        public string Nome { get; set; } = null!;
        [StringLength(150)]
        [Unicode(false)]
        public string? Email { get; set; }
        [Column(TypeName = "date")]
        public DateTime? DataNascimento { get; set; }

        [InverseProperty("IdAlunoNavigation")]
        public virtual ICollection<Matricula> Matriculas { get; set; }
    }
}
