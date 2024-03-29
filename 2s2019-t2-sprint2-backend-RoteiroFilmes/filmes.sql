CREATE DATABASE RoteiroFilmes;

USE RoteiroFilmes;

CREATE TABLE Generos 
(
    IdGenero    INT PRIMARY KEY IDENTITY
    ,Nome       VARCHAR(200) NOT NULL UNIQUE
);

insert into Generos(Nome)
values('Animacao'), ('Drama'), ('Comedia'), ('Romance');
select * from Generos;

CREATE TABLE Filmes
(
    IdFilme     INT PRIMARY KEY IDENTITY
    ,Titulo     VARCHAR(200) UNIQUE
    ,IdGenero   INT FOREIGN KEY REFERENCES Generos (IdGenero)
);

insert into Filmes(Titulo, IdGenero)
values ('Toturo', 13), ('Entrando numa fria', 15), ('Um lugar chamado Nothing Hills', 16), ('O Chamado', 1);
select * from Filmes;

select F.IdFilme, F.Titulo, F.IdGenero, G.IdGenero, G.Nome as NomeGenero
from Filmes as F
join Generos as G
on F.IdGenero = G.IdGenero;              
