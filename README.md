# Fluxo de Caixa - README

Este projeto � uma aplica��o de controle de fluxo de caixa, que permite o registro de lan�amentos (d�bitos e cr�ditos) e fornece um saldo di�rio consolidado.

## Desenho da Solu��o

A solu��o � composta por tr�s principais componentes:

1. **FluxoDeCaixa**: Classe respons�vel por controlar o saldo di�rio e registrar os lan�amentos.
2. **ControleLancamentosService**: Servi�o respons�vel por realizar o controle dos lan�amentos. Ele recebe o tipo de lan�amento (d�bito ou cr�dito) e o valor, e atualiza o saldo di�rio.
3. **SaldoDiarioService**: Servi�o respons�vel por obter o saldo di�rio consolidado.

A arquitetura da solu��o segue o padr�o de inje��o de depend�ncia, onde os servi�os dependem da interface `IFluxoDeCaixaRepository` para interagir com a camada de persist�ncia.

## Execu��o Local

Para executar a aplica��o localmente, siga as instru��es abaixo:

1. Certifique-se de ter o SDK do .NET instalado em sua m�quina.
2. Clone o reposit�rio para o seu ambiente local.
3. Abra o terminal na pasta raiz do projeto.
4. Execute o comando `dotnet run` para iniciar a aplica��o.
5. A aplica��o estar� dispon�vel em `http://localhost:5000`.

## Execu��o em Cont�ineres

Para executar a aplica��o em cont�ineres, siga as instru��es abaixo:

1. Certifique-se de ter o Docker instalado em sua m�quina.
2. Clone o reposit�rio para o seu ambiente local.
3. Abra o terminal na pasta raiz do projeto, onde se encontra o arquivo Dockerfile.
4. Execute o comando `docker build -t nome-do-projeto:latest .` para criar a imagem do cont�iner.
5. Ap�s a conclus�o do comando anterior, execute o comando `docker run -d -p 8080:80 nome-do-projeto:latest` para iniciar o cont�iner.
6. A aplica��o estar� dispon�vel em `http://localhost:8080`.

## Utiliza��o dos Servi�os

### Controle de Lan�amentos

O servi�o de controle de lan�amentos � acessado atrav�s de uma API REST.

- **Endpoint**: `/api/lancamentos`
- **M�todo**: POST
- **Corpo da Requisi��o**:
    ```json
    {
        "tipoLancamento": "Debito",
        "valor": 50
    }
    ```
  - O campo `tipoLancamento` pode ser "Debito" ou "Credito".
  - O campo `valor` deve ser um n�mero decimal maior que zero.
- **Resposta**:
  - Status 200 OK: O lan�amento foi registrado com sucesso.
  - Status 400 Bad Request: O corpo da requisi��o est� inv�lido.

### Saldo Di�rio Consolidado

O servi�o de saldo di�rio consolidado � acessado atrav�s de uma API REST.

- **Endpoint**: `/api/saldo`
- **M�todo**: GET
- **Resposta**:
  - Status 200 OK: Retorna o saldo di�rio consolidado no formato JSON.
    ```json
    {
        "saldoDiarioConsolidado": 500.75
    }
    ```