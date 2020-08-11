using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace ProjetoMobills.Data.Models
{
    public class Despesa
    {
        [Key]
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Campo Necessário")]
        public string Descricao { get; set; }
        [Required(ErrorMessage = "Campo Necessário")]
        [Column(TypeName = "decimal(18,2)")]
        [NotNull]
        [Range(0.01, 9999999999999999.99)]
        public decimal Valor { get; set; }
        public DateTime Data { get; set; }
        [Required(ErrorMessage = "Campo Necessário")]
        public bool Pago { get; set; }
    }

}
