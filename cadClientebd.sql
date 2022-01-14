create database cadClientebd;

use cadClientebd;

create table cliente (
   codigo int primary key not null auto_increment, 
   nome varchar(60) not null,
   cpf varchar(14) not null,
   cep varchar(9) not null,
   endereco varchar(60) not null,
   numero int not null,
   Complemento varchar(45),
   Telefone varchar(15) not null
   );  
   
select * from cliente; 

/* OU */
SELECT * FROM cadClientebd.cliente;