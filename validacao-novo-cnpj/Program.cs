using validacao_novo_cnpj;

class Program
{
    static void Main(string[] args)
    {
        string validacao1 = Validacao.IsNovoCnpj("13.638.767/0001-92") ? "válido" : "inválido";
        string validacao2 = Validacao.IsNovoCnpj("33.EMA.SAM/E007-81") ? "válido" : "inválido";
        string validacao3 = Validacao.IsNovoCnpj("04.KA2.B01/A001-49") ? "válido" : "inválido";


        Console.WriteLine($"O CNPJ 13.638.767/0001-92 é {validacao1}"); //CNPJ válido

        Console.WriteLine($"O CNPJ 33.EMA.SAM/E007-81 é {validacao2}"); //CNPJ válido

        Console.WriteLine($"O CNPJ 04.KA2.B01/A001-49 é {validacao3}"); //CNPJ inválido
    }
}