using SoapClientWF.Dominio.Enums;

namespace SoapClientWF.Dominio.Features
{
    public class Calculo
    {
        public float PrimeiroNumero { get; set; }
        public OperacaoEnum Operacao { get; set; }
        public float SegundoNumero { get; set; }
        public float Resultado { get; set; }
        public Calculo(float num1, float num2, OperacaoEnum operacao, float result)
        {
            PrimeiroNumero = num1;
            SegundoNumero = num2;
            Operacao = operacao;
            Resultado = result;
        }
        public override string ToString()
        {
            return string.Format("{0}{1}{2} = {3}", PrimeiroNumero, GetOperacao(), SegundoNumero, Resultado);
        }

        private string GetOperacao()
        {
            if (this.Operacao == OperacaoEnum.Soma)
                return "+";
            if (this.Operacao == OperacaoEnum.Subtracao)
                return "-";
            if (this.Operacao == OperacaoEnum.Divisao)
                return "/";
            if (this.Operacao == OperacaoEnum.Multiplicacao)
                return "X";

            return "";
        }
    }
}
