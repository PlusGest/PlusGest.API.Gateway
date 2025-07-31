using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlusGest.Domain.Entities.Simulador.SimuladorCliente
{
    public class SimuladorClienteEntity
    {
        #region Propriedades
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid SimuladorClienteId { get; set; }

        [Required]
        public Guid SimuladorId { get; set; }

        [Required]
        [StringLength(200)]
        public string NomeCompleto { get; set; } = string.Empty;

        [Required]
        [StringLength(14)]
        public string Telefone { get; set; } = string.Empty;
        #endregion
    }
}