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
        [Column(TypeName = "decimal(21,2)")]
        [NotNull]
        public decimal Valor { get; set; }
        public DateTime Data { get; set; }
        public Boolean Pago { get; set; }
    }
    


}
