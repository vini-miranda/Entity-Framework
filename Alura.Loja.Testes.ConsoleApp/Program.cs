using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.Loja.Testes.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
           using(var context = new LojaContext())
            {
                var produtos = context.Produtos.ToList();
                foreach(var p in produtos)
                {
                    Console.WriteLine(p);
                }
                Console.WriteLine("================");

                foreach(var e in context.ChangeTracker.Entries())
                {
                    Console.WriteLine(e.State);
                }

                var p1 = produtos.First();
                p1.Nome = "Novo Livro";
                Console.WriteLine("================");


                foreach (var e in context.ChangeTracker.Entries())
                {
                    Console.WriteLine(e.State);
                }
                Console.ReadLine();
            }
        }
    }
}
