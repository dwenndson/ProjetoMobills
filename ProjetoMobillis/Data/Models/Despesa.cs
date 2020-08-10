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
        [RegularExpression(@"^\d+\.\d{0,2}$")]
        [Range(0.01, 9999999999999999.99)]
        public decimal Valor { get; set; }
        public DateTime Data { get; set; }
        public Boolean Pago { get; set; }
    }
    


}
