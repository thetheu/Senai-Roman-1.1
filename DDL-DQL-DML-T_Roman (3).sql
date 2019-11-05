create database T_Roman

use T_Roman

create table Professores 
(
	IdProfessor int primary key identity,
	Nome varchar(255) not null
)


create table Temas 
(
	IdTema int primary key identity,
	Nome varchar(255) not null
)

create table Projetos 
(
	IdProjeto int primary key identity,
	Nome varchar(255) not null,
	IdProfessor int foreign key references Professores (IdProfessor),
	IdTema int foreign key references Temas (IdTema)
)




--===================================================DML====================================================================

insert into Professores (Nome) values ('Helena')
									 ,('EricK')
									 ,('Gabriel')



insert into Temas (Nome) values ('Tema de Gestão')
							   ,('Tema De HQ')	
							   ,('Tema de Hamburgueria')


insert into Projetos(Nome, IdProfessor, IdTema) values ('McBonals', 4,3)
													  ,('Marvel', 2,2)
													  ,('Ponto Digital',1,1)


--=======================================================DQL=========================================================================


select * from Projetos

select * from Temas

select * from Professores

alter table Professores add Email varchar(255) not null default('Senai@senaisp.org.br')

alter table Professores add Senha varchar(255) not null default(123456)

alter table Professores add Tipo varchar(255) not null default('Professor(a)')
