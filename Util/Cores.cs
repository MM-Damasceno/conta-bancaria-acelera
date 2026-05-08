namespace ContaBancaria.Util
{

    // definir cores de fundo // nao testada  // utilizando ASCI codes - determina cores para o terminal 
    public static class Cores
    {
        public const string Reset   = "\033[0m";
        public const string Preto   = "\033[30m";
        public const string Vermelho= "\033[31m";
        public const string Verde   = "\033[32m";
        public const string Amarelo = "\033[33m";
        public const string Azul    = "\033[34m";
        public const string Magenta = "\033[35m";
        public const string Ciano   = "\033[36m";
        public const string Branco  = "\033[37m";

        // Fundos
        public const string FundoAzul    = "\033[44m";
        public const string FundoVerde   = "\033[42m";
        public const string FundoVermelho= "\033[41m";

        public static void Titulo(string texto)
        {
            Console.WriteLine($"\n{Ciano}*****************************************************");
            Console.WriteLine($"  {texto}");
            Console.WriteLine($"*****************************************************{Reset}\n");
        }

        public static void Erro(string mensagem)
            => Console.WriteLine($"\n{Vermelho}Erro: {mensagem}{Reset}");

        public static void Sucesso(string mensagem)
            => Console.WriteLine($"\n{Verde}{mensagem}{Reset}");
    }
}
