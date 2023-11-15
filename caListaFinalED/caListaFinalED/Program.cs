using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace caListaFinalED
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Arvore Binaria:");

            ArvoreBin arvoreBin1 = new ArvoreBin(); // cria a árvore -> root = null

            arvoreBin1.inserir(20);
            arvoreBin1.inserir(18);
            arvoreBin1.inserir(25);
            arvoreBin1.inserir(10);
            arvoreBin1.inserir(12);
            arvoreBin1.inserir(30);
            arvoreBin1.inserir(27);
            arvoreBin1.inserir(32);
            arvoreBin1.inserir(5);
            arvoreBin1.inserir(7);
            arvoreBin1.imprimirArvore();
            Console.WriteLine(arvoreBin1.calculaAltura());
            Console.WriteLine(arvoreBin1.contaNos());
            Console.WriteLine(arvoreBin1.contaFolhas());
            Console.WriteLine(arvoreBin1.fatorDeBalanceamentoDaRaiz());

            arvoreBin1.removeQlqrNoh(10);
            arvoreBin1.imprimirArvore();
            Console.WriteLine(arvoreBin1.calculaAltura());
            Console.WriteLine(arvoreBin1.contaNos());
            Console.WriteLine(arvoreBin1.contaFolhas());
            Console.WriteLine(arvoreBin1.fatorDeBalanceamentoDaRaiz());



            Console.WriteLine();



            ArvoreBin arvoreBin2 = new ArvoreBin(); // cria a árvore -> root = null

            arvoreBin2.inserir(20);
            arvoreBin2.inserir(18);
            arvoreBin2.inserir(25);
            arvoreBin2.inserir(10);
            arvoreBin2.inserir(12);
            arvoreBin2.inserir(30);
            arvoreBin2.inserir(27);
            arvoreBin2.inserir(32);
            arvoreBin2.inserir(5);
            arvoreBin2.inserir(7);
            Console.WriteLine(arvoreBin1.testaIgualdade(arvoreBin2));
            arvoreBin2.removeQlqrNoh(10);
            Console.WriteLine(arvoreBin1.testaIgualdade(arvoreBin2));

            //Console.WriteLine(arvoreBin1.testaIgualdade(arvoreBin2));
        }
    }
}
