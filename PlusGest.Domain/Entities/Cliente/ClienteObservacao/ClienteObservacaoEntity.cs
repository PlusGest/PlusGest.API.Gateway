using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlusGest.Gateway.Domain.Entities.Cliente.ClienteObservacao
{
    public class ClienteObservacaoEntity
    {
        #region Propriedades
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ClienteObservacaoId { get; set; }

        [Required]
        public Guid ClienteId { get; set; }

        [Required]
        public string Obervacao { get; set; } = string.Empty;

        [NotMapped]
        public DateTime DataCadastro { get; set; }
        #endregion
    }
}