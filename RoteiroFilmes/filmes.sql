CREATE DATABASE RoteiroFilmes;

USE RoteiroFilmes;

CREATE TABLE Generos 
(
    IdGenero    INT PRIMARY KEY IDENTITY
    ,Nome       VARCHAR(200) NOT NULL UNIQUE
);

insert into Generos(Nome)
values('Animacao'), ('Drama'), ('Comedia'), ('Romance'), ('Terror');
select * from Generos;

CREATE TABLE Filmes
(
    IdFilme     INT PRIMARY KEY IDENTITY
    ,Titulo     VARCHAR(200) UNIQUE
    ,IdGenero   INT FOREIGN KEY REFERENCES Generos (IdGenero)
);

insert into Filmes(Titulo, IdGenero)
values ('Toturo', 1), ('Entrando numa fria', 3), ('Um lugar chamado Nothing Hills', 4), ('O Chamado', 5);
select * from Filmes;

select Filmes.*, Generos.*
from Filmes
join Generos
on Filmes.IdGenero = Generos.IdGenero;
