Vendinha — Sistema de Cadastro de Clientes e Controle de Dívidas

Sobre o projeto:
A Vendinha é uma aplicação desktop desenvolvida em C# com Windows Forms e .NET 8.0. O sistema foi criado com o objetivo de informatizar o controle de contas de clientes de uma vendinha, substituindo o registro manual de dívidas em papel por um sistema digital.
A aplicação permite cadastrar e gerenciar clientes, registrar dívidas, acompanhar pagamentos e consultar os valores pendentes de cada cliente.

Tecnologias utilizadas:
• Linguagem: C#
• Framework: .NET 8.0
• Interface gráfica: Windows Forms
• Banco de dados: SQLite
• Acesso ao banco: Microsoft.Data.Sqlite 8.0.34
• IDE: Visual Studio 2022

Funcionalidades:

- Cadastro e gerenciamento de clientes:
• Cadastro de novos clientes.
• Consulta dos clientes cadastrados.
• Edição dos dados dos clientes.
• Exclusão de clientes.
• Validação de CPF.
• Impedimento de cadastro de CPF duplicado.
• Validação de e-mail, quando informado.
• Cálculo automático da idade com base na data de nascimento.

- Gerenciamento de dívidas:
• Cadastro de dívidas vinculadas aos clientes.
• Consulta das dívidas de cada cliente.
• Exibição do valor e da data de criação da dívida.
• Controle da situação da dívida (paga ou em aberto).
• Registro da data de pagamento.
• Possibilidade de marcar uma dívida como paga.
• Impedimento de cadastrar uma nova dívida enquanto o cliente possuir outra em aberto.

- Listagem e organização dos clientes:
• Pesquisa de clientes pelo nome.
• Ordenação dos clientes do maior devedor para o menor devedor.
• Paginação com exibição de 10 clientes por página.
• Exibição da idade atualizada dos clientes.
• Exibição da soma das dívidas em aberto de cada cliente.

- Regras de negócio:
• Cada cliente deve possuir um CPF válido e exclusivo.
• Não é permitido cadastrar dois clientes com o mesmo CPF.
• Um cliente pode possuir somente uma dívida em aberto por vez.
• Uma nova dívida só pode ser cadastrada quando a anterior estiver paga.
• A idade é calculada a partir da data de nascimento.
• As dívidas possuem situação de pagamento e datas de criação e pagamento.


Responsabilidade das pastas
• Contexts: responsável pela conexão e inicialização do banco de dados SQLite.
• Models: contém as classes que representam os clientes e as dívidas.
• Services: concentra as operações de cadastro, consulta, atualização, exclusão e gerenciamento dos dados.
• Screens: contém as interfaces gráficas da aplicação Windows Forms.
• Utils: contém métodos auxiliares, como as validações de CPF e e-mail.


Banco de dados
O sistema utiliza SQLite para armazenar os dados dos clientes e das dívidas.
A classe VendinhaDbContext.cs é responsável por estabelecer a conexão com o banco e inicializar as tabelas necessárias.
As tabelas utilizadas são:
• Clientes: armazena os dados dos clientes, como nome, CPF, data de nascimento e e-mail.
• Dividas: armazena os valores das dívidas, a identificação do cliente relacionado, a situação e as datas de criação e pagamento.
O banco de dados é inicializado automaticamente quando a aplicação é executada pela primeira vez.

Como executar o projeto

Requisitos necessários:
• Windows.
• Visual Studio 2022.
• .NET 8.0 SDK.

Passo a passo
1. Clone ou baixe o repositório do GitHub.
2. Abra o arquivo ProjVendinhaFinal.slnx no Visual Studio 2022.
3. Aguarde a restauração dos pacotes NuGet.
4. Verifique se o pacote Microsoft.Data.Sqlite está instalado.
5. Defina o projeto ProjVendinhaFinal como projeto de inicialização.
6. Execute a aplicação utilizando a tecla F5 ou o botão Iniciar.


Participantes: Pedro Henrique Vieira - RA: 2039706, Miguel Vinicius - RA: 2038440
