Testes de unidade

Um teste de unidade � aquele que testa uma �nica unidade do sistema. Realiza o teste de maneira isolada, geralmente simulando prov�veis depend�ncias que aquela unidade tem.

Em linguagens orientadas a objetos, � comum que a unidade seja uma classe.
Quando precisamos escrever testes de unidade para a classe exemplo: Pedido, essa bateria de testes testar� o funcionamento da classe Pedido, isolada, sem intera��es com outras classes.


Testes de integra��o

� aquele que testa a integra��o entre duas ou mais partes da sua aplica��o.

Os testes que voc� escreve para sua classe de PedidoService e PedidoRepository, por exemplo, onde seu teste vai at� o banco de dados, � um teste de integra��o.

De fato voc� est� testando a integra��o da sua app com suas diversas partes, por exemplo o banco de dados, uma camada ou um servi�o externo.

Estes testes garantem algo que os testes de unidade n�o garantem, eles garantem que as unidades da sua aplica��o est�o se integrando conforme o esperado.


Testes automatizados

� um teste de sistema, podemos considerar como um teste de aceita��o, funciona como um teste de caixa preta j� que o sistema � testado de ponta a ponta atrav�s das opera��es executadas no sistema.

A automatiza��o garante que todo o processo ser� executado da mesma maneira que fosse um usu�rio utilizando a aplica��o.

Pode ser considerado um teste de aceita��o, pois neste teste al�m de garantir o funcionamento ponta a ponta, podemos validar caracter�sticas do neg�cio e funcionalidades.

Pode ser considerado um teste de regress�o pois sua execu��o garante que a aplica��o n�o regrediu, ou seja, que n�o surgiram novos defeitos em componentes que j� estavam funcionando nas vers�es anteriores.


Testes de carga

Consiste em testar as capacidades da aplica��o, muitas vezes at� seu limite, de forma que a aplica��o n�o consiga mais responder.Pode ser tamb�m considerado como um teste de stress.
Testar a performance do c�digo e componentes em situa��es extremas. Descobrir poss�veis gargalos.
Testar como a app ir� se comportar com um determinado n�mero de usu�rios simult�neos e garantir que ir� atender a demanda.
Testar um poss�vel balanceamento de carga no servidor ou at� mesmo a escala el�stica na nuvem.

O teste de carga � muito importante em aplica��es Web e em aplica��es que � esperado um grande volume de requisi��es.


Testes de unidades a fundo

Frameworks de testes

MSTest -> Microsoft
https://github.com/microsoft/testfx

NUnit -> Vers�o do JUnit para .Net
https://nunit.org

XUnit -> Parecido com NUnit s� que mais atual
https://xunit.net
Escrito pelos criadores do NUnit.
Compat�vel com Visual Studio.
Utilizado pelo time de desenvolvimento do .NET Core e ASP.NET.
Para instalar: Install-package xunit e Install-Package xunit.runner.visualstudio


Padr�es e Nomenclaturas 

Padr�es:
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


A import�ncia do Mock

Objetos Mock, objetos simulados ou simplesmente Mock (Mock Object) s�o objetos que simulam o comportamento de objetos reais de forma controlada.

	S�o normalmente criados para testar o comportamento de outros objetos. Em outras palavras, os objetos mock s�o objetos �falsos� que simulam o comportamento de uma classe ou objeto �real� para que possamos focar o teste na unidade a ser testada.

	Uma vantagem do Mock � que o objeto simulado pode ser criado dinamicamente atrav�s de um framework e Mock e poupando o desenvolvedor ter que criar uma classe f�sica para simular aquele objeto.

	Uma classe f�sica que simula o objeto costuma ser chamada de Fake, mas na teoria � um Mock, a diferen�a � que foi criada manualmente.

Framework para Mock: MOQ
Realize Mock com facilidade.
Compat�vel com Visual Studio.
Utilizado pelo time de desenvolvimento do .NET Core e ASP.NET

Instala��o do framework:
Install-Package Moq


