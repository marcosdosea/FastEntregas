using Microsoft.EntityFrameworkCore;
using Model;
using Persistence;
using Services;
using System;
using System.Linq;
using Xunit;

namespace TestesServices
{
    public class TesteContaBancaria
    {
        /// <summary>
        /// Obtendo informações da conta
        /// </summary>
        [Fact]
        public void Obter_retornar_conta_existente()
        {
            var options = new DbContextOptionsBuilder<fast_entregasContext>()
               .UseInMemoryDatabase(databaseName: "Obter")
               .Options;

            using (var context = new fast_entregasContext(options))
            {
                context.TbContaBancaria.Add(new TbContaBancaria { CodConta = 1234 });
                context.SaveChanges();
            }


            using (var context = new fast_entregasContext(options))
            {
                var contabancaria = new GerenciadorContaBancaria(context);
                var resultado = contabancaria.Obter(1234);
                Assert.NotNull(resultado);
            }


        }

        [Fact]
        public void Remover_conta_existente()
        {
            var options = new DbContextOptionsBuilder<fast_entregasContext>()
               .UseInMemoryDatabase(databaseName: "Remover")
               .Options;

            using (var context = new fast_entregasContext(options))
            {
                context.TbContaBancaria.Add(new TbContaBancaria { CodConta = 1234 });
                context.SaveChanges();
            }


            using (var context = new fast_entregasContext(options))
            {
                var contabancaria = new GerenciadorContaBancaria(context);
                contabancaria.Remover(1234);
            }


        }

        [Fact]
        public void ObterTodas_retona_todasContas()
        {
            var options = new DbContextOptionsBuilder<fast_entregasContext>()
               .UseInMemoryDatabase(databaseName: "ObterTodas")
               .Options;

            using (var context = new fast_entregasContext(options))
            {
                context.TbContaBancaria.Add(new TbContaBancaria { CodConta = 1234 });
                context.TbContaBancaria.Add(new TbContaBancaria { CodConta = 1235 });
                context.SaveChanges();
            }


            using (var context = new fast_entregasContext(options))
            {
                context.Database.EnsureCreated();
                var contabancaria = new GerenciadorContaBancaria(context);
                var resultado = contabancaria.ObterTodas();
                Assert.NotNull(resultado);
                Assert.True(resultado.Count() == 2);
            }


        }


        [Fact]
        public void Obter_retorno_porconta()
        {
            var options = new DbContextOptionsBuilder<fast_entregasContext>()
               .UseInMemoryDatabase(databaseName: "ObterPorConta")
               .Options;

            using (var context = new fast_entregasContext(options))
            {
                context.TbContaBancaria.Add(new TbContaBancaria { Numero = 1234 });
                context.SaveChanges();
            }


            using (var context = new fast_entregasContext(options))
            {
                context.Database.EnsureCreated();
                var contabancaria = new GerenciadorContaBancaria(context);
                var resultado = contabancaria.ObterPorConta(1234);
                Assert.NotNull(resultado);
                Assert.True(resultado.Count() == 1);
            }


        }

        [Fact]
        public void Inserir_conta()
        {
            var options = new DbContextOptionsBuilder<fast_entregasContext>()
               .UseInMemoryDatabase(databaseName: "Inserir")
               .Options;


            using (var context = new fast_entregasContext(options))
            {
                context.Database.EnsureCreated();
                var contabancaria = new GerenciadorContaBancaria(context);
                var resultado = contabancaria.Inserir(new ContaBancaria { CodConta = 1234 });
                Assert.True(resultado == 1234);
            }


        }

        [Fact]
        public void Editar_contaExistente()
        {
            var options = new DbContextOptionsBuilder<fast_entregasContext>()
               .UseInMemoryDatabase(databaseName: "Editar")
               .Options;


            using (var context = new fast_entregasContext(options))
            {
                context.TbContaBancaria.Add(new TbContaBancaria { CodConta = 1234 });
                context.SaveChanges();
            }

            using (var context = new fast_entregasContext(options))
            {
                context.Database.EnsureCreated();
                var contabancaria = new GerenciadorContaBancaria(context);
                contabancaria.Editar(new ContaBancaria { CodConta = 1234, Numero = 123 });
            }


        }

        [Fact]
        public void Editar_contaNaoExistente_Jogaexcecao()
        {
            var options = new DbContextOptionsBuilder<fast_entregasContext>()
               .UseInMemoryDatabase(databaseName: "Editar_contaNaoExistente_Jogaexcecao")
               .Options;


            using (var context = new fast_entregasContext(options))
            {
                context.TbContaBancaria.Add(new TbContaBancaria { CodConta = 1234 });
                context.SaveChanges();
            }

            using (var context = new fast_entregasContext(options))
            {
                context.Database.EnsureCreated();
                var contabancaria = new GerenciadorContaBancaria(context);

                Assert.Throws<Exception>(() => contabancaria.Editar(new ContaBancaria { CodConta = 124342, Numero = 123 }));
            }


        }

    }
}
