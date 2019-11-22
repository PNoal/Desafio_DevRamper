using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DevRamper_Resposta
{
    public partial class FrmLivraria : Form
    {
        int[] hp_vl = new int[7];
        int volumes_diferentes = 0, volumes_total = 0;
        double desconto = 0;

        public FrmLivraria()
        {
            InitializeComponent();
            limparCampos();
        }  

        private void btn_limparCampos_Click(object sender, EventArgs e)
        {
            resetarPedidos();
        }

        private void btn_efetuarPedido_Click(object sender, EventArgs e)
        {
            if (checarCampos())
            {
                MessageBox.Show("Os pedidos não Podem apresentar numeros negativos \n\n ou \n\nMais que 10 Volumes por Cliente");
                resetarPedidos();
            }
            else
            {
                hp_vl[0] = Convert.ToInt16(txt_hpvl1.Text);
                hp_vl[1] = Convert.ToInt16(txt_hpvl2.Text);
                hp_vl[2] = Convert.ToInt16(txt_hpvl3.Text);
                hp_vl[3] = Convert.ToInt16(txt_hpvl4.Text);
                hp_vl[4] = Convert.ToInt16(txt_hpvl5.Text);
                hp_vl[5] = Convert.ToInt16(txt_hpvl6.Text);
                hp_vl[6] = Convert.ToInt16(txt_hpvl7.Text);

                for (int i = 0; i < hp_vl.Length; i++)
                {
                    if (hp_vl[i] > 0)
                    {
                        volumes_total = volumes_total + hp_vl[i];
                        volumes_diferentes = volumes_diferentes + 1;
                    }
                }

                switch (volumes_diferentes)
                {
                    case 2:
                        desconto = 0.05;
                        break;
                    case 3:
                        desconto = 0.10;
                        break;
                    case 4:
                        desconto = 0.15;
                        break;
                    case 5:
                        desconto = 0.20;
                        break;
                    case 6:
                        desconto = 0.25;
                        break;
                    case 7:
                        desconto = 0.30;
                        break;
                    default:
                        desconto = 0;
                        break;
                }


                lbl_hp_vl1.Text = Convert.ToString(hp_vl[0]);
                lbl_hp_vl2.Text = Convert.ToString(hp_vl[1]);
                lbl_hp_vl3.Text = Convert.ToString(hp_vl[2]);
                lbl_hp_vl4.Text = Convert.ToString(hp_vl[3]);
                lbl_hp_vl5.Text = Convert.ToString(hp_vl[4]);
                lbl_hp_vl6.Text = Convert.ToString(hp_vl[5]);
                lbl_hp_vl7.Text = Convert.ToString(hp_vl[6]);

                lbl_hp_vlT.Text = Convert.ToString(volumes_total);

                ValorPagamento valorPagamento = new ValorPagamento();
                valorPagamento.qtd_vl_total = volumes_total;
                valorPagamento.qtd_vl_diferentes = volumes_diferentes;
                valorPagamento.desc = desconto;

                lbl_valorTotal.Text = Convert.ToString(valorPagamento.valorTotal);
                lbl_valorDesconto.Text = Convert.ToString(valorPagamento.valorDesconto);
                lbl_valorFinal.Text = Convert.ToString(valorPagamento.valorFinal);

                limparCampos();
            }            
        }

        private bool checarCampos()
        {
            bool checarCampos = true;
            if (Convert.ToInt16(txt_hpvl1.Text) < 0 || Convert.ToInt16(txt_hpvl2.Text) < 0 ||
                Convert.ToInt16(txt_hpvl3.Text) < 0 || Convert.ToInt16(txt_hpvl4.Text) < 0 ||
                Convert.ToInt16(txt_hpvl5.Text) < 0 || Convert.ToInt16(txt_hpvl6.Text) < 0 ||
                Convert.ToInt16(txt_hpvl7.Text) < 0 
                ||
                Convert.ToInt16(txt_hpvl1.Text) > 10 || Convert.ToInt16(txt_hpvl2.Text) > 10 ||
                Convert.ToInt16(txt_hpvl3.Text) > 10 || Convert.ToInt16(txt_hpvl4.Text) > 10 ||
                Convert.ToInt16(txt_hpvl5.Text) > 10 || Convert.ToInt16(txt_hpvl6.Text) > 10 ||
                Convert.ToInt16(txt_hpvl7.Text) > 10)
            {
                checarCampos = true;
            }
            else
            {
                checarCampos = false;

            }
            return checarCampos;
        }

        private void limparCampos()
        {
            volumes_total = 0;
            volumes_diferentes = 0;
            desconto = 0;
            txt_hpvl1.Text = " 0 ";
            txt_hpvl2.Text = " 0 ";
            txt_hpvl3.Text = " 0 ";
            txt_hpvl4.Text = " 0 ";
            txt_hpvl5.Text = " 0 ";
            txt_hpvl6.Text = " 0 ";
            txt_hpvl7.Text = " 0 ";
        }

        private void resetarPedidos()
        {
            volumes_total = 0;
            volumes_diferentes = 0;
            desconto = 0;
            txt_hpvl1.Text = " 0 ";
            txt_hpvl2.Text = " 0 ";
            txt_hpvl3.Text = " 0 ";
            txt_hpvl4.Text = " 0 ";
            txt_hpvl5.Text = " 0 ";
            txt_hpvl6.Text = " 0 ";
            txt_hpvl7.Text = " 0 ";
            lbl_hp_vl1.Text = " 0 ";
            lbl_hp_vl2.Text = " 0 ";
            lbl_hp_vl3.Text = " 0 ";
            lbl_hp_vl4.Text = " 0 ";
            lbl_hp_vl5.Text = " 0 ";
            lbl_hp_vl6.Text = " 0 ";
            lbl_hp_vl7.Text = " 0 ";
            lbl_hp_vlT.Text = " 0 ";
            lbl_valorTotal.Text = " 0.00 ";
            lbl_valorDesconto.Text = " 0.00 ";
            lbl_valorFinal.Text = " 0.00 ";
            txt_hpvl1.Focus();
        }
    }
}
