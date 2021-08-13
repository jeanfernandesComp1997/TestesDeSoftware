Testes de unidade

Um teste de unidade é aquele que testa uma única unidade do sistema. Realiza o teste de maneira isolada, geralmente simulando prováveis dependências que aquela unidade tem.

Em linguagens orientadas a objetos, é comum que a unidade seja uma classe.
Quando precisamos escrever testes de unidade para a classe exemplo: Pedido, essa bateria de testes testará o funcionamento da classe Pedido, isolada, sem interações com outras classes.


Testes de integração

É aquele que testa a integração entre duas ou mais partes da sua aplicação.

Os testes que você escreve para sua classe de PedidoService e PedidoRepository, por exemplo, onde seu teste vai até o banco de dados, é um teste de integração.

De fato você está testando a integração da sua app com suas diversas partes, por exemplo o banco de dados, uma camada ou um serviço externo.

Estes testes garantem algo que os testes de unidade não garantem, eles garantem que as unidades da sua aplicação estão se integrando conforme o esperado.


Testes automatizados

É um teste de sistema, podemos considerar como um teste de aceitação, funciona como um teste de caixa preta já que o sistema é testado de ponta a ponta através das operações executadas no sistema.

A automatização garante que todo o processo será executado da mesma maneira que fosse um usuário utilizando a aplicação.

Pode ser considerado um teste de aceitação, pois neste teste além de garantir o funcionamento ponta a ponta, podemos validar características do negócio e funcionalidades.

Pode ser considerado um teste de regressão pois sua execução garante que a aplicação não regrediu, ou seja, que não surgiram novos defeitos em componentes que já estavam funcionando nas versões anteriores.


Testes de carga

Consiste em testar as capacidades da aplicação, muitas vezes até seu limite, de forma que a aplicação não consiga mais responder.Pode ser também considerado como um teste de stress.
Testar a performance do código e componentes em situações extremas. Descobrir possíveis gargalos.
Testar como a app irá se comportar com um determinado número de usuários simultâneos e garantir que irá atender a demanda.
Testar um possível balanceamento de carga no servidor ou até mesmo a escala elástica na nuvem.

O teste de carga é muito importante em aplicações Web e em aplicações que é esperado um grande volume de requisições.


Testes de unidades a fundo

Frameworks de testes

MSTest -> Microsoft
https://github.com/microsoft/testfx

NUnit -> Versão do JUnit para .Net
https://nunit.org

XUnit -> Parecido com NUnit só que mais atual
https://xunit.net
Escrito pelos criadores do NUnit.
Compatível com Visual Studio.
Utilizado pelo time de desenvolvimento do .NET Core e ASP.NET.
Para instalar: Install-package xunit e Install-Package xunit.runner.visualstudio


Padrões e Nomenclaturas 

Padrões:
AAA - Arrange, Act, Assert

Nomenclaturas:
ObjetoEmTeste_MetodoComportamentoEmTeste_ComportamentoEsperado

Exemplos: 
Pedido_AdicionarPedidoItem_DeveIncrementarUnidadesSeItemJaExiste
Estoque_RetirarItem_DeveEnviarEmailSeAbaixoDe10Unidades

Outra nomenclatura:
MetodoEmTeste_EstadoEmTeste_ComportamentoEsperado

Exemplos:
AdiconarPedidoItem_ItemExistenteCarrinho_DeveIncrementarUnidadesDoItem
RetirarItemEstoque_EstoqueAbaxioDe10Unidades_DeveEnviarEmailDeAviso


A importância do Mock

Objetos Mock, objetos simulados ou simplesmente Mock (Mock Object) são objetos que simulam o comportamento de objetos reais de forma controlada.

	São normalmente criados para testar o comportamento de outros objetos. Em outras palavras, os objetos mock são objetos “falsos” que simulam o comportamento de uma classe ou objeto “real” para que possamos focar o teste na unidade a ser testada.

	Uma vantagem do Mock é que o objeto simulado pode ser criado dinamicamente através de um framework e Mock e poupando o desenvolvedor ter que criar uma classe física para simular aquele objeto.

	Uma classe física que simula o objeto costuma ser chamada de Fake, mas na teoria é um Mock, a diferença é que foi criada manualmente.

Framework para Mock: MOQ
Realize Mock com facilidade.
Compatível com Visual Studio.
Utilizado pelo time de desenvolvimento do .NET Core e ASP.NET

Instalação do framework:
Install-Package Moq


