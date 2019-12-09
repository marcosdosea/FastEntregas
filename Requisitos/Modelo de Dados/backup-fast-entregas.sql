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
-- Table structure for table __efmigrationshistory
--

DROP TABLE IF EXISTS __efmigrationshistory;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE __efmigrationshistory (
  MigrationId varchar(150) NOT NULL,
  ProductVersion varchar(32) NOT NULL,
  PRIMARY KEY (MigrationId)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table __efmigrationshistory
--

LOCK TABLES __efmigrationshistory WRITE;
/*!40000 ALTER TABLE __efmigrationshistory DISABLE KEYS */;
INSERT INTO __efmigrationshistory VALUES ('00000000000000_CreateIdentitySchema','2.1.11-servicing-32099');
/*!40000 ALTER TABLE __efmigrationshistory ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table aspnetroleclaims
--

DROP TABLE IF EXISTS aspnetroleclaims;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE aspnetroleclaims (
  Id int(11) NOT NULL,
  RoleId varchar(767) NOT NULL,
  ClaimType text,
  ClaimValue text,
  PRIMARY KEY (Id),
  KEY IX_AspNetRoleClaims_RoleId (RoleId),
  CONSTRAINT FK_AspNetRoleClaims_AspNetRoles_RoleId FOREIGN KEY (RoleId) REFERENCES aspnetroles (Id) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table aspnetroleclaims
--

LOCK TABLES aspnetroleclaims WRITE;
/*!40000 ALTER TABLE aspnetroleclaims DISABLE KEYS */;
/*!40000 ALTER TABLE aspnetroleclaims ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table aspnetroles
--

DROP TABLE IF EXISTS aspnetroles;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE aspnetroles (
  Id varchar(767) NOT NULL,
  Name varchar(256) DEFAULT NULL,
  NormalizedName varchar(256) DEFAULT NULL,
  ConcurrencyStamp text,
  PRIMARY KEY (Id),
  UNIQUE KEY RoleNameIndex (NormalizedName)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table aspnetroles
--

LOCK TABLES aspnetroles WRITE;
/*!40000 ALTER TABLE aspnetroles DISABLE KEYS */;
INSERT INTO aspnetroles VALUES ('1','cliente','cliente',NULL),('2','entregador','entregador',NULL),('3','funcionario','funcionario',NULL);
/*!40000 ALTER TABLE aspnetroles ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table aspnetuserclaims
--

DROP TABLE IF EXISTS aspnetuserclaims;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE aspnetuserclaims (
  Id int(11) NOT NULL,
  UserId varchar(767) NOT NULL,
  ClaimType text,
  ClaimValue text,
  PRIMARY KEY (Id),
  KEY IX_AspNetUserClaims_UserId (UserId),
  CONSTRAINT FK_AspNetUserClaims_AspNetUsers_UserId FOREIGN KEY (UserId) REFERENCES aspnetusers (Id) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table aspnetuserclaims
--

LOCK TABLES aspnetuserclaims WRITE;
/*!40000 ALTER TABLE aspnetuserclaims DISABLE KEYS */;
/*!40000 ALTER TABLE aspnetuserclaims ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table aspnetuserlogins
--

DROP TABLE IF EXISTS aspnetuserlogins;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE aspnetuserlogins (
  LoginProvider varchar(128) NOT NULL,
  ProviderKey varchar(128) NOT NULL,
  ProviderDisplayName text,
  UserId varchar(767) NOT NULL,
  PRIMARY KEY (LoginProvider,ProviderKey),
  KEY IX_AspNetUserLogins_UserId (UserId),
  CONSTRAINT FK_AspNetUserLogins_AspNetUsers_UserId FOREIGN KEY (UserId) REFERENCES aspnetusers (Id) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table aspnetuserlogins
--

LOCK TABLES aspnetuserlogins WRITE;
/*!40000 ALTER TABLE aspnetuserlogins DISABLE KEYS */;
/*!40000 ALTER TABLE aspnetuserlogins ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table aspnetuserroles
--

DROP TABLE IF EXISTS aspnetuserroles;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE aspnetuserroles (
  UserId varchar(767) NOT NULL,
  RoleId varchar(767) NOT NULL,
  PRIMARY KEY (UserId,RoleId),
  KEY IX_AspNetUserRoles_RoleId (RoleId),
  CONSTRAINT FK_AspNetUserRoles_AspNetRoles_RoleId FOREIGN KEY (RoleId) REFERENCES aspnetroles (Id) ON DELETE CASCADE,
  CONSTRAINT FK_AspNetUserRoles_AspNetUsers_UserId FOREIGN KEY (UserId) REFERENCES aspnetusers (Id) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table aspnetuserroles
--

LOCK TABLES aspnetuserroles WRITE;
/*!40000 ALTER TABLE aspnetuserroles DISABLE KEYS */;
/*!40000 ALTER TABLE aspnetuserroles ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table aspnetusers
--

DROP TABLE IF EXISTS aspnetusers;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE aspnetusers (
  Id varchar(767) NOT NULL,
  UserName varchar(256) DEFAULT NULL,
  NormalizedUserName varchar(256) DEFAULT NULL,
  Email varchar(256) DEFAULT NULL,
  NormalizedEmail varchar(256) DEFAULT NULL,
  EmailConfirmed bit(1) NOT NULL,
  PasswordHash text,
  SecurityStamp text,
  ConcurrencyStamp text,
  PhoneNumber text,
  PhoneNumberConfirmed bit(1) NOT NULL,
  TwoFactorEnabled bit(1) NOT NULL,
  LockoutEnd timestamp NULL DEFAULT NULL,
  LockoutEnabled bit(1) NOT NULL,
  AccessFailedCount int(11) NOT NULL,
  PRIMARY KEY (Id),
  UNIQUE KEY UserNameIndex (NormalizedUserName),
  UNIQUE KEY Email_UNIQUE (Email),
  KEY EmailIndex (NormalizedEmail)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table aspnetusers
--

LOCK TABLES aspnetusers WRITE;
/*!40000 ALTER TABLE aspnetusers DISABLE KEYS */;
INSERT INTO aspnetusers VALUES ('0b654e48-51c6-4e88-95f9-89d8bbd6a6a7','lipe.dornelles@gmail.com','LIPE.DORNELLES@GMAIL.COM','lipe.dornelles@gmail.com','LIPE.DORNELLES@GMAIL.COM',_binary '\0','AQAAAAEAACcQAAAAEAW8iunIcGaxjiSHNnhzCdOchGL63qddBYFofCN6fSg+xeyINVQ0xYMQCUTIM8yR5w==','B4G257YQLSGLM7QUV6ITCV7KZXKMHBSY','fc30906c-f214-4c6b-9520-4938795dc766','79991194510',_binary '\0',_binary '\0',NULL,_binary '',0),('2b60d89b-b529-43d5-a8c7-73b501f6b586','h@hotmail.com','H@HOTMAIL.COM','h@hotmail.com','H@HOTMAIL.COM',_binary '\0','AQAAAAEAACcQAAAAELKn//3zYyKMmCgxj4xV/pFQxnGSe2GXzqV+Jshe4FF2sU7fIZ3cMBhS8F9UUDwc2g==','N2TC6CWMWHB6IZI7MCJHEWQBIVGFSCT2','1d0a924e-cd13-417b-af42-976a6d3d6124','79991341771',_binary '\0',_binary '\0',NULL,_binary '',0),('65205194-d0c4-44bd-a897-bbe6b9e942d0','exemplo@exemplo.com','EXEMPLO@EXEMPLO.COM','exemplo@exemplo.com','EXEMPLO@EXEMPLO.COM',_binary '\0','AQAAAAEAACcQAAAAEBkoIoYI8FXxYhvd0mYoInxN+7mVRcWxsl5b1716YKFIBlZorsNGBa8iCsIAocIgfw==','RVDYFQCGH5SMSIZGXT3HBKSJH7XB5BU4','f5f34437-63dd-43f5-a783-5f554a656941','79999999999',_binary '\0',_binary '\0',NULL,_binary '',0),('7787915a-af05-47d0-8498-2139ecde7044','dornelles','DORNELLES','lipe.dornelles@hotmail.com','LIPE.DORNELLES@HOTMAIL.COM',_binary '\0','AQAAAAEAACcQAAAAEFekk+SAzR9q/US1kEzXkVq1bGdWYFeOfcitK1zgt9BHa6cFdYXexrjA6oAfnaIGVA==','UYKNBBXM2PFTFQACXUV5AAJB7ZCLUXUX','318a6b61-1dc8-4097-b52f-c41d06cb15e7','79991194510',_binary '\0',_binary '\0',NULL,_binary '',0),('7a012149-ae8f-416f-a849-fabc2ec996f8','dornelles@gmail.com','DORNELLES@GMAIL.COM','dornelles@gmail.com','DORNELLES@GMAIL.COM',_binary '\0','AQAAAAEAACcQAAAAEP+nXIrUDXA1rFjZoc61PPfo0ZKPzsKfmOOL1DM/lgDPlVCPAPbLZRs1o10TtRqPjQ==','HUER5WAMLOPZ27EQ7YEGJFPFVHHD4ISU','4c9d4cc0-9add-4325-ab36-2497c678025c','79913578415',_binary '\0',_binary '\0',NULL,_binary '',0),('a12c27fd-dc9d-4519-b3be-66feea9cfce5','Hamilton','HAMILTON','h.s.teles@hotmail.com','H.S.TELES@HOTMAIL.COM',_binary '\0','AQAAAAEAACcQAAAAEIuASEjAjfstsaANcgIGhKoNjVcEtkspgQJDUKiZt2WOF2TCcqcaTXVkxJdgXdyghg==','VUF5SW6H3JOD32QG3WGAP67KUBZM4LSP','338bb32c-8aad-45f9-b956-7f8bc5ca7dff','+5579991341771',_binary '\0',_binary '\0',NULL,_binary '',0),('a7144e61-6fce-4a35-8aaf-0abccb302161','felipeDornelles','FELIPEDORNELLES','h.s.tles@hotmail.com','H.S.TLES@HOTMAIL.COM',_binary '\0','AQAAAAEAACcQAAAAEEugiUOHvd2P9xfuCT5BIz6OF10Ho9eAq/wIXfUThl8PTY2oL8MTtQVCbVuOJk9Ybw==','WNQXIJXAQE7PXZ6NDVZ62MUNVF3OPXE5','fab37b39-8b83-47a4-a209-c8394db35c18','79991194510',_binary '\0',_binary '\0',NULL,_binary '',0),('b9747014-1be0-4aee-9a61-0ef06c721bb7','test','TEST','emailvalido@email.com','EMAILVALIDO@EMAIL.COM',_binary '\0','AQAAAAEAACcQAAAAEPbPzO/eQemAnJI22JNhimaH2FFzigkkWS1HHg4lCAgN4PUrwP3aktSyoOuh74Bwhw==','TW7YZNPZL3OK2BRA2E3SUYLXBGMKWYKL','ebd698b2-6c3a-4ce1-9202-58b489223e7f','79 970707070',_binary '\0',_binary '\0',NULL,_binary '',0),('c2476ab9-81d8-49f7-8d48-2c505aa896b9','felipe','FELIPE','carmeluce@hotmail.com','CARMELUCE@HOTMAIL.COM',_binary '\0','AQAAAAEAACcQAAAAEL2bU7FbwJjMm51aCboBDRh9Sf7gd+0RK0YWjDNabIMQf1oQ81/Ya5m6bWUAODRRfQ==','DNO4YDRVV5UDU3MEJSB3ZAJCO7PXKW3U','adeff41b-b450-4cc8-b351-6eea6b151ded','79991194510',_binary '\0',_binary '\0',NULL,_binary '',0),('e770c443-bc9d-4615-9358-590dd39f1d97','lipe@gmail.com','LIPE@GMAIL.COM','lipe@gmail.com','LIPE@GMAIL.COM',_binary '\0','AQAAAAEAACcQAAAAEBHhDXacG1EHhrbtTDSrNvosdeg6fy0VyMP+d6nDTViKVkyVPSHtl/oj25EgSxfLVw==','A4V5KJSXMX6HFYRHX6NQGRXYOB4GVX2L','bce9ebd6-e42b-4b04-8059-94823f97798e','79999999999',_binary '\0',_binary '\0',NULL,_binary '',0);
/*!40000 ALTER TABLE aspnetusers ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table aspnetusertokens
--

DROP TABLE IF EXISTS aspnetusertokens;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE aspnetusertokens (
  UserId varchar(767) NOT NULL,
  LoginProvider varchar(128) NOT NULL,
  Name varchar(128) NOT NULL,
  Value text,
  PRIMARY KEY (UserId,LoginProvider,Name),
  CONSTRAINT FK_AspNetUserTokens_AspNetUsers_UserId FOREIGN KEY (UserId) REFERENCES aspnetusers (Id) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table aspnetusertokens
--

LOCK TABLES aspnetusertokens WRITE;
/*!40000 ALTER TABLE aspnetusertokens DISABLE KEYS */;
/*!40000 ALTER TABLE aspnetusertokens ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table tbbanco
--

DROP TABLE IF EXISTS tbbanco;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE tbbanco (
  codBanco int(11) NOT NULL AUTO_INCREMENT,
  nome varchar(45) NOT NULL,
  PRIMARY KEY (codBanco)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table tbbanco
--

LOCK TABLES tbbanco WRITE;
/*!40000 ALTER TABLE tbbanco DISABLE KEYS */;
INSERT INTO tbbanco VALUES (1,'Banco do Brasil'),(2,'Bradesco'),(3,'Santander'),(4,'Itaú'),(5,'Banese'),(6,'Caixa');
/*!40000 ALTER TABLE tbbanco ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table tbcartao
--

DROP TABLE IF EXISTS tbcartao;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE tbcartao (
  codCartao int(11) NOT NULL AUTO_INCREMENT,
  numero varchar(20) DEFAULT NULL,
  nomeDono varchar(50) NOT NULL,
  dataValidade varchar(10) NOT NULL,
  cvv int(11) NOT NULL,
  codUsuario int(11) NOT NULL,
  PRIMARY KEY (codCartao),
  KEY fk_Cartao_Usuario1_idx (codUsuario),
  CONSTRAINT fk_Cartao_Usuario1 FOREIGN KEY (codUsuario) REFERENCES tbusuario (codUsuario)
) ENGINE=InnoDB AUTO_INCREMENT=103 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table tbcartao
--

LOCK TABLES tbcartao WRITE;
/*!40000 ALTER TABLE tbcartao DISABLE KEYS */;
INSERT INTO tbcartao VALUES (102,'1234567891236547','natan','2019-08-10',789,5);
/*!40000 ALTER TABLE tbcartao ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table tbconta_bancaria
--

DROP TABLE IF EXISTS tbconta_bancaria;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE tbconta_bancaria (
  codConta int(11) NOT NULL AUTO_INCREMENT,
  numero int(11) NOT NULL,
  agencia int(11) NOT NULL,
  tipo enum('Conta Corrente','Poupança') DEFAULT NULL,
  codUsuario int(11) NOT NULL,
  codBanco int(11) NOT NULL,
  PRIMARY KEY (codConta),
  KEY fk_ContaBancaria_Usuario_idx (codUsuario),
  KEY fk_Conta_Bancaria_Banco1_idx (codBanco),
  CONSTRAINT fk_ContaBancaria_Usuario FOREIGN KEY (codUsuario) REFERENCES tbusuario (codUsuario),
  CONSTRAINT fk_Conta_Bancaria_Banco1 FOREIGN KEY (codBanco) REFERENCES tbbanco (codBanco)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table tbconta_bancaria
--

LOCK TABLES tbconta_bancaria WRITE;
/*!40000 ALTER TABLE tbconta_bancaria DISABLE KEYS */;
INSERT INTO tbconta_bancaria VALUES (1,789546,5,'Conta Corrente',1,2);
/*!40000 ALTER TABLE tbconta_bancaria ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table tbentrega
--

DROP TABLE IF EXISTS tbentrega;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE tbentrega (
  codEntrega int(11) NOT NULL AUTO_INCREMENT,
  origem varchar(500) DEFAULT NULL,
  destino varchar(500) DEFAULT NULL,
  data date NOT NULL,
  status enum('solicitada','cancelada','atendida','em andamento') NOT NULL DEFAULT 'solicitada',
  valor float NOT NULL,
  descricao_origem varchar(300) NOT NULL,
  descricao_destino varchar(300) NOT NULL,
  codUsuarioCliente int(11) NOT NULL,
  codUsuarioEntregador int(11) DEFAULT NULL,
  duracao varchar(10) DEFAULT NULL,
  distancia varchar(10) DEFAULT NULL,
  codVeiculo int(11) DEFAULT NULL,
  categoriaVeiculo varchar(30) DEFAULT NULL,
  PRIMARY KEY (codEntrega),
  KEY fk_Corrida_Entrega_Usuario1_idx (codUsuarioCliente),
  KEY fk_Corrida_Entrega_Usuario2_idx (codUsuarioEntregador),
  KEY codVeiculo (codVeiculo),
  CONSTRAINT fk_Corrida_Entrega_Usuario1 FOREIGN KEY (codUsuarioCliente) REFERENCES tbusuario (codUsuario),
  CONSTRAINT fk_Corrida_Entrega_Usuario2 FOREIGN KEY (codUsuarioEntregador) REFERENCES tbusuario (codUsuario),
  CONSTRAINT tbentrega_ibfk_1 FOREIGN KEY (codVeiculo) REFERENCES tbveiculo (codVeiculo),
  CONSTRAINT tbentrega_ibfk_2 FOREIGN KEY (codVeiculo) REFERENCES tbveiculo (codVeiculo)
) ENGINE=InnoDB AUTO_INCREMENT=46 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table tbentrega
--

LOCK TABLES tbentrega WRITE;
/*!40000 ALTER TABLE tbentrega DISABLE KEYS */;
INSERT INTO tbentrega VALUES (29,'Rua Pericles Vieira De Azevedo 485, Coroa Do Meio, Aracaju - Sergipe, 49036, Brazil','Rua Manoel Andrade 2279, Coroa Do Meio, Aracaju - Sergipe, 49035, Brazil','2019-09-05','solicitada',450,'sdfsdfsdf','ghjghjghj',1,NULL,'1min','0.46km',NULL,NULL),(30,'Rua Professor Lima Junior 438, Centro, Itabaiana - Sergipe, 49503, Brazil','UFS - Universidade Federal de Sergipe, Av. Ver Olimpio Grande, Itabaiana, Sergipe 49500, Brazil','2019-09-05','solicitada',450,'sdfsdfsdf','ghjghjghj',1,NULL,'1min','0.60km',NULL,NULL),(31,'Rua Pericles Vieira De Azevedo 485, Coroa Do Meio, Aracaju - Sergipe, 49036, Brazil','Shopping Jardins, Av. Min. Geraldo Barreto Sobral, 215, Aracaju, Sergipe 49025, Brazil','2019-09-05','solicitada',1192,'sdfsdfsdf','ghjghjghj',1,NULL,'12min','5.96km',NULL,NULL),(32,'Rua Pericles Vieira De Azevedo, Coroa Do Meio, Aracaju - Sergipe, 49036, Brazil','Rua Manoel Andrade 2279, Coroa Do Meio, Aracaju - Sergipe, 49035, Brazil','2019-09-08','solicitada',450,'sdfsdfsdf','ghjghjghj',1,NULL,'1min','0.37km',NULL,'Carro'),(33,'Shopping Jardins, Av. Min. Geraldo Barreto Sobral, 215, Aracaju, Sergipe 49025, Brazil','Colégio Jardins, Av. Min Geraldo Barreto Sobral, Aracaju, Sergipe 49025, Brazil','2019-09-08','solicitada',450,'sdfsdfsdf','ghjghjghj',13,NULL,'5min','1.63km',NULL,'Moto'),(34,'Rua Pericles Vieira De Azevedo 485, Coroa Do Meio, Aracaju - Sergipe, 49036, Brazil','Rua Manoel Andrade 2279, Coroa Do Meio, Aracaju - Sergipe, 49035, Brazil','2019-09-09','solicitada',450,'sdfsdfsdf','ghjghjghj',15,NULL,'1min','0.46km',NULL,'Carro'),(35,'Rua Pericles Vieira De Azevedo 485, Coroa Do Meio, Aracaju - Sergipe, 49036, Brazil','Shopping Jardins, Av. Min. Geraldo Barreto Sobral, 215, Aracaju, Sergipe 49025, Brazil','2019-09-09','solicitada',1192,'PEGAR DOCUMENTO COM fELIPE','Entregar na recepção a Natan',16,NULL,'11min','5.96km',NULL,'Moto'),(36,'','','2018-09-05','solicitada',450,'','',1,NULL,NULL,NULL,NULL,NULL),(37,'','','2018-10-05','solicitada',450,'','',1,NULL,NULL,NULL,NULL,NULL),(38,'','','2018-09-05','solicitada',450,'','',1,NULL,NULL,NULL,NULL,NULL),(39,'Shopping Jardins, Av. Min. Geraldo Barreto Sobral, 215, Aracaju, Sergipe 49025, Brazil','UFS - Universidade Federal de Sergipe, Av. Mal. Rondon, S/N, São Cristóvão, Sergipe 49088, Brazil','2019-09-10','solicitada',2440,'sdfsdfsdf','ghjghjghj',15,NULL,'26min','12.2km',NULL,'Carro'),(40,'Rua Manoel Andrade 2279, Coroa Do Meio, Aracaju - Sergipe, 49035, Brazil','Colégio Jardins, Av. Min Geraldo Barreto Sobral, Aracaju, Sergipe 49025, Brazil','2019-09-10','solicitada',1050,'sdfsdfsdf','ghjghjghj',15,NULL,'10min','5.25km',NULL,'Carro'),(41,'Shopping Jardins, Av. Min. Geraldo Barreto Sobral, 215, Aracaju, Sergipe 49025, Brazil','UFS - Universidade Federal de Sergipe, Av. Mal. Rondon, S/N, São Cristóvão, Sergipe 49088, Brazil','2019-09-10','solicitada',2440,'sdfsdfsdf','ghjghjghj',15,NULL,'24min','12.2km',NULL,'Carro'),(42,'UFS - Universidade Federal de Sergipe, Av. Mal. Rondon, S/N, São Cristóvão, Sergipe 49088, Brazil','Shopping Jardins, Av. Min. Geraldo Barreto Sobral, 215, Aracaju, Sergipe 49025, Brazil','2019-09-10','solicitada',1636,'sdfsdfsdf','ghjghjghj',15,NULL,'17min','8.18km',NULL,'Carro'),(43,'Rua Pericles Vieira De Azevedo 485, Coroa Do Meio, Aracaju - Sergipe, 49036, Brazil','Shopping Jardins, Av. Min. Geraldo Barreto Sobral, 215, Aracaju, Sergipe 49025, Brazil','2019-09-11','solicitada',1192,'Pegar Documento com Felipe','Entregar na recepção a Natan',15,NULL,'12min','5.96km',NULL,'Carro'),(44,'UFS - Universidade Federal de Sergipe, Av. Mal. Rondon, S/N, São Cristóvão, Sergipe 49088, Brazil','Shopping Jardins, Av. Min. Geraldo Barreto Sobral, 215, Aracaju, Sergipe 49025, Brazil','2019-09-11','solicitada',1636,'Pegar malote na reitoria','Entregar ao secretário do shopping',20,NULL,'20min','8.18km',NULL,'Carro'),(45,'Shopping Jardins, Av. Min. Geraldo Barreto Sobral, 215, Aracaju, Sergipe 49025, Brazil','UFS - Universidade Federal de Sergipe, Av. Mal. Rondon, S/N, São Cristóvão, Sergipe 49088, Brazil','2019-09-11','solicitada',2560,'Pegar Malote com o secretario do shoping','Entregar na reitoria',20,NULL,'28min','12.8km',NULL,'Moto');
/*!40000 ALTER TABLE tbentrega ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table tbformaspagamento
--

DROP TABLE IF EXISTS tbformaspagamento;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE tbformaspagamento (
  codFormaPagamento int(11) NOT NULL,
  descricao varchar(45) NOT NULL,
  PRIMARY KEY (codFormaPagamento)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table tbformaspagamento
--

LOCK TABLES tbformaspagamento WRITE;
/*!40000 ALTER TABLE tbformaspagamento DISABLE KEYS */;
INSERT INTO tbformaspagamento VALUES (1,'Dinheiro'),(2,'Cartão de Crédito');
/*!40000 ALTER TABLE tbformaspagamento ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table tbformaspagamento_has_entrega
--

DROP TABLE IF EXISTS tbformaspagamento_has_entrega;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE tbformaspagamento_has_entrega (
  FormasPagamento_codFormaPagamento int(11) NOT NULL,
  Entrega_codCorrida_Entrega int(11) NOT NULL,
  valor float NOT NULL,
  PRIMARY KEY (FormasPagamento_codFormaPagamento,Entrega_codCorrida_Entrega),
  KEY fk_FormasPagamento_has_Entrega_Entrega1_idx (Entrega_codCorrida_Entrega),
  KEY fk_FormasPagamento_has_Entrega_FormasPagamento1_idx (FormasPagamento_codFormaPagamento),
  CONSTRAINT fk_FormasPagamento_has_Entrega_Entrega1 FOREIGN KEY (Entrega_codCorrida_Entrega) REFERENCES tbentrega (codEntrega),
  CONSTRAINT fk_FormasPagamento_has_Entrega_FormasPagamento1 FOREIGN KEY (FormasPagamento_codFormaPagamento) REFERENCES tbformaspagamento (codFormaPagamento)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table tbformaspagamento_has_entrega
--

LOCK TABLES tbformaspagamento_has_entrega WRITE;
/*!40000 ALTER TABLE tbformaspagamento_has_entrega DISABLE KEYS */;
INSERT INTO tbformaspagamento_has_entrega VALUES (1,39,0),(1,40,0),(1,42,0),(1,43,0),(1,44,0),(1,45,0),(2,41,0);
/*!40000 ALTER TABLE tbformaspagamento_has_entrega ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table tbsolicitacao_de_cadastro
--

DROP TABLE IF EXISTS tbsolicitacao_de_cadastro;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE tbsolicitacao_de_cadastro (
  codSolicitacao int(11) NOT NULL AUTO_INCREMENT,
  numRegistro varchar(15) NOT NULL,
  numCnh varchar(15) NOT NULL,
  dataNascimento date NOT NULL,
  status enum('solicitada','aprovada','reprovada','em analise') NOT NULL DEFAULT 'solicitada',
  codUsuarioEntregador int(11) NOT NULL,
  codUsuarioFuncionario int(11) DEFAULT NULL,
  PRIMARY KEY (codSolicitacao),
  UNIQUE KEY numCnh_UNIQUE (numCnh),
  UNIQUE KEY numRegistro_UNIQUE (numRegistro),
  UNIQUE KEY codSolicitacao_UNIQUE (codSolicitacao),
  KEY fk_Solicitacao_de_Cadastro_Usuario1_idx (codUsuarioEntregador),
  KEY fk_Solicitacao_de_Cadastro_Usuario2_idx (codUsuarioFuncionario),
  CONSTRAINT fk_Solicitacao_de_Cadastro_Usuario1 FOREIGN KEY (codUsuarioEntregador) REFERENCES tbusuario (codUsuario),
  CONSTRAINT fk_Solicitacao_de_Cadastro_Usuario2 FOREIGN KEY (codUsuarioFuncionario) REFERENCES tbusuario (codUsuario)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table tbsolicitacao_de_cadastro
--

LOCK TABLES tbsolicitacao_de_cadastro WRITE;
/*!40000 ALTER TABLE tbsolicitacao_de_cadastro DISABLE KEYS */;
INSERT INTO tbsolicitacao_de_cadastro VALUES (1,'06776096988','1557101985','1997-10-08','solicitada',13,NULL),(3,'06776096987','1557101981','1997-10-08','solicitada',16,NULL),(4,'06776096985','1557101980','1997-10-08','solicitada',15,NULL),(5,'06776096984','1557101986','1997-10-08','solicitada',17,NULL),(6,'0257469852147','2587469254','1997-10-08','solicitada',20,NULL);
/*!40000 ALTER TABLE tbsolicitacao_de_cadastro ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table tbusuario
--

DROP TABLE IF EXISTS tbusuario;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE tbusuario (
  codUsuario int(11) NOT NULL AUTO_INCREMENT,
  cpf varchar(15) NOT NULL,
  statusCliente enum('online','offline','inativo') DEFAULT 'offline',
  statusEntregador enum('em analise','bloqueado','online','offline') DEFAULT 'offline',
  userName varchar(256) DEFAULT NULL,
  PRIMARY KEY (codUsuario),
  UNIQUE KEY cpf_UNIQUE (cpf)
) ENGINE=InnoDB AUTO_INCREMENT=22 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table tbusuario
--

LOCK TABLES tbusuario WRITE;
/*!40000 ALTER TABLE tbusuario DISABLE KEYS */;
INSERT INTO tbusuario VALUES (1,'06447692548',NULL,NULL,NULL),(5,'57438773515','offline','online',NULL),(8,'78945612323','offline','offline',NULL),(10,'07162756514','offline','offline','dornelles'),(11,'0103024925','offline','offline','Hamilton'),(13,'0103024924','offline','offline','felipe'),(15,'0103024928','offline','offline','lipe.dornelles@gmail.com'),(16,'0103024920','offline','offline','felipeDornelles'),(17,'07162756510','offline','offline','h@hotmail.com'),(18,'1234567890258','offline','offline','exemplo@exemplo.com'),(19,'999999999999','offline','offline','lipe@gmail.com'),(20,'078514258745','offline','offline','dornelles@gmail.com'),(21,'1234567890123','offline','offline','test');
/*!40000 ALTER TABLE tbusuario ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table tbusuario_veiculo
--

DROP TABLE IF EXISTS tbusuario_veiculo;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE tbusuario_veiculo (
  codUsuario int(11) NOT NULL,
  codVeiculo int(11) NOT NULL,
  PRIMARY KEY (codUsuario,codVeiculo),
  KEY fk_Usuario_has_Veiculo_Veiculo1_idx (codVeiculo),
  KEY fk_Usuario_has_Veiculo_Usuario1_idx (codUsuario),
  CONSTRAINT fk_Usuario_has_Veiculo_Usuario1 FOREIGN KEY (codUsuario) REFERENCES tbusuario (codUsuario),
  CONSTRAINT fk_Usuario_has_Veiculo_Veiculo1 FOREIGN KEY (codVeiculo) REFERENCES tbveiculo (codVeiculo)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table tbusuario_veiculo
--

LOCK TABLES tbusuario_veiculo WRITE;
/*!40000 ALTER TABLE tbusuario_veiculo DISABLE KEYS */;
/*!40000 ALTER TABLE tbusuario_veiculo ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table tbveiculo
--

DROP TABLE IF EXISTS tbveiculo;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE tbveiculo (
  codVeiculo int(11) NOT NULL AUTO_INCREMENT,
  categoria varchar(20) NOT NULL,
  placa varchar(10) NOT NULL,
  renavam varchar(20) NOT NULL,
  ano int(11) NOT NULL,
  status enum('disponivel','bloqueado') NOT NULL DEFAULT 'bloqueado',
  emUso enum('Sim','Nao') DEFAULT NULL,
  codDono int(11) NOT NULL,
  PRIMARY KEY (codVeiculo),
  KEY fk_Veiculo_Usuario1_idx (codDono),
  CONSTRAINT fk_Veiculo_Usuario1 FOREIGN KEY (codDono) REFERENCES tbusuario (codUsuario)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table tbveiculo
--

LOCK TABLES tbveiculo WRITE;
/*!40000 ALTER TABLE tbveiculo DISABLE KEYS */;
INSERT INTO tbveiculo VALUES (1,'carro','iae-8730','789546463',2010,'disponivel','Nao',1),(6,'carro','iae-8730','78654963',2019,'disponivel','Nao',1);
/*!40000 ALTER TABLE tbveiculo ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping events for database 'fast_entregas'
--

--
-- Dumping routines for database 'fast_entregas'
--
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2019-12-06 15:36:04
