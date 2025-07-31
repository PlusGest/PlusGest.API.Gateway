namespace PlusGest.Domain.Entities.Enums.Usuario
{
    public enum EnumFuncaoUsuario
    {
        //Recepção
        RecepcaoAtendente = 10,
        RecepcaoSupervisor = 11,

        //Comercial
        ComercialAuxiliar = 20,
        ComercialOperador = 21,
        ComercialCoodernador = 22,
        ComercialBackOffice = 23,
        SupervisorComercial = 24,

        //Negociações
        NegociacoesAuxiliar = 30,
        NegociacoesOperador = 31,
        NegociacoesCoodernador = 32,
        NegociacoesBackOffice = 33,
        SupervisorNegociacoes = 34,

        // Auditoria
        AuditoriaAnalista = 40,
        AuditoriaCoordenador = 41,

        // RH
        RH_Assistente = 50,
        RH_Analista = 51,
        RH_Recrutador = 52,
        RH_Coordenador = 53,

        // Financeiro
        FinanceiroAssistente = 60,
        FinanceiroAnalista = 61,
        FinanceiroTesoureiro = 62,
        FinanceiroCoordenador = 63,

        // Marketing
        MarketingCriativo = 70,
        MarketingEstrategista = 71,
        MarketingSocialMedia = 72,
        MarketingCoordenador = 73,

        // Suporte
        SuporteTecnico = 80,
        Dev = 81,

        // Gerência
        GerenciaOperacoes = 90,

        // Diretoria
        DiretoriaGeral = 100,
    }
}