--criar o banco
CREATE DATABASE CursoRenatoGava;

--usar o banco
USE CursoRenatoGava;

--criar tabela usuario
CREATE TABLE Usuario(
	id INT NOT NULL AUTO_INCREMENT,
	nome VARCHAR(50) NOT NULL,
	sobrenome VARCHAR(150) NOT NULL,
	telefone VARCHAR(15) NOT NULL,
	email VARCHAR(50) NOT NULL,
	genero VARCHAR(20) NOT NULL,
	senha VARCHAR(30) NOT NULL,
	PRIMARY KEY (id)
);

--criar tabela endereço(esqueci de copiar pra cá)

--adicionar coluna na tabela ja existente
ALTER TABLE nome da tabela ADD nome da coluna INT NOT NULL;

--adicionar chave estrangeira(ALTER TABLE endereco ADD CONSTRAINT FK_usuario foreign key(usuario_id) REFERENCES usuario(id);)
ALTER TABLE tabelaOndeSeCriaraAChave ADD CONSTRAINT FK_usuario foreign key(coluna da chave estrangeira) REFERENCES lugar onde ela vai se referenciar;

--inserir usuario
INSERT INTO  usuario
(nome, sobrenome, telefone, email, genero, senha)
 VALUES 
 ('Rafael', 'Alves', '(11) 9634786354', 'rafael@mail.com', 'masculino', '123');

 INSERT INTO  usuario
(nome, sobrenome, telefone, email, genero, senha)
 VALUES 
 ('Maria Eduarda', 'Alves', '(11) 99384457', 'maria@mail.com', 'feminino', '321');


 --selecionar usuario/exibir dados
 SELECT * FROM usuario

 --selecionar usuario por alguma infrmação
 SELECT * FROM usuario WHERE sobrenome = 'alves'; --o * significa todas as informações,mas se quiser pode-se escolher uma informação especifica
 
 --selecionar mais de um usuario
 SELECT * FROM usuario WHERE sobrenome IN ('alves','carvalho');
 --ou
 SELECT * FROM usuario WHERE id > 2


 --alterar usuario
 UPDATE usuario SET email = 'mariaEditada@mail.com' WHERE id = 3; --depois do SET coloca-se o dado que se deseja alterar e depois do WHERE coloca-se de onde se quer mudar a informação

 --deletar usuario
 DELETE FROM usuario WHERE id = 6;