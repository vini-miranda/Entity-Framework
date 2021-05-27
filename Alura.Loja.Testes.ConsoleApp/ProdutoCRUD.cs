using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.Loja.Testes.ConsoleApp
{
    class ProdutoCRUD
    {
        public static void GravarUsandoEntity()
        {
            Produto p = new Produto();
            p.Nome = "Harry Potter e a Ordem da Fênix";
            p.Categoria = "Livros";
            p.Preco = 19.89;

            Produto p2 = new Produto();
            p2.Nome = "Harry Potter e o Prisioneiro de Azkbahn";
            p2.Categoria = "Livros";
            p2.Preco = 15.50;

            using (var contexto = new ProdutoDAOEntity())
            {
                contexto.Adicionar(p2);
            }
        }

        public static void AtualizarProduto(int id)
        {
            using (var context = new ProdutoDAOEntity())
            {
                var ItemToRefresh = context.Produtos().SingleOrDefault(x => x.Id == id);
                if (ItemToRefresh != null)
                {
                    ItemToRefresh.Preco = 10.75;
                    ItemToRefresh.Nome = "Harry Potter - Editado2";
                    context.Atualizar(ItemToRefresh);
                }
            }
            RecuperarProdutos();
        }

        public static void ExcluirUnicoItem(int id)
        {

            using (var context = new ProdutoDAOEntity())
            {
                var ItemToRemove = context.Produtos().SingleOrDefault(x => x.Id == id);
                if (ItemToRemove != null)
                {
                    context.Remover(ItemToRemove);
                }
            }
        }

        public static void ExcluirProdutos()
        {
            using (var contexto = new ProdutoDAOEntity())
            {
                IList<Produto> produtos = contexto.Produtos();
                foreach (var item in produtos)
                {
                    contexto.Remover(item);
                }
            }
        }

        public static void RecuperarProdutos()
        {
            using (var contexto = new ProdutoDAOEntity())
            {
                IList<Produto> produtos = contexto.Produtos();
                Console.WriteLine("Foram encontrados {0} produto(s).", produtos.Count);
                foreach (var item in produtos)
                {
                    Console.WriteLine(item.Nome + "\t\t" + item.Categoria + " " + item.Preco);
                }
            }

            Console.ReadLine();
        }
    }
}
