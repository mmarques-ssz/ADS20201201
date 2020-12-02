using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace projVendas
{
    class Vendedor
    {
        private int id;
        private string nome;
        private double percComissao;
        private Venda[] asVendas;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Nome
        {
            get { return nome; }
            set { nome = value; }
        }

        public double PercComissao
        {
            get { return percComissao; }
            set { percComissao = value; }
        }

        public Venda[] AsVendas
        {
            get { return asVendas; }
        }

        public Vendedor(int id, string nome, double percComissao)
        {
            this.id = id;
            this.nome = nome;
            this.percComissao = percComissao;
            this.asVendas = new Venda[31];
            for (int i = 0; i < 31; ++i)
            {
                this.asVendas[i] = new Venda();
            }
        }

        public Vendedor()
            : this(0, "", 0.00)
        { }

        public override bool Equals(object obj)
        {
            return this.id.Equals(((Vendedor)obj).id);
        }

        public void registrarVenda(int dia, Venda venda)
        {
            this.asVendas[dia-1] = venda;
        }

        public double valorVendas()
        {
            double totalVendas = 0;
            foreach (Venda v in this.asVendas)
            {
                totalVendas += v.Valor;
            }
            return totalVendas;
        }

        public double valorComissao()
        {
            return this.valorVendas() * (this.percComissao/100);
        }

        public string dados()
        {
            return
                "Id: " + this.id.ToString() +
                " - Nome: " + this.nome +
                " - % Comissão: " + this.percComissao.ToString() +
                " - Valor das vendas: " + this.valorVendas().ToString() +
                " - Valor da comissão: " + this.valorComissao().ToString();
        }

        public string listaVendas()
        {
            string lista = "";
            foreach (Venda v in this.asVendas)
            {
                if (v.Qtde != 0)
                {
                    lista += v.dados() + '\n';
                }
            }
            return lista;
        }
    }
}
