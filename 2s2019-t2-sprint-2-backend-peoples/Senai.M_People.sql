/*Script 01 : criar o banco de dados M_Peoples*/ 

Create Database M_Peoples;

Use M_Peoples;

/*Criar Tabela de Funcionarios contendo nome e sobrenome;*/

Create Table Funcionarios

(
	IdNome int primary key identity
	, Nome varchar(200) not null
	, Sobrenome varchar(255) not null
);

/*inserir os funcionários Catarina Strada e 
Tadeu Vitelli com os sobrenomes*/

insert into Funcionarios(Nome, Sobrenome) 
values ('Catarina', 'Strada'), ('Tadeu', 'Vitelli');

/*selecionar todos os registros*/
select * from Funcionarios;


/* Incluir data de nascimento para os funcionários*/
ALTER TABLE Funcionarios
ADD DataNascimento Date;

UPDATE Funcionarios
SET DataNascimento = '2000-01-01'
WHERE IdNome=3;

UPDATE Funcionarios
SET DataNascimento = '2000-05-12'
WHERE IdNome=2;
