using Microsoft.EntityFrameworkCore;
using Model;
using Persistence;
using Services;
using System;
using System.Linq;
using Xunit;

namespace TestesServices
{
    public class TesteCartao
    {
        [Fact]
        public void Obter_retorna_cartaoExistente()
        {
            var options = new DbContextOptionsBuilder<fast_entregasContext>()
               .UseInMemoryDatabase(databaseName: "Obter")
               .Options;

            using (var context = new fast_entregasContext(options))
            {
                context.TbCartao.Add(new TbCartao { CodCartao = 123 });
                context.SaveChanges();
            }


            using (var context = new fast_entregasContext(options))
            {
                var cartao = new GerenciadorCartao(context);
                var resultado = cartao.Obter(123);
                Assert.NotNull(resultado);
            }


        }

        [Fact]
        public void Remover_cartaoExistente()
        {
            var options = new DbContextOptionsBuilder<fast_entregasContext>()
               .UseInMemoryDatabase(databaseName: "Remover")
               .Options;

            using (var context = new fast_entregasContext(options))
            {
                context.TbCartao.Add(new TbCartao { CodCartao = 123 });
                context.SaveChanges();
            }


            using (var context = new fast_entregasContext(options))
            {
                var cartao = new GerenciadorCartao(context);
                cartao.Remover(123);
            }


        }

        [Fact]
        public void ObterTodos_retona_todosCartoes()
        {
            var options = new DbContextOptionsBuilder<fast_entregasContext>()
               .UseInMemoryDatabase(databaseName: "ObterTodos")
               .Options;

            using (var context = new fast_entregasContext(options))
            {
                context.TbCartao.Add(new TbCartao { CodCartao = 123 });
                context.TbCartao.Add(new TbCartao { CodCartao = 12345 });
                context.SaveChanges();
            }


            using (var context = new fast_entregasContext(options))
            {
                context.Database.EnsureCreated();
                var cartao = new GerenciadorCartao(context);
                var resultado = cartao.ObterTodos();
                Assert.NotNull(resultado);
                Assert.True(resultado.Count() == 2);
            }


        }


        [Fact]
        public void Obter_retorno_porNumero()
        {
            var options = new DbContextOptionsBuilder<fast_entregasContext>()
               .UseInMemoryDatabase(databaseName: "ObterPorNumero")
               .Options;

            using (var context = new fast_entregasContext(options))
            {
                context.TbCartao.Add(new TbCartao { Numero = "4321-1" });
                context.SaveChanges();
            }


            using (var context = new fast_entregasContext(options))
            {
                context.Database.EnsureCreated();
                var cartao = new GerenciadorCartao(context);
                var resultado = cartao.ObterPorNumero("4321-1");
                Assert.NotNull(resultado);
                Assert.True(resultado.Count() == 1);
            }


        }

        [Fact]
        public void Inserir_cartao()
        {
            var options = new DbContextOptionsBuilder<fast_entregasContext>()
               .UseInMemoryDatabase(databaseName: "Inserir")
               .Options;


            using (var context = new fast_entregasContext(options))
            {
                context.Database.EnsureCreated();
                var cartao = new GerenciadorCartao(context);
                var resultado = cartao.Inserir(new Cartao { CodCartao = 123 });
                Assert.True(resultado == 123);
            }


        }

        [Fact]
        public void Editar_cartaoExistente()
        {
            var options = new DbContextOptionsBuilder<fast_entregasContext>()
               .UseInMemoryDatabase(databaseName: "Editar")
               .Options;


            using (var context = new fast_entregasContext(options))
            {
                context.TbCartao.Add(new TbCartao { CodCartao = 123 });
                context.SaveChanges();
            }

            using (var context = new fast_entregasContext(options))
            {
                context.Database.EnsureCreated();
                var cartao = new GerenciadorCartao(context);
                cartao.Editar(new Cartao { CodCartao = 123, Numero = "4321 - 1" });
            }


        }

        [Fact]
        public void Editar_cartaoNaoExistente_Jogaexcecao()
        {
            var options = new DbContextOptionsBuilder<fast_entregasContext>()
               .UseInMemoryDatabase(databaseName: "Editar_cartaoNaoExistente_Jogaexcecao")
               .Options;


            using (var context = new fast_entregasContext(options))
            {
                context.TbCartao.Add(new TbCartao { CodCartao = 123 });
                context.SaveChanges();
            }

            using (var context = new fast_entregasContext(options))
            {
                context.Database.EnsureCreated();
                var cartao = new GerenciadorCartao(context);

                Assert.Throws<Exception>(() => cartao.Editar(new Cartao { CodCartao = 124342, Numero = "123-2" }));
            }


        }
    }
}
