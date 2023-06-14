# Fluxo de Caixa - README

Este projeto é uma aplicação de controle de fluxo de caixa, que permite o registro de lançamentos (débitos e créditos) e fornece um saldo diário consolidado.

## Desenho da Solução

A solução é composta por três principais componentes:

1. **FluxoDeCaixa**: Classe responsável por controlar o saldo diário e registrar os lançamentos.
2. **ControleLancamentosService**: Serviço responsável por realizar o controle dos lançamentos. Ele recebe o tipo de lançamento (débito ou crédito) e o valor, e atualiza o saldo diário.
3. **SaldoDiarioService**: Serviço responsável por obter o saldo diário consolidado.

A arquitetura da solução segue o padrão de injeção de dependência, onde os serviços dependem da interface `IFluxoDeCaixaRepository` para interagir com a camada de persistência.

## Execução Local

Para executar a aplicação localmente, siga as instruções abaixo:

1. Certifique-se de ter o SDK do .NET instalado em sua máquina.
2. Clone o repositório para o seu ambiente local.
3. Abra o terminal na pasta raiz do projeto.
4. Execute o comando `dotnet run` para iniciar a aplicação.
5. A aplicação estará disponível em `http://localhost:5000`.

## Execução em Contêineres

Para executar a aplicação em contêineres, siga as instruções abaixo:

1. Certifique-se de ter o Docker instalado em sua máquina.
2. Clone o repositório para o seu ambiente local.
3. Abra o terminal na pasta raiz do projeto, onde se encontra o arquivo Dockerfile.
4. Execute o comando `docker build -t nome-do-projeto:latest .` para criar a imagem do contêiner.
5. Após a conclusão do comando anterior, execute o comando `docker run -d -p 8080:80 nome-do-projeto:latest` para iniciar o contêiner.
6. A aplicação estará disponível em `http://localhost:8080`.

## Utilização dos Serviços

### Controle de Lançamentos

O serviço de controle de lançamentos é acessado através de uma API REST.

- **Endpoint**: `/api/lancamentos`
- **Método**: POST
- **Corpo da Requisição**:
    ```json
    {
        "tipoLancamento": "Debito",
        "valor": 50
    }
    ```
  - O campo `tipoLancamento` pode ser "Debito" ou "Credito".
  - O campo `valor` deve ser um número decimal maior que zero.
- **Resposta**:
  - Status 200 OK: O lançamento foi registrado com sucesso.
  - Status 400 Bad Request: O corpo da requisição está inválido.

### Saldo Diário Consolidado

O serviço de saldo diário consolidado é acessado através de uma API REST.

- **Endpoint**: `/api/saldo`
- **Método**: GET
- **Resposta**:
  - Status 200 OK: Retorna o saldo diário consolidado no formato JSON.
    ```json
    {
        "saldoDiarioConsolidado": 500.75
    }
    ```