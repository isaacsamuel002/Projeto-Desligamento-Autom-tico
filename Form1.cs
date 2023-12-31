﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Novo_Desligamento_Automático
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string nome, matricula, curso, desligamento, informacoesDesligamentoDevolver, pagar, devolver, informacoes, simulacao, informacaoSimulacaoDevolver, detalhesParcelas, calculo, desligamentoDevolver, simulacaoDevolver, deducao;

            int numeroParcela, numeroParcelaPaga, chTotal, chMinistrada, proximaParcela, parcelaDeducao, chTrancada, novaChMinistrada;

            double valorParcela, valorParcelaPaga, valorCurso, valorCh, valorChMinistrada, multa, totalPago, valoraPagar, resultado, resultadoAbsoluto, parcelasGeradas, valorResidual, valorDeducao;

            nome = textBox12.Text;
            matricula = textBox13.Text;
            curso = textBox10.Text;
            numeroParcela = Convert.ToInt32(textBox1.Text);
            valorParcela = Convert.ToDouble(textBox2.Text);
            valorCurso = (Convert.ToDouble(textBox1.Text) * Convert.ToDouble(textBox2.Text));
            chTotal = Convert.ToInt32(textBox5.Text);
            valorCh = valorCurso / chTotal;
            chMinistrada = Convert.ToInt32(textBox6.Text);
            chTrancada = Convert.ToInt32(textBox14.Text);
            novaChMinistrada = chMinistrada - chTrancada;
            valorChMinistrada = valorCh * novaChMinistrada;
            multa = valorCurso * 0.02;
            valoraPagar = valorChMinistrada + multa;
            numeroParcelaPaga = Convert.ToInt32(textBox4.Text);
            valorParcelaPaga = Convert.ToDouble(textBox3.Text);
            totalPago = numeroParcelaPaga * valorParcelaPaga;
            resultado = valoraPagar - totalPago;
            resultadoAbsoluto = Math.Abs(resultado);
            DateTime dataSolicitacao = dateTimePicker2.Value;
            DateTime dataVencimento = dateTimePicker1.Value;
            proximaParcela = Convert.ToInt32(textBox7.Text);
            parcelasGeradas = resultado / valorParcela;      //valor quebrado que será transformado em int
            int iparcelaGerada = (int)parcelasGeradas;       //valor da quantidade de parcelas geradas SEM o residual
            valorResidual = resultado % valorParcela;        //valor referente ao residual
            parcelaDeducao = iparcelaGerada + proximaParcela;
            valorDeducao = valorParcela - valorResidual;
            detalhesParcelas = "";

            desligamento = ("Prezado(a) " + nome + ", \r\n\r\n" +

                "O desligamento referente ao curso " + curso + ", matrícula " + matricula + ", foi realizado conforme solicitado. Aguardamos retorno numa próxima oportunidade.\r\n\r\n" +

              "Conforme contrato de prestação de serviços, em casos de desligamento é cobrada a carga horária ministrada até a data de solicitação, " + dataSolicitacao.ToString("dd/MM/yyyy") + ", acrescido da multa de 2% sobre o valor total do curso."
                + "\r\n\r\n" +

                "Caso tenha assistido aulas após a data de solicitação, informamos que perderá a carga horária ministrada e possíveis aprovações.\r\n\r\n" +

                "O valor cobrado, se refere as aulas já ministradas até a data de solicitação do desligamento somados a multa, não tem relação com aulas futuras.\r\n\r\n" +

                "De acordo com o cálculo existe o valor de R$ " +resultado.ToString("N2")+ " para pagamento. \r\n\r\n" +

                "Sendo assim, você deverá efetuar o pagamento das parcelas mencionadas abaixo.\r\n\r\n");

            simulacao = ("Prezado(a) " + nome + ", \r\n\r\n" +

              "Conforme solicitado, segue a simulação do desligamento do curso " + curso + ", matrícula "+ matricula+ ". \r\n\r\n" +

                "Gentileza analisar a simulação do desligamento abaixo, considerando carga horária ministrada somada a multa." + "\r\n\r\n" +

              "Conforme contrato de prestação de serviços, em casos de desligamento é cobrada a carga horária ministrada até a data de solicitação, " +dataSolicitacao.ToString("dd/MM/yyyy") + ", acrescido da multa de 2% sobre o valor total do curso.\r\n\r\n" +

                "Caso tenha assistido aulas após a data de solicitação, informamos que perderá a carga horária ministrada e possíveis aprovações.\r\n\r\n" +

                "De acordo com o cálculo, existe o valor de R$ " + resultado.ToString("N2") +
                " para pagamento.\r\n\r\n" +

                "Sendo assim, você deverá efetuar o pagamento das parcelas mencionadas abaixo.\r\n\r\n");

            desligamentoDevolver = ("Prezado(a) " + nome + ", \r\n\r\n" +

                "O desligamento referente ao curso " + curso + ", matrícula " + matricula + ", foi realizado conforme solicitado. Aguardamos retorno numa próxima oportunidade.\r\n\r\n" +

              "Conforme contrato de prestação de serviços, em casos de desligamento é cobrada a carga horária ministrada até a data de solicitação, " + dataSolicitacao.ToString("dd/MM/yyyy") + ", acrescido da multa de 2% sobre o valor total do curso."
                + "\r\n\r\n" +

                "Caso tenha assistido aulas após a data de solicitação, informamos que perderá a carga horária ministrada e possíveis aprovações.\r\n\r\n");

            simulacaoDevolver = ("Prezado(a), " + nome + ", \r\n\r\n" +

                " Conforme solicitado, segue a simulação de desligamento do curso " + curso + ", matrícula " +matricula + ".\r\n\r\n" +

                "Gentileza analisar a simulação do desligamento abaixo, considerando carga horária ministrada somados à multa." + "\r\n\r\n"+

              "Conforme contrato de prestação de serviços, em casos de desligamento, é cobrada a carga horária ministrada até a data de solicitação, " + dataSolicitacao.ToString("dd/MM/yyyy") + ", acrescido da multa de 2% sobre o valor total do curso."
                + "\r\n\r\n" +

                "Caso tenha assistido aulas após a data de solicitação, informamos que perderá a carga horária ministrada e possíveis aprovações.\r\n\r\n");

            calculo = ("Condição de pagamento: " + numeroParcela + " x R$ " + valorParcela.ToString("N2") + "\r\n" +
                "Valor total do curso: R$ " + valorCurso.ToString("N2") + "\r\n" +
                "Carga horária total do curso: " + chTotal + "\r\n" +
                "Custo hora-aula do curso: R$ " + valorCh.ToString("N2") + "\r\n" +
                "Carga horária ministrada até a data de solicitação: " + novaChMinistrada + "\r\n" +
                "Carga horária das disciplinas trancadas / dispensadas: " +chTrancada+ "\r\n" +
                "Carga horária considerada: " + novaChMinistrada+ "\r\n" +
                "Valor da carga horária ministrada: R$ " + valorChMinistrada.ToString("N2") + "\r\n" +
                "Multa: R$ " + multa.ToString("N2") + "\r\n" +
                "Total: R$ " + valoraPagar.ToString("N2") + "\r\n" +
                "Valor pago: " + numeroParcelaPaga + " x R$ " + valorParcelaPaga.ToString("N2") + " = " +
                "R$ " + totalPago.ToString("N2") + "\r\n" +
                "\r\n");

            informacoesDesligamentoDevolver = ("Gentileza encaminhar as informações descrita abaixo para que possamos programar a devolução. \r\n" +
                "Nome do aluno:\r\n" +
                "CPF do aluno:\r\n" +
                "Nome do titular da conta:\r\n" +
                "CPF do titular da conta: CPF:\r\nNome do banco:\r\n" +
                "Número da conta corrente: (o dígito verificador deverá ser separado por hífen)\r\n" +
                "Número da agencia: (o dígito verificador deverá ser separado por hífen):\r\n" +
                "OBS: Esclarecemos que o depósito não poderá ser realizado em conta poupança ou salário.\r\n" +
                "Em caso de conta conjunta, deverá ser informado o nome do 1º Titular.\r\n\r\n" +
                "Informamos ainda que a solicitação da restituição será encaminhada ao setor responsável, gentileza aguardar aproximadamente 30 dias uteis para a devolução. \r\n" +
                "Assim que o deposito for programado informaremos a data.\r\n\r\n");

            informacaoSimulacaoDevolver = ("Após a confirmação do desligamento, gentileza encaminhar as informações descritas abaixo para que possamos programar a devolução. \r\n" +
                "Nome do aluno:\r\n" +
                "CPF do aluno:\r\n" +
                "Nome do titular da conta:\r\n" +
                "CPF do titular da conta: CPF:\r\nNome do banco:\r\n" +
                "Número da conta corrente: (o dígito verificador deverá ser separado por hífen)\r\n" +
                "Número da agencia: (o dígito verificador deverá ser separado por hífen):\r\n" +
                "OBS: Esclarecemos que o depósito não poderá ser realizado em conta poupança ou salário.\r\n" +
                "Em caso de conta conjunta, deverá ser informado o nome do 1º Titular.\r\n\r\n" +
                "Informamos ainda que a solicitação da restituição será encaminhada ao setor responsável, gentileza aguardar aproximadamente 30 dias uteis para a devolução. \r\n" +
                "Assim que o deposito for programado informaremos a data.\r\n\r\n");

            informacoes = ("Para emissão de boletos, gentileza acessar o SGA.\r\n" +
                "Acesse www.iec.pucminas.br. \r\n" +
                "Acesso restrito, opção Aluno, localizado no canto superior à sua direita.\r\n" +
                "Entre com o número de matricula e senha informado anteriormente.\r\n" +
                "No campo Origem, selecione a opção IEC e clique em entrar.\r\n" +
                "Clique no menu Financeiro, escolha 2ª via do boleto bancário ou negociação de parcelas.\r\n" +
                "Para solicitar a 2ª via e/ou negociar as parcelas, gentileza encaminhar e-mail para o atendimento financeiro pelo e-mail: (financeiroiec@pucminas.br)." + "\r\n\r\n");

            pagar = ("Valor a Pagar: R$ " + resultado.ToString("N2") + "\r\n"
                 + "\r\n");

            devolver = ("De acordo com o cálculo acima, existe um valor a devolver de  R$ " + resultadoAbsoluto.ToString("N2") + "\r\n\r\n");


            for (int i = proximaParcela; i <= iparcelaGerada + proximaParcela - 1; i++)
            {
                detalhesParcelas += $"Parcela {i} - Vencimento {dataVencimento:dd/MM/yyyy} - R$ {valorParcela:N2}\r\n";

                dataVencimento = dataVencimento.AddMonths(1);
            }
                
            if (valorResidual > 0)
            {
               detalhesParcelas += $"Parcela {iparcelaGerada + proximaParcela} - Vencimento {dataVencimento:dd/MM/yyyy} - R$ {valorResidual:N2} - Será solicitado o ajuste do boleto e estará disponível no SGA." +"\r\n\r\n";
            }

            deducao = ("Olá Cássia, tudo bem!?\r\n\r\n" +
              "Gentileza realizar a dedução da parcela conforme descrito abaixo: \r\n\r\n" +
              "Nome: " + nome + "\r\n" +
              "Matrícula: " + matricula + "\r\n" +
              "Curso: " + curso + "\r\n" +
              "Parcela: " + parcelaDeducao + " - Vencimento: " + dataVencimento.ToString("dd/MM/yyyy") + "\r\n" +
              "Valor da parcela: R$" + valorParcela.ToString("N2") + "\r\n" +
              "Valor da dedução: R$" + valorDeducao.ToString("N2") + "\r\n" +
              "Valor a pagar: R$" +valorResidual.ToString("N2") + "\r\n");

            if (radioButton1.Checked && resultado > 0)
            {
                textBox11.Text = (desligamento + detalhesParcelas+ calculo + pagar + informacoes + deducao);
            }

            else if (radioButton1.Checked && resultado < 0)
            {
                textBox11.Text = desligamentoDevolver + calculo + devolver + informacoesDesligamentoDevolver;
            }

            else if (!radioButton1.Checked && resultado > 0)
            {
                textBox11.Text = simulacao + detalhesParcelas + calculo + pagar +informacoes + deducao;
            }

            else if (!radioButton1.Checked && resultado < 0)
            {
                textBox11.Text = simulacaoDevolver + calculo + devolver + informacaoSimulacaoDevolver;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            LimparForm();
        }

        private void LimparForm()
        {
            foreach (Control controle in this.Controls)
            {
                if (controle is TextBox)
                {
                    ((TextBox)controle).Clear();
                }
            }
        }
    }
}
