using System;
using System.Collections.Generic;

namespace Persistence
{
    public partial class TbUsuario
    {
        public TbUsuario()
        {
            Cartao = new HashSet<TbCartao>();
            ContaBancaria = new HashSet<TbContaBancaria>();
            EntregaCodUsuarioClienteNavigation = new HashSet<TbEntrega>();
            EntregaCodUsuarioEntregadorNavigation = new HashSet<TbEntrega>();
            SolicitacaoDeCadastroCodUsuarioEntregadorNavigation = new HashSet<TbSolicitacaoDeCadastro>();
            SolicitacaoDeCadastroCodUsuarioFuncionarioNavigation = new HashSet<TbSolicitacaoDeCadastro>();
            UsuarioVeiculo = new HashSet<TbUsuarioVeiculo>();
            Veiculo = new HashSet<TbVeiculo>();
        }

        public int CodUsuario { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string Tipo { get; set; }
        public string StatusCliente { get; set; }
        public string StatusEntregador { get; set; }

        public virtual ICollection<TbCartao> Cartao { get; set; }
        public virtual ICollection<TbContaBancaria> ContaBancaria { get; set; }
        public virtual ICollection<TbEntrega> EntregaCodUsuarioClienteNavigation { get; set; }
        public virtual ICollection<TbEntrega> EntregaCodUsuarioEntregadorNavigation { get; set; }
        public virtual ICollection<TbSolicitacaoDeCadastro> SolicitacaoDeCadastroCodUsuarioEntregadorNavigation { get; set; }
        public virtual ICollection<TbSolicitacaoDeCadastro> SolicitacaoDeCadastroCodUsuarioFuncionarioNavigation { get; set; }
        public virtual ICollection<TbUsuarioVeiculo> UsuarioVeiculo { get; set; }
        public virtual ICollection<TbVeiculo> Veiculo { get; set; }
    }
}
