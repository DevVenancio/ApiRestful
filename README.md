## ApiRestful
APIRestful criada utilizando:
- .NET Core
- Entity Framework
- PostgreSQL

## Utilizando as Rotas
Para utilizar as rotas, é necessário realizar o login de autenticação.
- **Usuário:** admin
- **Senha:** admin

## Instruções de Instanciamento do Banco de Dados:
#### Criando o Database
```
CREATE DATABASE "ApiVize"
    WITH
    OWNER = postgres
    ENCODING = 'UTF8'
    LC_COLLATE = 'Portuguese_Brazil.1252'
    LC_CTYPE = 'Portuguese_Brazil.1252'
    LOCALE_PROVIDER = 'libc'
    TABLESPACE = pg_default
    CONNECTION LIMIT = -1
    IS_TEMPLATE = False;
```

#### Criando as Tabelas:
```
CREATE TABLE IF NOT EXISTS public.produto
(
    produto_id character varying(5) COLLATE pg_catalog."default" NOT NULL,
    produto_nome character varying COLLATE pg_catalog."default",
    preco_unit real,
    produto_tipo character varying COLLATE pg_catalog."default",
    CONSTRAINT produto_pkey PRIMARY KEY (produto_id)
)

TABLESPACE pg_default;

ALTER TABLE IF EXISTS public.produto
    OWNER to postgres;
```

#### Inserindo alguns dados fictícios (opcional)
```
INSERT INTO produto
VALUES
('M001', 'Produto 1', 10.00, 'Material'),
('M002', 'Produto 2', 11.00, 'Material'),
('M003', 'Produto 3', 12.00, 'Material'),
('M004', 'Produto 4', 13.00, 'Material'),
('M005', 'Produto 5', 14.00, 'Material'),
('M006', 'Produto 6', 15.00, 'Material'),
('M007', 'Produto 7', 16.00, 'Material'),
('M008', 'Produto 8', 17.00, 'Material'),
('M009', 'Produto 9', 18.00, 'Material'),
('M010', 'Produto 10', 19.00, 'Material'),
('S001', 'Serviço 1', 20.00, 'Serviço'),
('S002', 'Serviço 2', 21.00, 'Serviço'),
('S003', 'Serviço 3', 22.00, 'Serviço'),
('S004', 'Serviço 4', 23.00, 'Serviço'),
('S005', 'Serviço 5', 24.00, 'Serviço'),
('S006', 'Serviço 6', 25.00, 'Serviço'),
('S007', 'Serviço 7', 26.00, 'Serviço'),
('S008', 'Serviço 8', 27.00, 'Serviço'),
('S009', 'Serviço 9', 28.00, 'Serviço'),
('S010', 'Serviço 10', 29.00, 'Serviço')
```
