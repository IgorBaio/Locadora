create database Locadora;
use Locadora;
create table Clientes(
	Id int NOT NULL identity(1,1) primary key,
	Nome VARCHAR(200) not null ,
	Cpf varchar(11) not null ,
	DataNascimento DateTime,
);

create table Filmes(
	Id int NOT NULL identity(1,1) primary key,
	Titulo VARCHAR(200) not null ,
	Lancamento Tinyint not null ,
	ClassificacaoIndicativa int
);

create table Locacao(
	Id int NOT NULL identity(1,1) primary key,
	IdFilme int NOT NULL FOREIGN KEY REFERENCES Filmes(Id),
	IdCliente int NOT NULL FOREIGN KEY REFERENCES Clientes(Id),
	DataLocacao DateTime,
	DataDevolucao DateTime,
	
);

