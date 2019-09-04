-- MySQL dump 10.13  Distrib 8.0.16, for Win64 (x86_64)
--
-- Host: 127.0.0.1    Database: fast_entregas
-- ------------------------------------------------------
-- Server version	8.0.16

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
 SET NAMES utf8 ;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `__efmigrationshistory`
--

DROP TABLE IF EXISTS `__efmigrationshistory`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `__efmigrationshistory` (
  `MigrationId` varchar(150) NOT NULL,
  `ProductVersion` varchar(32) NOT NULL,
  PRIMARY KEY (`MigrationId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `__efmigrationshistory`
--

LOCK TABLES `__efmigrationshistory` WRITE;
/*!40000 ALTER TABLE `__efmigrationshistory` DISABLE KEYS */;
INSERT INTO `__efmigrationshistory` VALUES ('00000000000000_CreateIdentitySchema','2.1.11-servicing-32099');
/*!40000 ALTER TABLE `__efmigrationshistory` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `aspnetroleclaims`
--

DROP TABLE IF EXISTS `aspnetroleclaims`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `aspnetroleclaims` (
  `Id` int(11) NOT NULL,
  `RoleId` varchar(767) NOT NULL,
  `ClaimType` text,
  `ClaimValue` text,
  PRIMARY KEY (`Id`),
  KEY `IX_AspNetRoleClaims_RoleId` (`RoleId`),
  CONSTRAINT `FK_AspNetRoleClaims_AspNetRoles_RoleId` FOREIGN KEY (`RoleId`) REFERENCES `aspnetroles` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `aspnetroleclaims`
--

LOCK TABLES `aspnetroleclaims` WRITE;
/*!40000 ALTER TABLE `aspnetroleclaims` DISABLE KEYS */;
/*!40000 ALTER TABLE `aspnetroleclaims` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `aspnetroles`
--

DROP TABLE IF EXISTS `aspnetroles`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `aspnetroles` (
  `Id` varchar(767) NOT NULL,
  `Name` varchar(256) DEFAULT NULL,
  `NormalizedName` varchar(256) DEFAULT NULL,
  `ConcurrencyStamp` text,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `RoleNameIndex` (`NormalizedName`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `aspnetroles`
--

LOCK TABLES `aspnetroles` WRITE;
/*!40000 ALTER TABLE `aspnetroles` DISABLE KEYS */;
INSERT INTO `aspnetroles` VALUES ('1','cliente','cliente',NULL),('2','entregador','entregador',NULL),('3','funcionario','funcionario',NULL);
/*!40000 ALTER TABLE `aspnetroles` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `aspnetuserclaims`
--

DROP TABLE IF EXISTS `aspnetuserclaims`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `aspnetuserclaims` (
  `Id` int(11) NOT NULL,
  `UserId` varchar(767) NOT NULL,
  `ClaimType` text,
  `ClaimValue` text,
  PRIMARY KEY (`Id`),
  KEY `IX_AspNetUserClaims_UserId` (`UserId`),
  CONSTRAINT `FK_AspNetUserClaims_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `aspnetusers` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `aspnetuserclaims`
--

LOCK TABLES `aspnetuserclaims` WRITE;
/*!40000 ALTER TABLE `aspnetuserclaims` DISABLE KEYS */;
/*!40000 ALTER TABLE `aspnetuserclaims` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `aspnetuserlogins`
--

DROP TABLE IF EXISTS `aspnetuserlogins`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `aspnetuserlogins` (
  `LoginProvider` varchar(128) NOT NULL,
  `ProviderKey` varchar(128) NOT NULL,
  `ProviderDisplayName` text,
  `UserId` varchar(767) NOT NULL,
  PRIMARY KEY (`LoginProvider`,`ProviderKey`),
  KEY `IX_AspNetUserLogins_UserId` (`UserId`),
  CONSTRAINT `FK_AspNetUserLogins_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `aspnetusers` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `aspnetuserlogins`
--

LOCK TABLES `aspnetuserlogins` WRITE;
/*!40000 ALTER TABLE `aspnetuserlogins` DISABLE KEYS */;
/*!40000 ALTER TABLE `aspnetuserlogins` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `aspnetuserroles`
--

DROP TABLE IF EXISTS `aspnetuserroles`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `aspnetuserroles` (
  `UserId` varchar(767) NOT NULL,
  `RoleId` varchar(767) NOT NULL,
  PRIMARY KEY (`UserId`,`RoleId`),
  KEY `IX_AspNetUserRoles_RoleId` (`RoleId`),
  CONSTRAINT `FK_AspNetUserRoles_AspNetRoles_RoleId` FOREIGN KEY (`RoleId`) REFERENCES `aspnetroles` (`Id`) ON DELETE CASCADE,
  CONSTRAINT `FK_AspNetUserRoles_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `aspnetusers` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `aspnetuserroles`
--

LOCK TABLES `aspnetuserroles` WRITE;
/*!40000 ALTER TABLE `aspnetuserroles` DISABLE KEYS */;
INSERT INTO `aspnetuserroles` VALUES ('1e43005d-fa18-4fae-a4f4-7775a9f1518f','1');
/*!40000 ALTER TABLE `aspnetuserroles` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `aspnetusers`
--

DROP TABLE IF EXISTS `aspnetusers`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `aspnetusers` (
  `Id` varchar(767) NOT NULL,
  `UserName` varchar(256) DEFAULT NULL,
  `NormalizedUserName` varchar(256) DEFAULT NULL,
  `Email` varchar(256) DEFAULT NULL,
  `NormalizedEmail` varchar(256) DEFAULT NULL,
  `EmailConfirmed` bit(1) NOT NULL,
  `PasswordHash` text,
  `SecurityStamp` text,
  `ConcurrencyStamp` text,
  `PhoneNumber` text,
  `PhoneNumberConfirmed` bit(1) NOT NULL,
  `TwoFactorEnabled` bit(1) NOT NULL,
  `LockoutEnd` timestamp NULL DEFAULT NULL,
  `LockoutEnabled` bit(1) NOT NULL,
  `AccessFailedCount` int(11) NOT NULL,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `UserNameIndex` (`NormalizedUserName`),
  UNIQUE KEY `Email_UNIQUE` (`Email`),
  KEY `EmailIndex` (`NormalizedEmail`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `aspnetusers`
--

LOCK TABLES `aspnetusers` WRITE;
/*!40000 ALTER TABLE `aspnetusers` DISABLE KEYS */;
INSERT INTO `aspnetusers` VALUES ('1e43005d-fa18-4fae-a4f4-7775a9f1518f','clovijan','CLOVIJAN','clovijan@gmail.com','CLOVIJAN@GMAIL.COM',_binary '\0','AQAAAAEAACcQAAAAELWTVgUd00+DqVc6ndtTmhoTs2qfIYRsD0HDxo50vaRBvLx/X/jy6fj0zaSctwjsaQ==','XBSLRXMBDF5VDWKZY3FJGA5VI7SYRU26','d2b5fd44-2607-4c94-86f5-1a14b86a30de',NULL,_binary '\0',_binary '\0',NULL,_binary '',0),('4f3515ca-5266-43bf-9a10-38eb3a0203eb','wrwqe','WRWQE','fgh@gmail.com','FGH@GMAIL.COM',_binary '\0','AQAAAAEAACcQAAAAEHpBtrG8AqCJhXVwpzGupK2mq7VDlPx0l+cmsBZOAPNCuyj6EeF4O3lCeYZZBEvAWg==','BM7QPHN26IKUJAYPLVCIJITNAEWTOK6K','31e09bd2-815f-40b3-8068-15972d019e4f','79 9 8809 7795',_binary '\0',_binary '\0',NULL,_binary '',0),('6e7c1c12-74f7-4de0-8db3-47e8db6d7ea7','natan.goes777@gmail.com','NATAN.GOES777@GMAIL.COM','natan.goes777@gmail.com','NATAN.GOES777@GMAIL.COM',_binary '\0','AQAAAAEAACcQAAAAEO9Uzrsx4DkoW413buMW7dJWQHqNV1GDF2x9zrGLndjUNI1RRk/hyAZiw36S56nBEA==','2LS5KGYGWD7ETEM6BJS4PMK2PBIDH2UZ','7425981c-e16d-4efa-bde4-7a23595f6cd4',NULL,_binary '\0',_binary '\0',NULL,_binary '',0),('b3367181-1f82-4a0a-9089-0b7c9a5ac4f4','dosea','DOSEA','dosea@gmail.com','DOSEA@GMAIL.COM',_binary '\0','AQAAAAEAACcQAAAAEOtqSptuWArIuG4THTkyQPrzk5ea2h3JA38YsbgZF1/0ldixOF5WgFBZEQ6wBlIO5g==','4DDJMDPHY4RZI24CEV2IWLJ2YNJH4CRX','ca6e40a1-ef3c-45cd-bb07-1c5fd82151f9','79 9 12345689',_binary '\0',_binary '\0',NULL,_binary '',0);
/*!40000 ALTER TABLE `aspnetusers` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `aspnetusertokens`
--

DROP TABLE IF EXISTS `aspnetusertokens`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `aspnetusertokens` (
  `UserId` varchar(767) NOT NULL,
  `LoginProvider` varchar(128) NOT NULL,
  `Name` varchar(128) NOT NULL,
  `Value` text,
  PRIMARY KEY (`UserId`,`LoginProvider`,`Name`),
  CONSTRAINT `FK_AspNetUserTokens_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `aspnetusers` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `aspnetusertokens`
--

LOCK TABLES `aspnetusertokens` WRITE;
/*!40000 ALTER TABLE `aspnetusertokens` DISABLE KEYS */;
/*!40000 ALTER TABLE `aspnetusertokens` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `banco`
--

DROP TABLE IF EXISTS `banco`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `banco` (
  `codBanco` int(11) NOT NULL AUTO_INCREMENT,
  `nome` varchar(45) NOT NULL,
  PRIMARY KEY (`codBanco`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `banco`
--

LOCK TABLES `banco` WRITE;
/*!40000 ALTER TABLE `banco` DISABLE KEYS */;
INSERT INTO `banco` VALUES (1,'Banco do Brasil'),(2,'Bradesco'),(3,'Santander'),(4,'Itaú'),(5,'Banese'),(6,'Caixa');
/*!40000 ALTER TABLE `banco` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `cartao`
--

DROP TABLE IF EXISTS `cartao`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `cartao` (
  `codCartao` int(11) NOT NULL AUTO_INCREMENT,
  `numero` varchar(20) DEFAULT NULL,
  `nomeDono` varchar(50) NOT NULL,
  `dataValidade` varchar(10) NOT NULL,
  `cvv` int(11) NOT NULL,
  `codUsuario` int(11) NOT NULL,
  PRIMARY KEY (`codCartao`),
  KEY `fk_Cartao_Usuario1_idx` (`codUsuario`),
  CONSTRAINT `fk_Cartao_Usuario1` FOREIGN KEY (`codUsuario`) REFERENCES `usuario` (`codUsuario`)
) ENGINE=InnoDB AUTO_INCREMENT=103 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `cartao`
--

LOCK TABLES `cartao` WRITE;
/*!40000 ALTER TABLE `cartao` DISABLE KEYS */;
INSERT INTO `cartao` VALUES (102,'1234567891236547','natan','2019-08-10',789,5);
/*!40000 ALTER TABLE `cartao` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `conta_bancaria`
--

DROP TABLE IF EXISTS `conta_bancaria`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `conta_bancaria` (
  `codConta` int(11) NOT NULL AUTO_INCREMENT,
  `numero` int(11) NOT NULL,
  `agencia` int(11) NOT NULL,
  `tipo` enum('Conta Corrente','Poupança') DEFAULT NULL,
  `codUsuario` int(11) NOT NULL,
  `codBanco` int(11) NOT NULL,
  PRIMARY KEY (`codConta`),
  KEY `fk_ContaBancaria_Usuario_idx` (`codUsuario`),
  KEY `fk_Conta_Bancaria_Banco1_idx` (`codBanco`),
  CONSTRAINT `fk_ContaBancaria_Usuario` FOREIGN KEY (`codUsuario`) REFERENCES `usuario` (`codUsuario`),
  CONSTRAINT `fk_Conta_Bancaria_Banco1` FOREIGN KEY (`codBanco`) REFERENCES `banco` (`codBanco`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `conta_bancaria`
--

LOCK TABLES `conta_bancaria` WRITE;
/*!40000 ALTER TABLE `conta_bancaria` DISABLE KEYS */;
INSERT INTO `conta_bancaria` VALUES (1,789546,5,'Conta Corrente',1,2);
/*!40000 ALTER TABLE `conta_bancaria` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `entrega`
--

DROP TABLE IF EXISTS `entrega`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `entrega` (
  `codEntrega` int(11) NOT NULL AUTO_INCREMENT,
  `origem` varchar(45) NOT NULL,
  `destino` varchar(45) NOT NULL,
  `data` date NOT NULL,
  `status` enum('solicitada','cancelada','atendida','em andamento') NOT NULL DEFAULT 'solicitada',
  `valor` float NOT NULL,
  `descricao_origem` varchar(300) NOT NULL,
  `descricao_destino` varchar(300) NOT NULL,
  `codUsuarioCliente` int(11) NOT NULL,
  `codUsuarioEntregador` int(11) DEFAULT NULL,
  PRIMARY KEY (`codEntrega`),
  KEY `fk_Corrida_Entrega_Usuario1_idx` (`codUsuarioCliente`),
  KEY `fk_Corrida_Entrega_Usuario2_idx` (`codUsuarioEntregador`),
  CONSTRAINT `fk_Corrida_Entrega_Usuario1` FOREIGN KEY (`codUsuarioCliente`) REFERENCES `usuario` (`codUsuario`),
  CONSTRAINT `fk_Corrida_Entrega_Usuario2` FOREIGN KEY (`codUsuarioEntregador`) REFERENCES `usuario` (`codUsuario`)
) ENGINE=InnoDB AUTO_INCREMENT=15 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `entrega`
--

LOCK TABLES `entrega` WRITE;
/*!40000 ALTER TABLE `entrega` DISABLE KEYS */;
INSERT INTO `entrega` VALUES (7,'rua s, numero 2','rua c, numero 50','2019-08-16','solicitada',0,'','',1,NULL),(10,'rua 1, numero 10','rua 2, numero 20','2019-08-25','em andamento',0,'','',1,NULL),(13,'rua prof lima jr, numero 438','av. olimpio campos, s/n','2019-08-25','atendida',0,'','',1,NULL);
/*!40000 ALTER TABLE `entrega` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `formaspagamento`
--

DROP TABLE IF EXISTS `formaspagamento`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `formaspagamento` (
  `codFormaPagamento` int(11) NOT NULL,
  `descricao` varchar(45) NOT NULL,
  PRIMARY KEY (`codFormaPagamento`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `formaspagamento`
--

LOCK TABLES `formaspagamento` WRITE;
/*!40000 ALTER TABLE `formaspagamento` DISABLE KEYS */;
/*!40000 ALTER TABLE `formaspagamento` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `formaspagamento_has_entrega`
--

DROP TABLE IF EXISTS `formaspagamento_has_entrega`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `formaspagamento_has_entrega` (
  `FormasPagamento_codFormaPagamento` int(11) NOT NULL,
  `Entrega_codCorrida_Entrega` int(11) NOT NULL,
  `valor` float NOT NULL,
  PRIMARY KEY (`FormasPagamento_codFormaPagamento`,`Entrega_codCorrida_Entrega`),
  KEY `fk_FormasPagamento_has_Entrega_Entrega1_idx` (`Entrega_codCorrida_Entrega`),
  KEY `fk_FormasPagamento_has_Entrega_FormasPagamento1_idx` (`FormasPagamento_codFormaPagamento`),
  CONSTRAINT `fk_FormasPagamento_has_Entrega_Entrega1` FOREIGN KEY (`Entrega_codCorrida_Entrega`) REFERENCES `entrega` (`codEntrega`),
  CONSTRAINT `fk_FormasPagamento_has_Entrega_FormasPagamento1` FOREIGN KEY (`FormasPagamento_codFormaPagamento`) REFERENCES `formaspagamento` (`codFormaPagamento`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `formaspagamento_has_entrega`
--

LOCK TABLES `formaspagamento_has_entrega` WRITE;
/*!40000 ALTER TABLE `formaspagamento_has_entrega` DISABLE KEYS */;
/*!40000 ALTER TABLE `formaspagamento_has_entrega` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `solicitacao_de_cadastro`
--

DROP TABLE IF EXISTS `solicitacao_de_cadastro`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `solicitacao_de_cadastro` (
  `codSolicitacao` int(11) NOT NULL AUTO_INCREMENT,
  `numRegistro` varchar(15) NOT NULL,
  `numCnh` varchar(15) NOT NULL,
  `dataNascimento` date NOT NULL,
  `status` enum('solicitada','aprovada','reprovada','em analise') NOT NULL DEFAULT 'solicitada',
  `codUsuarioEntregador` int(11) NOT NULL,
  `codUsuarioFuncionario` int(11) DEFAULT NULL,
  PRIMARY KEY (`codSolicitacao`),
  UNIQUE KEY `numCnh_UNIQUE` (`numCnh`),
  UNIQUE KEY `numRegistro_UNIQUE` (`numRegistro`),
  UNIQUE KEY `codSolicitacao_UNIQUE` (`codSolicitacao`),
  KEY `fk_Solicitacao_de_Cadastro_Usuario1_idx` (`codUsuarioEntregador`),
  KEY `fk_Solicitacao_de_Cadastro_Usuario2_idx` (`codUsuarioFuncionario`),
  CONSTRAINT `fk_Solicitacao_de_Cadastro_Usuario1` FOREIGN KEY (`codUsuarioEntregador`) REFERENCES `usuario` (`codUsuario`),
  CONSTRAINT `fk_Solicitacao_de_Cadastro_Usuario2` FOREIGN KEY (`codUsuarioFuncionario`) REFERENCES `usuario` (`codUsuario`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `solicitacao_de_cadastro`
--

LOCK TABLES `solicitacao_de_cadastro` WRITE;
/*!40000 ALTER TABLE `solicitacao_de_cadastro` DISABLE KEYS */;
/*!40000 ALTER TABLE `solicitacao_de_cadastro` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `usuario`
--

DROP TABLE IF EXISTS `usuario`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `usuario` (
  `codUsuario` int(11) NOT NULL AUTO_INCREMENT,
  `cpf` varchar(15) NOT NULL,
  `statusCliente` enum('online','offline','inativo') DEFAULT 'offline',
  `statusEntregador` enum('em analise','bloqueado','online','offline') DEFAULT 'offline',
  `aspnetusers_Id` varchar(767) NOT NULL,
  PRIMARY KEY (`codUsuario`),
  UNIQUE KEY `cpf_UNIQUE` (`cpf`),
  KEY `fk_usuario_aspnetusers1_idx` (`aspnetusers_Id`)
) ENGINE=InnoDB AUTO_INCREMENT=10 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `usuario`
--

LOCK TABLES `usuario` WRITE;
/*!40000 ALTER TABLE `usuario` DISABLE KEYS */;
INSERT INTO `usuario` VALUES (1,'06447692548',NULL,NULL,'1e43005d-fa18-4fae-a4f4-7775a9f1518f'),(5,'57438773515','offline','online','4f3515ca-5266-43bf-9a10-38eb3a0203eb'),(8,'78945612323','offline','offline','6e7c1c12-74f7-4de0-8db3-47e8db6d7ea7');
/*!40000 ALTER TABLE `usuario` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `usuario_veiculo`
--

DROP TABLE IF EXISTS `usuario_veiculo`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `usuario_veiculo` (
  `codUsuario` int(11) NOT NULL,
  `codVeiculo` int(11) NOT NULL,
  PRIMARY KEY (`codUsuario`,`codVeiculo`),
  KEY `fk_Usuario_has_Veiculo_Veiculo1_idx` (`codVeiculo`),
  KEY `fk_Usuario_has_Veiculo_Usuario1_idx` (`codUsuario`),
  CONSTRAINT `fk_Usuario_has_Veiculo_Usuario1` FOREIGN KEY (`codUsuario`) REFERENCES `usuario` (`codUsuario`),
  CONSTRAINT `fk_Usuario_has_Veiculo_Veiculo1` FOREIGN KEY (`codVeiculo`) REFERENCES `veiculo` (`codVeiculo`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `usuario_veiculo`
--

LOCK TABLES `usuario_veiculo` WRITE;
/*!40000 ALTER TABLE `usuario_veiculo` DISABLE KEYS */;
/*!40000 ALTER TABLE `usuario_veiculo` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `veiculo`
--

DROP TABLE IF EXISTS `veiculo`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `veiculo` (
  `codVeiculo` int(11) NOT NULL AUTO_INCREMENT,
  `categoria` varchar(20) NOT NULL,
  `placa` varchar(10) NOT NULL,
  `renavam` varchar(20) NOT NULL,
  `ano` int(11) NOT NULL,
  `status` enum('disponivel','bloqueado') NOT NULL DEFAULT 'bloqueado',
  `emUso` enum('Sim','Nao') DEFAULT NULL,
  `codDono` int(11) NOT NULL,
  PRIMARY KEY (`codVeiculo`),
  KEY `fk_Veiculo_Usuario1_idx` (`codDono`),
  CONSTRAINT `fk_Veiculo_Usuario1` FOREIGN KEY (`codDono`) REFERENCES `usuario` (`codUsuario`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `veiculo`
--

LOCK TABLES `veiculo` WRITE;
/*!40000 ALTER TABLE `veiculo` DISABLE KEYS */;
INSERT INTO `veiculo` VALUES (1,'carro','iae-8730','789546463',2010,'disponivel','Nao',1),(6,'carro','iae-8730','78654963',2019,'disponivel','Nao',1);
/*!40000 ALTER TABLE `veiculo` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2019-08-30 12:24:10
