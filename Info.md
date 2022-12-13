
# Guerra Civil - Marvel

  

Os heróis da Marvel estão em guerra. Depois de um desastre que matou milhares de pessoas o Congresso Nacional Norte-Americano criou a Lei de Registro dos Super-Humanos, onde os heróis devem se registrar junto ao governo e ter sua atuação regulada por ele. Além disso, os heróis devem revelar suas identidades secretas.

  

Isso causou discórdia entre os heróis que são a favor e contra a lei e, com isso, começaram a lutar entre si.

  

Você é o responsável pela criação do sistema de registro dos heróis a favor e contra a lei. Esse sistema também faz simulações de lutas entre os heróis.

  

O sistema então terá dois escopos:

  

## Sistema de Registro

  

Seu sistema deverá expor APIs para que seja possível:

  

- Listar heróis existente.
- Listar detalhes de um herói existente.
- Cadastrar um novo herói.
- Atualizar dados de um herói existente.
- Excluir um herói existente.

  

Um herói possui os seguintes atributos:

  

- Nome.
- Poder de Ataque.
- Poder de Defesa.
- Pontos de Vida.
- Indicação se ele é a favor ou contra a lei de registro dos super-humanos.

O cadastro inicial de heróis deve seguir a tabela abaixo

### Contra o Registro

| Nome                                                                                              | Poder de Ataque | Poder de Defesa | Pontos de Vida |
| ------------------------------------------------------------------------------------------------- | --------------- | --------------- | -------------- |
| Capitão América| 83              | 88              | 500            |
| Soldado Invernal | 75              | 100             | 500            |
| Gavião Arqueiro     | 88              | 77              | 500            |
| Feiticeira Escarlate | 93              | 77              | 500            |
| Falcão  | 80              | 82              | 500            |
| Hulk| 100             | 70              | 500            |  

### A favor do Registro

| Nome                                                                                                         | Poder de Ataque | Poder de Defesa | Pontos de Vida |
| ------------------------------------------------------------------------------------------------------------ | --------------- | --------------- | -------------- |
| Homem de Ferro                       | 75              | 100             | 500            |
| Pantera Negra | 86              | 93              | 500            |
| Viúva Negra | 88              | 77              | 500            |
| Visão          | 100             | 70              | 500            |
| Máquina de Combate    | 75              | 100             | 500            |
| Homem-Aranha          | 80              | 82              | 500            |

## Simulador de Batalha

  

Para o simulador, deve ser criada uma API que recebe dois heróis como parâmetros. O sistema então deverá simular uma batalha por turnos entre os heróis.

### O que acontece em cada turno?

- A cada turno um herói ataca e o outro defende, revezando entre os turnos.
- O herói que ataca rola um dado virtual que vai de 0 (zero) até o máximo do seu poder de ataque.
- O herói que defende rola um dado virtual que vai de 0 (zero) até o seu máximo poder de defesa.
- O dano é calculado da seguinte forma: valor do ataque - valor de defesa = dano.
- O dano é subtraído dos pontos de vida do defensor.
- Se o dano for igual ou menor que zero, nenhum valor é subtraído dos pontos de vida.
- Se um dos heróis tiver zero ou menos pontos de vida, a batalha é terminada.

  

A API da batalha deverá retornar os dados da batalha: nome dos heróis, uma lista com todos os turnos mostrando quem atacou, quem defendou, quantos foram os pontos de ataque, quantos foram os pontos de defesa e a quantidade de pontos de vida dos dois heróis no final do turno.

  

*Um herói não pode batalhar contra outro que esteja do mesmo lado da lei.*

## Especificação Técnica

 - Você pode construir em qualquer linguagem de programação que se sentir mais confortável.
 - Você deve enviar as intruções de como rodar o projeto. Preferível se estiver [Dockerizado](https://www.docker.com/)
- O sistema deve obrigatoriamente funcionar através de APIs e não através de interface web ou mobile.
- O código deve ser commitado neste repositório e deve conter também o contrato das APIs (pode ser um swagger não funcional, um txt com os cURLs, collection do Postman etc)
