
# Vixtra - Marvel Challenge API






## Rodando a aplicação


Docker build

```bash
  docker build -t marvelapi:v1 -f Marvel.API/DockerFile
```

Start Application

```bash
  docker run --name marvelapi -it  —rm -p 8080:80 marvelapi:v1
```


## Documentação da API

## Herois

#### Obtenha uma lista paginada de todos os heros cadastrados. 

```http
  GET /api/Heroes/GetAllHeroes
```

| Parameter   | Type       | Description                         |
| :---------- | :--------- | :---------------------------------- |
| `query` | `string` | String com nome completo ou parcial do Herói  |
| `page` | `int` |  Numero da pagina |


#### Obtem um Herói

```http
  GET /api/Heroes/${id}
```

| Parameter   | Type       | Description                         |
| :---------- | :--------- | :------------------------------------------ |
| `id`      | `int` | **Obrigatório**. Id do heroi |

#### Cria um Herói

```http
  POST /api/Heroes/Create
```

| Parameter   | Type       | Description                         |
| :---------- | :--------- | :------------------------------------------ |
| `name`      | `string` | **Obrigatório**. Nome do Herói |
| `attackPower`      | `int` | **Obrigatório**. Poder de Ataque  |
| `defensePower`      | `int` | **Obrigatório**. Poder de Defesa  |
| `hp`      | `int` | **Obrigatório**. Pontos de Vida  |
| `affiliation`      | `bool` | **Obrigatório**. Indicação se ele é a favor ou contra a lei de registro dos super-humanos.|


#### Atualiza dados de um herói existente

```http
  PUT /api/Heroes/Update
```

| Parameter   | Type       | Description                         |
| :---------- | :--------- | :------------------------------------------ |
| `id`      | `int` | **Obrigatório**. Id do herói|
| `name`      | `string` | Nome do Herói |
| `attackPower`      | `int` |  Poder de Ataque  |
| `defensePower`      | `int` | Poder de Defesa  |
| `hp`      | `int` | Pontos de Vida  |
| `affiliation`      | `bool` | Indicação se ele é a favor ou contra a lei de registro dos super-humanos.|

#### Deleta um Herói

```http
  DELETE /api/Heroes/Delete/${id}
```

| Parameter   | Type       | Description                         |
| :---------- | :--------- | :------------------------------------------ |
| `id`      | `int` | **Obrigatório**. Id do herói|

#### Insere a lista inicial dos Herois na base de dados.

```http
  POST /api/Heroes/InitialLoad
```

## Batalha

```http
  POST /api/Battle
```

| Parameter   | Type       | Description                         |
| :---------- | :--------- | :---------------------------------- |
| `heroInFavorId` | `int` |  **Obrigatório**. Id do Herói a favor do registro.  |
| `heroAgainstId` | `int` |  **Obrigatório**. Id do Herói contrario ao registro |

## Melhorias

Para os testes unitários, criei apenas alguns testes básicos, no mundo real, precisaremos aumentar a cobertura do código, com mais testes unitários, testes de integração e muito mais.


## Autores

- [@Abnoan Muniz](https://github.com/Abnoan)

