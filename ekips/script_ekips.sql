Create Database M_Ekips;

Use M_Ekips;

/*DDL - Criando Tabelas*/

Create Table Departamentos
(	
	IdDepartamento int primary key identity
	, Nome varchar(255) not null unique
);

/*Drop table Departamento;*/

Create Table Cargos
(
	IdCargo int primary key identity
	, Nome varchar(255) not null unique
);

Create Table Usuarios
(
	IdUsuario int primary key identity
	, Email varchar(255) not null 
	, Senha varchar(255) not null 
	, Permissao varchar(255) not null 
);

Create Table Funcionarios
(
	IdFuncionario int primary key identity
	, Nome varchar(255) not null 
	, CPF int 
	, DataNascimento Date
	, Salario float
	, IdDepartamento int foreign key references Departamentos (IdDepartamento)
	, IdCargo int foreign key references Cargos (IdCargo)
	, IdUsuario int foreign key references Usuarios (IdUsuario)	
);

/*DML*/

insert into Departamentos(Nome)
values ('Jurídico'), ('Tecnologia'), ('Administrador');

insert into Cargos(Nome)
values ('Advogado Trabalhista'), ('Product Owner'), ('Product Manager'), ('Developer'), ('Gerente');

insert into Usuarios(Email, Senha, Permissao)
values	('bob@email.com',		'123456', 'COMUM') 
		, ('fernando@email.com','123456', 'COMUM')
		, ('Helena@email.com',  '123456', 'ADMINISTRADOR')
		, ('ERIK@email.com',	'123456', 'ADMINISTRADOR');

insert into Funcionarios(Nome, CPF, DataNascimento, Salario, IdDepartamento, IdCargo, IdUsuario)
values	 ('Bob',		321, '2000-12-01', 1785.00, 1, 1, 1)
		,('Fernando',	322, '2000-10-07', 2540.00, 2, 2, 2)
		,('Helena',		323, '2000-01-06', 5400.00, 2, 3, 3)
		,('Erik',		324, '2000-01-17', 8800.00, 3, 4, 4);

/*DQL*/
select * from Departamentos;
select * from Cargos;
select * from Usuarios;

select  F.IdFuncionario, F.Nome, F.CPF, F.DataNascimento,  F.Salario, F.IdCargo, F.IdDepartamento, F.IdUsuario, D.IdDepartamento, D.Nome, C.IdCargo, C.Nome, U.IdUsuario, U.Email, U.Permissao
from Departamentos as D
join Funcionarios as F
on F.IdDepartamento = D.IdDepartamento
join Cargos as C
on C.IdCargo = F.IdCargo
join Usuarios as U
on U.IdUsuario = F.IdUsuario


