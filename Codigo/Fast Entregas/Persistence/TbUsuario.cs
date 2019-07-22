using System;
using System.Collections.Generic;

namespace Persistence
{
    public partial class Usuario
    {
        public Usuario()
        {
            Cartao = new HashSet<Cartao>();
            ContaBancaria = new HashSet<ContaBancaria>();
            EntregaCodUsuarioClienteNavigation = new HashSet<Entrega>();
            EntregaCodUsuarioEntregadorNavigation = new HashSet<Entrega>();
            SolicitacaoDeCadastroCodUsuarioEntregadorNavigation = new HashSet<SolicitacaoDeCadastro>();
            SolicitacaoDeCadastroCodUsuarioFuncionarioNavigation = new HashSet<SolicitacaoDeCadastro>();
            UsuarioVeiculo = new HashSet<UsuarioVeiculo>();
            Veiculo = new HashSet<Veiculo>();
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

        public virtual ICollection<Cartao> Cartao { get; set; }
        public virtual ICollection<ContaBancaria> ContaBancaria { get; set; }
        public virtual ICollection<Entrega> EntregaCodUsuarioClienteNavigation { get; set; }
        public virtual ICollection<Entrega> EntregaCodUsuarioEntregadorNavigation { get; set; }
        public virtual ICollection<SolicitacaoDeCadastro> SolicitacaoDeCadastroCodUsuarioEntregadorNavigation { get; set; }
        public virtual ICollection<SolicitacaoDeCadastro> SolicitacaoDeCadastroCodUsuarioFuncionarioNavigation { get; set; }
        public virtual ICollection<UsuarioVeiculo> UsuarioVeiculo { get; set; }
        public virtual ICollection<Veiculo> Veiculo { get; set; }
    }
}
