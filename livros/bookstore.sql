CREATE DATABASE M_BookStore;


USE M_BookStore;


CREATE TABLE Generos
(
    IdGenero    INT PRIMARY KEY IDENTITY
    ,Descricao  VARCHAR(200) NOT NULL UNIQUE
);

CREATE TABLE Autores 
(
    IdAutor             INT PRIMARY KEY IDENTITY
    ,Nome               VARCHAR(200)
    ,Email              VARCHAR(255) UNIQUE
    ,Ativo              BIT DEFAULT(1) -- BIT/CHAR
    ,DataNascimento     DATE
);


CREATE TABLE Livros
(
    IdLivro             INT PRIMARY KEY IDENTITY
    ,Descricao          VARCHAR(255) NOT NULL UNIQUE
    ,IdAutor            INT FOREIGN KEY REFERENCES Autores (IdAutor)
    ,IdGenero           INT FOREIGN KEY REFERENCES Generos (IdGenero)
);


/*DML*/

insert into Generos (Descricao)
values ('Romance'), ('Suspense'), ('AutoAjuda');

insert into Autores (Nome, Email, Ativo, DataNascimento)
values	('Chapman',			  'ch@email.com', 1, '1970-08-10'), 
		('Érico Veríssimo',	  'ev@email.com', 0, '1930-07-01'), 
		('Clarice Lispector', 'cl@email.com', 0, '1910-05-16');

insert into Livros (Descricao, IdAutor, IdGenero)
values	('As cinco linguagens do amor', 1, 3),
		('Saga',						2, 2),
		('A hora da estrela',			3, 1);

select * from Generos;
select * from Autores;

select L.IdLivro, L.Descricao, L.IdAutor, L.IdGenero, G.IdGenero, G.Descricao as DescricaoGenero, A.IdAutor, A.Nome, A.Email, A.Ativo, A.DataNascimento 
from  Generos as G
join Livros as L
on L.IdGenero = G.IdGenero
join Autores as A
on L.IdAutor = A.IdAutor;