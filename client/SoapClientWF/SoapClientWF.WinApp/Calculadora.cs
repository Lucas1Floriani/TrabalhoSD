using SoapClientWF.Dominio.Enums;
using SoapClientWF.Dominio.Features;
using SoapClientWF.WinApp.CalcService;
using System;
using System.Windows.Forms;

namespace SoapClientWF
{
    public partial class Calculadora : Form
    {
        OperacaoEnum operacao = OperacaoEnum.SemOperacao;
        string PrimeiroNumero = String.Empty;
        string SegundoNumero = String.Empty;
        string CalculoAtual = String.Empty;
        public Calculadora()
        {
            InitializeComponent();
        }

        private void btnCalc_Click(object sender, EventArgs e)
        {
            var contaValida = (PrimeiroNumero != string.Empty) && (SegundoNumero != string.Empty) && (operacao != OperacaoEnum.SemOperacao);
            if (contaValida)
            {
                var service = new CalculadoraServerClient();
                float num1 = float.Parse(PrimeiroNumero);
                float num2 = float.Parse(SegundoNumero);
                if (operacao == OperacaoEnum.Soma)
                    ExecSoma(service, num1, num2);
                else if (operacao == OperacaoEnum.Subtracao)
                    ExecSubtracao(service, num1, num2);
                else if (operacao == OperacaoEnum.Multiplicacao)
                    ExecMultiplicacao(service, num1, num2);
                else if (operacao == OperacaoEnum.Divisao)
                    ExecDivisao(service, num1, num2);
                AtualizarLabelContaAtual();
            }
            else            
                MessageBox.Show("Você ainda não montou uma conta valida");            
        }

        private void ExecDivisao(CalculadoraServerClient service, float num1, float num2)
        {
            var result = service.divisao(num1, num2);
            var calc = new Calculo(num1, num2, operacao, result);
            listBox1.Items.Add(calc.ToString());
            LimparCalculo();
        }

        private void ExecMultiplicacao(CalculadoraServerClient service, float num1, float num2)
        {
            var result = service.multiplicacao(num1, num2);
            var calc = new Calculo(num1, num2, operacao, result);
            listBox1.Items.Add(calc.ToString());
            LimparCalculo();
        }

        private void ExecSubtracao(CalculadoraServerClient service, float num1, float num2)
        {
            var result = service.subtracao(num1, num2);
            var calc = new Calculo(num1, num2, operacao, result);
            listBox1.Items.Add(calc.ToString());
            LimparCalculo();
        }

        private void ExecSoma(CalculadoraServerClient service, float num1, float num2)
        {
            var result = service.soma(num1, num2);
            var calc = new Calculo(num1, num2, operacao, result);
            listBox1.Items.Add(calc.ToString());
            LimparCalculo();
        }
        private void AtualizarLabelContaAtual()
        {
            if (PrimeiroNumero == String.Empty && SegundoNumero == String.Empty)
                labResult.Text = "00";
            if (PrimeiroNumero != String.Empty && operacao == OperacaoEnum.SemOperacao)
                labResult.Text = String.Format("{0}", PrimeiroNumero);
            if(PrimeiroNumero != String.Empty && operacao != OperacaoEnum.SemOperacao && SegundoNumero == String.Empty)
                labResult.Text = string.Format("{0} {1}", PrimeiroNumero, GetOperacao());
            if(PrimeiroNumero != String.Empty && SegundoNumero != String.Empty)
                labResult.Text = string.Format("{0} {1} {2} = ?", PrimeiroNumero, GetOperacao(), SegundoNumero);
        }

        private string GetOperacao()
        {
            if (this.operacao == OperacaoEnum.Soma)
                return "+";
            if (this.operacao == OperacaoEnum.Subtracao)
                return "-";
            if (this.operacao == OperacaoEnum.Divisao)
                return "/";
            if (this.operacao == OperacaoEnum.Multiplicacao)
                return "X";

            return "";
        }
        private void LimparCalculo()
        {
            operacao = OperacaoEnum.SemOperacao;
            PrimeiroNumero = String.Empty;
            SegundoNumero = String.Empty;
            labResult.Text = String.Empty;
        }
        private void btnActionClear_Click(object sender, EventArgs e)
        {
            LimparCalculo();
            AtualizarLabelContaAtual();
        }

        private void btnNum1_Click(object sender, EventArgs e)
        {
            AtualizarNumeros(btnNum1);
        }

        private void AtualizarNumeros(Button btn)
        {
            if (operacao == OperacaoEnum.SemOperacao)
                PrimeiroNumero += btn.Text;
            else
                SegundoNumero += btn.Text;

            AtualizarLabelContaAtual();
        }

        private void btnNum2_Click(object sender, EventArgs e)
        {
            AtualizarNumeros(btnNum2);
        }

        private void btnNum3_Click(object sender, EventArgs e)
        {
            AtualizarNumeros(btnNum3);
        }

        private void btnNum4_Click(object sender, EventArgs e)
        {
            AtualizarNumeros(btnNum4);
        }

        private void btnNum5_Click(object sender, EventArgs e)
        {
            AtualizarNumeros(btnNum5);
        }

        private void btnNum6_Click(object sender, EventArgs e)
        {
            AtualizarNumeros(btnNum6);
        }

        private void btnNum7_Click(object sender, EventArgs e)
        {
            AtualizarNumeros(btnNum7);
        }

        private void btnNum8_Click(object sender, EventArgs e)
        {
            AtualizarNumeros(btnNum8);
        }

        private void btnNum9_Click(object sender, EventArgs e)
        {
            AtualizarNumeros(btnNum9);
        }

        private void BtnCaracVirg_Click(object sender, EventArgs e)
        {
            AtualizarNumeros(BtnCaracVirg);
        }

        private void btnOpSoma_Click(object sender, EventArgs e)
        {
            if (PrimeiroNumero != string.Empty)
                this.operacao = OperacaoEnum.Soma;
            else
                MessageBox.Show("Você precisa informar um número primeiro");

            AtualizarLabelContaAtual();
        }

        private void btnOpMult_Click(object sender, EventArgs e)
        {
            if (PrimeiroNumero != string.Empty)
                this.operacao = OperacaoEnum.Multiplicacao;
            else
                MessageBox.Show("Você precisa informar um número primeiro");

            AtualizarLabelContaAtual();
        }

        private void btnOpDiv_Click(object sender, EventArgs e)
        {
            if (PrimeiroNumero != string.Empty)
                this.operacao = OperacaoEnum.Divisao;
            else
                MessageBox.Show("Você precisa informar um número primeiro");

            AtualizarLabelContaAtual();
        }

        private void BtnOpSub_Click(object sender, EventArgs e)
        {            
            if (PrimeiroNumero != string.Empty)
                this.operacao = OperacaoEnum.Subtracao;
            else
                MessageBox.Show("Você precisa informar um número primeiro");

            AtualizarLabelContaAtual();
        }
    }
}
