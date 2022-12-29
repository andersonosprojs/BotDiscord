using BotDiscord.Dominio.Validacao;

namespace BotDiscord.Dominio.Entidades
{
    public class DiaDominio: EntidadeBase
    {
        public DiaDominio(string descricao)
            => ValidaDominio(descricao);

        public DiaDominio(long id, string descricao)
        {
            ValidacaoDominio.When(id < 0, "Indentificador Inválido");
            Id = id;
            ValidaDominio(descricao);
        }

        public string Descricao { get; private set; }

        private void ValidaDominio(string descricao)
        {
            ValidacaoDominio.When(string.IsNullOrEmpty(descricao),
                "Descrição do dia é obrigatória");

            Descricao = descricao;
        }
    }
}
