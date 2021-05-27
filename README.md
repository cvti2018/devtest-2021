# DevTest - Cadastro de EPI

Implemente os seguintes cadastros:

- Cadastro de empresa
- Cadastro de Função
- Cadastro de Funcionário
- Associar um ou vários EPIs a um funcionário

No cadastro de funcionários mostrar os EPIs associados a esse funcionário.

Desejável para o desenvolvimento:
- Injeção de dependência
- TDD
- Persistência dos dados e regras de negócio devem ser feitas no projeto CadastroEpi.Domain

---
## Informações gerais

1. Crie um branch e o utilize para enviar o código ao finalizar. Favor enviar um email para avisar que o código está disponível.
2. O banco de dados já possui o cadastro de EPIs, não é necessário fazer o cadastro
3. Na tabela Funcionário EPI, a data de troca é a data que um EPI já cadastrado foi substituído por outro do mesmo tipo (mesmo CA)

---
## Referências
- [TDD](https://en.wikipedia.org/wiki/Test-driven_development)
- Injeção de dependência
    - https://autofac.org/
    - https://simpleinjector.org
    - http://www.ninject.org/
