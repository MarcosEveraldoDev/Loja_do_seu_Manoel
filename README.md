# Loja do Seu Manoel - Microserviço em .NET Core

## Descrição

Este projeto é um microserviço desenvolvido em .NET Core (ou superior) que utiliza banco de dados SQL Server. Tanto o serviço quanto o banco de dados são executados via Docker, garantindo portabilidade e facilidade de uso.

A API está documentada com Swagger, permitindo testes diretamente pela interface web.

---

## Pré-requisitos

- [Docker](https://docs.docker.com/get-docker/) instalado na sua máquina.
- [Docker Compose](https://docs.docker.com/compose/install/) (geralmente já vem junto com o Docker).

---

## Como rodar a aplicação

1. Clone este repositório:
   ```bash
   git clone https://github.com/MarcosEveraldoDev/Loja_do_seu_Manoel.git
   cd Loja_do_seu_Manoel

2.docker-compose up -d (aguardar os containers subirem)

3.acessar o swagger http://localhost:8080/swagger/index.html
