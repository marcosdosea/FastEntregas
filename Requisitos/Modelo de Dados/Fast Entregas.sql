CREATE DATABASE FastEntregas;
USE FastEntregas;

-- Table FastEntregas.Usuario
CREATE TABLE FastEntregas.Usuario (
  codUsuario INT NOT NULL AUTO_INCREMENT,
  nome VARCHAR(45) NOT NULL,
  cpf VARCHAR(15) NOT NULL,
  telefone VARCHAR(12) NOT NULL,
  email VARCHAR(45) NOT NULL,
  senha VARCHAR(45) NOT NULL,
  tipo INT NOT NULL,
  statusCliente INT NULL,
  statusEntregador INT NULL,
  PRIMARY KEY (codUsuario)
)ENGINE = InnoDB;

INSERT INTO fastentregas.usuario VALUES()

-- Table FastEntregas.Veiculo
CREATE TABLE IF NOT EXISTS FastEntregas.Veiculo (
  codVeiculo INT NOT NULL AUTO_INCREMENT,
  categoria VARCHAR(20) NOT NULL,
  placa VARCHAR(10) NOT NULL,
  renavam VARCHAR(20) NOT NULL,
  ano INT NOT NULL,
  status ENUM('disponivel', 'bloqueado') NOT NULL DEFAULT 'bloqueado',
  emUso TINYINT NOT NULL DEFAULT 0,
  codDono INT NOT NULL,
  PRIMARY KEY (codVeiculo),
  CONSTRAINT fk_Veiculo_Usuario1 FOREIGN KEY (codDono) REFERENCES FastEntregas.Usuario (codUsuario)

) ENGINE = InnoDB;

-- Table FastEntregas.Cartao
CREATE TABLE IF NOT EXISTS FastEntregas.Cartao (
  codCartao INT NOT NULL AUTO_INCREMENT,
  numero INT NOT NULL,
  cpfDono VARCHAR(15) NOT NULL,
  dataValidade VARCHAR(10) NOT NULL,
  cvv INT NOT NULL,
  codUsuario INT NOT NULL,
  PRIMARY KEY (codCartao),
  CONSTRAINT fk_Cartao_Usuario1 FOREIGN KEY (codUsuario) REFERENCES FastEntregas.Usuario (codUsuario)
)ENGINE = InnoDB;

-- Table FastEntregas.Banco
CREATE TABLE IF NOT EXISTS FastEntregas.Banco (
  idBanco INT NOT NULL AUTO_INCREMENT,
  nomeBanco VARCHAR(45) NOT NULL,
  PRIMARY KEY (idBanco)
) ENGINE = InnoDB;

-- Table FastEntregas.Conta_Bancaria
CREATE TABLE IF NOT EXISTS FastEntregas.Conta_Bancaria (
  codConta INT NOT NULL AUTO_INCREMENT,
  numero INT NOT NULL,
  agencia INT NOT NULL,
  tipo VARCHAR(10) NOT NULL,
  codUsuario INT NOT NULL,
  idBanco INT NOT NULL,
  PRIMARY KEY (codConta),
  CONSTRAINT fk_ContaBancaria_Usuario FOREIGN KEY (codUsuario) REFERENCES FastEntregas.Usuario (codUsuario),
  CONSTRAINT fk_Conta_Bancaria_Banco1 FOREIGN KEY (idBanco) REFERENCES FastEntregas.Banco (idBanco)
)ENGINE = InnoDB;

-- Table FastEntregas.Entrega
CREATE TABLE IF NOT EXISTS FastEntregas.Entrega (
  codEntrega INT NOT NULL AUTO_INCREMENT,
  origem VARCHAR(45) NOT NULL,
  destino VARCHAR(45) NOT NULL,
  data DATE NOT NULL,
  status INT NOT NULL,
  valor FLOAT NOT NULL,
  descricao VARCHAR(300) NOT NULL,
  codUsuarioCliente INT NOT NULL,
  codUsuarioServidor INT NOT NULL,
  PRIMARY KEY (codEntrega),
  CONSTRAINT fk_Corrida_Entrega_Usuario1 FOREIGN KEY (codUsuarioCliente) REFERENCES FastEntregas.Usuario (codUsuario),
  CONSTRAINT fk_Corrida_Entrega_Usuario2 FOREIGN KEY (codUsuarioServidor) REFERENCES FastEntregas.Usuario (codUsuario)
)ENGINE = InnoDB;

-- Table FastEntregas.Solicitacao_de_Cadastro
CREATE TABLE IF NOT EXISTS FastEntregas.Solicitacao_de_Cadastro (
  codSolicitacao INT NOT NULL AUTO_INCREMENT,
  numRegistro VARCHAR(15) NOT NULL,
  numCnh VARCHAR(15) NOT NULL,
  dataNascimento DATE NOT NULL,
  status INT NOT NULL,
  codUsuarioEntregador INT NOT NULL,
  codUsuarioFuncionario INT NULL,
  PRIMARY KEY (codSolicitacao),
  CONSTRAINT fk_Solicitacao_de_Cadastro_Usuario1 FOREIGN KEY (codUsuarioEntregador) REFERENCES FastEntregas.Usuario (codUsuario),
  CONSTRAINT fk_Solicitacao_de_Cadastro_Usuario2 FOREIGN KEY (codUsuarioFuncionario) REFERENCES FastEntregas.Usuario (codUsuario)
)ENGINE = InnoDB;

-- Table FastEntregas.Usuario_Veiculo
CREATE TABLE IF NOT EXISTS FastEntregas.Usuario_Veiculo (
  codUsuario INT NOT NULL,
  codVeiculo INT NOT NULL,
  PRIMARY KEY (codUsuario, codVeiculo),
  CONSTRAINT fk_Usuario_has_Veiculo_Usuario1 FOREIGN KEY (codUsuario) REFERENCES FastEntregas.Usuario (codUsuario),
  CONSTRAINT fk_Usuario_has_Veiculo_Veiculo1 FOREIGN KEY (codVeiculo) REFERENCES FastEntregas.Veiculo (codVeiculo)
)ENGINE = InnoDB;

-- Table FastEntregas.FormasPagamento
CREATE TABLE IF NOT EXISTS FastEntregas.FormasPagamento (
  codFormaPagamento INT NOT NULL,
  descricao VARCHAR(45) NOT NULL,
  PRIMARY KEY (codFormaPagamento)
)ENGINE = InnoDB;

-- Table FastEntregas.FormasPagamento_has_Entrega
CREATE TABLE IF NOT EXISTS FastEntregas.FormasPagamento_has_Entrega (
  FormasPagamento_codFormaPagamento INT NOT NULL,
  Entrega_codCorrida_Entrega INT NOT NULL,
  valor FLOAT NOT NULL,
  PRIMARY KEY (FormasPagamento_codFormaPagamento, Entrega_codCorrida_Entrega),
  CONSTRAINT fk_FormasPagamento_has_Entrega_FormasPagamento1 FOREIGN KEY (FormasPagamento_codFormaPagamento) REFERENCES FastEntregas.FormasPagamento (codFormaPagamento),
  CONSTRAINT fk_FormasPagamento_has_Entrega_Entrega1 FOREIGN KEY (Entrega_codCorrida_Entrega) REFERENCES FastEntregas.Entrega (codEntrega)
) ENGINE = InnoDB;

