using System;
using System.Collections.Generic;

namespace Persistence
{
    public partial class TbUsuario
    {
        public TbUsuario()
        {
            Tbcartao = new HashSet<TbCartao>();
            TbcontaBancaria = new HashSet<TbContaBancaria>();
            TbentregaCodUsuarioClienteNavigation = new HashSet<TbEntrega>();
            TbentregaCodUsuarioEntregadorNavigation = new HashSet<TbEntrega>();
            TbsolicitacaoDeCadastroCodUsuarioEntregadorNavigation = new HashSet<TbSolicitacaoDeCadastro>();
            TbsolicitacaoDeCadastroCodUsuarioFuncionarioNavigation = new HashSet<TbSolicitacaoDeCadastro>();
            TbusuarioVeiculo = new HashSet<TbUsuarioVeiculo>();
            Tbveiculo = new HashSet<TbVeiculo>();
        }

        public int CodUsuario { get; set; }
        public string Cpf { get; set; }
        public string StatusCliente { get; set; }
        public string StatusEntregador { get; set; }
        public string UserName { get; set; }

        public ICollection<TbCartao> Tbcartao { get; set; }
        public ICollection<TbContaBancaria> TbcontaBancaria { get; set; }
        public ICollection<TbEntrega> TbentregaCodUsuarioClienteNavigation { get; set; }
        public ICollection<TbEntrega> TbentregaCodUsuarioEntregadorNavigation { get; set; }
        public ICollection<TbSolicitacaoDeCadastro> TbsolicitacaoDeCadastroCodUsuarioEntregadorNavigation { get; set; }
        public ICollection<TbSolicitacaoDeCadastro> TbsolicitacaoDeCadastroCodUsuarioFuncionarioNavigation { get; set; }
        public ICollection<TbUsuarioVeiculo> TbusuarioVeiculo { get; set; }
        public ICollection<TbVeiculo> Tbveiculo { get; set; }
    }
}
