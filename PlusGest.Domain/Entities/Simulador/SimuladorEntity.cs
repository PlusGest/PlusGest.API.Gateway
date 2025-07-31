using PlusGest.Domain.Entities.Enums.Simulador;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlusGest.Domain.Entities.Simulador
{
    public class SimuladorEntity
    {
        #region Propriedades
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid SimuladorId { get; set; }

        [Required]
        public Guid UsuarioId { get; set; }

        [Required]
        public EnumSimuladorTipo Tipo { get; set; }

        [Required]
        public EnumSimuladorStatus Status { get; set; }

        [Required]
        public DateTime DataAtentimento { get; set; }

        [Required]
        public DateTime DataExpriracao { get; set; }

        [Required]
        public bool DadosAnonimizados { get; set; } = false;

        [Required]
        public EnumSimuladorMidia Midia { get; set; }

        public DateTime DataCriacao { get; set; }
        #endregion
    }
}