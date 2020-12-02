using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace projVendas
{
    class Vendedores
    {
        private Vendedor[] osVendedores;
        private int max;
        private int qtde;

        public Vendedor[] OsVendedores
        {
            get { return osVendedores; }
            set { osVendedores = value; }
        }

        public int Max
        {
            get { return max; }
            set { max = value; }
        }

        public int Qtde
        {
            get { return qtde; }
            set { qtde = value; }
        }

        public Vendedores(int max)
        {
            this.max = max;
            this.qtde = 0;
            this.osVendedores = new Vendedor[this.max];
            for (int i = 0; i < max; ++i)
            {
                this.osVendedores[i] = new Vendedor();
            }
        }

        public bool addVendedor(Vendedor v)
        {
            bool podeAdicionar = (qtde < max);
            if (podeAdicionar)
            {
                this.osVendedores[this.qtde++] = v;
            }
            return podeAdicionar;
        }

        public bool delVendedor(Vendedor v)
        {
            bool podeDeletar = (
                this.searchVendedor(v).Id != 0 && 
                this.searchVendedor(v).valorVendas() == 0
                );
            int i = 0;
            int j;
            if (podeDeletar)
            {
                while (!v.Equals(this.osVendedores[i]))
                {
                    ++i;
                }
                for (j = i; j < max - 1; ++j)
                {
                    this.osVendedores[j] = this.osVendedores[j + 1];
                }
                this.osVendedores[this.max - 1] = new Vendedor();
            }
            return podeDeletar;
        }

        public Vendedor searchVendedor(Vendedor v)
        {
            Vendedor vendedorAchado = new Vendedor();
            foreach (Vendedor vendedor in this.osVendedores)
            {
                if (v.Equals(vendedor))
                {
                    vendedorAchado = vendedor;
                }
            }
            return vendedorAchado;
        }

        public double valorVendas()
        {
            double totalVendas = 0;
            foreach (Vendedor vendedor in this.osVendedores)
            {
                totalVendas += vendedor.valorVendas();
            }
            return totalVendas;
        }

        public double valorComissao()
        {
            double totalComissao = 0;
            foreach (Vendedor vendedor in this.osVendedores)
            {
                totalComissao += vendedor.valorComissao();
            }
            return totalComissao;
        }

        public string listaVendedores()
        {
            string lista = "";
            foreach (Vendedor v in this.osVendedores)
            {
                if (v.Id != 0)
                {
                    lista += v.dados() + '\n';
                }
            }
            return lista;
        }
    }
}
