<div align="center">
<h1> Scientific Calc API</h1>
</div>

> API REST de calculadora científica com autenticação JWT, histórico de cálculos e gerenciamento de conta.

<div align="center">
  <h1> 
 <img src="https://cdn.jsdelivr.net/gh/devicons/devicon@latest/icons/postgresql/postgresql-original.svg" alt="PostgreSQL Logo" width="50"> &nbsp;
 <img src="https://cdn.jsdelivr.net/gh/devicons/devicon@latest/icons/entityframeworkcore/entityframeworkcore-original.svg" alt="EntityFrameworkCoreLogo" width="50"/> &nbsp;
<img src="https://cdn.jsdelivr.net/gh/devicons/devicon@latest/icons/csharp/csharp-original.svg" alt="csharpLogo" width="50"/> &nbsp;
<img src="https://cdn.jsdelivr.net/gh/devicons/devicon@latest/icons/dot-net/dot-net-plain-wordmark.svg" width = "50"/>&nbsp;
<img src="https://cdn.jsdelivr.net/gh/devicons/devicon@latest/icons/docker/docker-plain-wordmark.svg" width = "50" /> &nbsp;
<img src="https://cdn.jsdelivr.net/gh/devicons/devicon@latest/icons/openapi/openapi-original-wordmark.svg" width = "70"/> &nbsp;
<h1>
</div>
## 📋 Pré-requisitos

- Docker
- Docker Compose
- Git

## 🚀 Como executar

1. Clone o repositório
```bash
git clone https://github.com/zdudusz/ScientificCalcAPI
```

2. Suba os containers
```bash
docker compose up --build
```

3. Acesse o Scalar
```
http://localhost:8080/scalar/v1
```

## 📡 Endpoints

| Método | Rota | Descrição | Auth |
|--------|------|-----------|------|
| `POST` | `/api/user` | Cadastrar usuário | ❌ |
| `POST` | `/api/auth/login` | Login | ❌ |
| `GET` | `/api/user` | Consultar dados | ✅ |
| `PUT` | `/api/user/name` | Alterar nome | ✅ |
| `PUT` | `/api/user/email` | Alterar email | ✅ |
| `PUT` | `/api/user/password` | Alterar senha | ✅ |
| `POST` | `/api/calculator` | Realizar cálculo | ✅ |
| `GET` | `/api/history` | Listar histórico | ✅ |
| `DELETE` | `/api/history/{id}` | Deletar um registro | ✅ |
| `DELETE` | `/api/history` | Deletar todo histórico | ✅ |

## Exemplos de uso
### Cadastro

```json
{
  "name": "Thales",
  "email": "Thales@ongold.com",
  "password": "123456789"
}
```
___
### Login
```json
{
  "email": "Thales@ongold.com",
  "password": "123456789"
}
```
___
### Calculadora Científica
#### Operação com 2 operandos
```json
{
  "operation": "add",
  "operands": [
    1,9
  ]
}
```
#### Operação com 1 operando
```json
{
  "operation": "factorial",
  "operands": [
    9
  ]
}
```
___

## 👨‍💻 Autor

Feito por **Eduardo** 

[![GitHub](https://img.shields.io/badge/GitHub-zdudusz-black?logo=github)](https://github.com/zdudusz)     

          
          
          
 
 