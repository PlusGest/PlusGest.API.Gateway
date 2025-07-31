using PlusGest.Domain.Entities.Enums.Simulador;

namespace PlusGest.Domain.DTOs.Simulador
{
    public class SimuladorDTO
    {
        #region Propriedades
        public Guid SimuladorId { get; set; }
        public Guid UsuarioId { get; set; }
        public EnumSimuladorTipo Tipo { get; set; }
        public EnumSimuladorStatus Status { get; set; }
        public DateTime DataAtentimento { get; set; }
        public DateTime DataExpriracao { get; set; }
        public bool DadosAnonimizados { get; set; } = false;
        public EnumSimuladorMidia Midia { get; set; }
        public DateTime DataCriacao { get; set; } 
        #endregion
    }
}