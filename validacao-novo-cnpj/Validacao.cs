namespace validacao_novo_cnpj
{
    /// <summary>
    /// Classe utilizada para validações
    /// </summary>
    public static class Validacao
    {
        /// <summary>
        /// Valida um CNPJ conforme novo formato alfanumérico que entrará em vigor em 2026 pela Receita Federal
        /// </summary>
        /// <param name="cnpj"></param>
        /// <returns></returns>
        public static bool IsNovoCnpj(string cnpj)
        {
            //Deixa somente as posições do CNPJ sem barras, pontos, etc
            cnpj =  !string.IsNullOrEmpty(cnpj) 
                    ? cnpj.Trim().ToUpper().Replace(".", "").Replace("-", "").Replace("/", "").Replace("\\", "") 
                    : "";

            if (cnpj.Length != 14)
            {
                return false;
            }

            //Multiplicadores padrão para os dígitos verificadores
            int[] multipDV1 = { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multipDV2 = { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };

            //Pega as posições que serão utilizadas no cálculo dos dígitos verificadores
            string calcDV1 = cnpj.Substring(0, 12);
            string calcDV2 = cnpj.Substring(0, 13);

            int soma = 0;
            int resto = 0;

            //Calculando o primeiro dígito verificador
            for (int i = 0; i < multipDV1.Length; i++)
            {
                soma += (Convert.ToInt32(calcDV1[i]) - 48) * multipDV1[i];
            }

            resto = (soma % 11);

            string digito1 = (resto <= 1 ? 0 : 11 - resto).ToString();

            soma = 0;

            //Calculando o segundo dígito verificador
            for (int i = 0; i < multipDV2.Length; i++)
            {
                soma += (Convert.ToInt32(calcDV2[i]) - 48) * multipDV2[i];
            }

            resto = (soma % 11);

            string digito2 = (resto <= 1 ? 0 : 11 - resto).ToString();

            return cnpj.Equals($"{calcDV1}{digito1}{digito2}");
        }
    }
}