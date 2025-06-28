
# 📄 Sobre o Projeto - FraudSys

**FraudSys** é uma aplicação ASP.NET Core MVC desenvolvida com o objetivo de simular um sistema bancário simplificado com foco na prevenção e controle de fraudes em transações via PIX. O projeto foi arquitetado com boas práticas de desenvolvimento, separação de responsabilidades em camadas e uso de tecnologias modernas da plataforma .NET.

## ✨ Funcionalidades principais

- **Cadastro e Gerenciamento de Contas Correntes**  
  Permite o registro de contas com informações como agência, número da conta, CPF/CNPJ e limite individual para transações PIX.

- **Edição e Visualização Detalhada**  
  Consultas com base em filtros de agência e conta, além da visualização de dados com campos desabilitados para leitura.

- **Transferência PIX**  
  Simulação de uma transferência entre contas, respeitando os limites definidos e validando a existência das contas envolvidas.

- **Remoção de Contas**  
  Interface simples e segura para exclusão de contas com feedback ao usuário.

## 🧱 Arquitetura e Tecnologias

- **ASP.NET Core MVC**
- **MediatR** para orquestração de comandos e queries (CQRS)
- **AutoMapper** para mapeamento entre modelos e view models
- **Amazon DynamoDB** como banco de dados NoSQL
- **jQuery + Bootstrap** para interações no frontend
- **SweetAlert** para mensagens dinâmicas ao usuário
- **Validações com Data Annotations**  
- **ViewComponents e Partial Views** para reaproveitamento de layout

## 🎯 Objetivo

O projeto foi desenvolvido como parte de um processo seletivo e demonstra conhecimento em:
- Desenvolvimento fullstack com ASP.NET Core MVC
- Integração com banco NoSQL (DynamoDB)
- Aplicação de padrões como CQRS e injeção de dependência
- Manipulação segura de dados sensíveis e validações no frontend/backend
