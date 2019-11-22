using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevRamper_Resposta
{
    class ValorPagamento
    {
        public int qtd_vl_total { get; set; }
        public int qtd_vl_diferentes { get; set; }
        public double desc { get; set; }
        
        public double valorTotal
        {
            get { return qtd_vl_total * 42.00; }
        }

        public double valorDesconto
        {
            get { return valorTotal * desc ; }
        }

        public double valorFinal
        {
            get { return valorTotal - valorDesconto; }
        }        
    }
}
