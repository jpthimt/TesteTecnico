create database teste_tecnico;
use teste_tecnico;

create table Usuarios(
	id int identity(1,1) primary key,
	nome varchar(50),
	email varchar(50),
	senha varchar(50)
);