using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace projVendas
{
    class Program
    {
        static void Main(string[] args)
        {
            Vendedores vendedores = new Vendedores(5);

            Vendedor vendedor1 = new Vendedor(1, "Joao", 11);
            Vendedor vendedor2 = new Vendedor(2, "Maria", 12);
            Vendedor vendedor3 = new Vendedor(3, "Antonio", 13);
            Vendedor vendedor4 = new Vendedor(4, "Roberto", 14);
            Vendedor vendedor5 = new Vendedor(5, "Julia", 15);

            Venda venda1 = new Venda(10, 500.00);
            Venda venda2 = new Venda(20, 700.00);
            Venda venda3 = new Venda(30, 1500.00);
            Venda venda4 = new Venda(10, 200.00);
            Venda venda5 = new Venda(20, 400.00);
            Venda venda6 = new Venda(30, 900.00);


            vendedor1.registrarVenda(1, venda1);
            vendedor1.registrarVenda(5, venda2);

            vendedor2.registrarVenda(3, venda3);
            vendedor2.registrarVenda(9, venda4);

            vendedor3.registrarVenda(5, venda5);
            vendedor3.registrarVenda(15, venda6);


            vendedores.addVendedor(vendedor1);
            vendedores.addVendedor(vendedor2);
            vendedores.addVendedor(vendedor3);
            vendedores.addVendedor(vendedor4);
            vendedores.addVendedor(vendedor5);

            Console.WriteLine(vendedores.listaVendedores());

            Vendedor vendedorPesquisado = vendedores.searchVendedor(new Vendedor(2, "", 0.00));
            if (vendedorPesquisado.Id != 0)
            {
                Console.WriteLine(vendedorPesquisado.dados());
                Console.WriteLine(vendedorPesquisado.listaVendas());
                /*
                foreach (Venda v in vendedorPesquisado.AsVendas)
                {
                    if (v.Qtde > 0)
                    {
                        Console.WriteLine(v.dados());
                    }
                }
                 */
            }
            else
            {
                Console.WriteLine("Vendedor não encontrado");
            }


            Console.WriteLine("Total das vendas: {0}", vendedores.valorVendas());
            Console.WriteLine("Total das comissões: {0}", vendedores.valorComissao());

            vendedores.delVendedor(vendedor2);

            Console.WriteLine(vendedores.listaVendedores());

            vendedores.delVendedor(vendedor4);

            Console.WriteLine(vendedores.listaVendedores());

            Console.ReadKey();
        }
    }
}
