<div> <h2 align="center" style="font-wight: bold;"> Desafio Back-End FCamara :computer:</h2>
  <p align="center">
    <a href="#intro">Introdução</a> •
    <a href="#install">Instalação e Uso</a> •
    <a href="#routes">Endpoints</a> •
    <a href="#arch">Arquitetura e Organização</a> •
    <a href="#tech">Tecnologias</a> •
    <a href="#author">Autor</a> 
  </p>
</div>

<div>
  <h3 id="intro">Introdução :pencil: </h3>
  <p align="justify">A aplicação consiste em um gerenciador de múltipos estacionamentos de carros e motos. Essa API REST foi desenvolvida para a solução do desafio de back-end proposto pela FCamara!</p>
</div>
<hr>


  <h3 id="install">Instalação e Uso 🚀</h3>
  <li> Baixe e instale <a href="https://dotnet.microsoft.com/pt-br/download/dotnet/6.0">.NET 6.0</a> e <a href="https://git-scm.com/downloads">Git 2</a> em sua máquina. Caso já os tenha instalado, desconsidere esse passo. </li>
  
  <li> Clone esse repositório. </li>
  
```bash
git clone https://github.com/VitorDeFranca/backend-test-dotnet.git
```

  <li> Dentro da pasta criada, execute os comandos a seguir e aguarde a build.</li>
  
  ```bash
  cd .\TesteFCamara.API\
  dotnet run
  ```
  
  <li> Navegue para <a href="https://localhost:7048/swagger/index.html">este</a> endereço para explorar os endpoints da API.</li>

<hr>

<div>
  <h3 id="routes">Endpoints 📍</h3>
</div>

| Verbos HTTP | Endpoints | Ação 
|---|---|--- 
| GET | /api/Estabelecimentos | Retorna todos os estabelecimentos 
| GET | /api/Estabelecimentos/{id} | Retorna um estabelecimento específico 
| POST | /api/Estabelecimentos | Cria um novo estabelecimento 
| PUT | /api/Estabelecimentos/{id} | Altera um estabelecimento específico 
| DELETE | /api/Estabelecimentos/{id} | Deleta um estabelecimento específico 
| GET | /api/Estabelecimentos/{id}/Veiculos | Retorna todos os veículos de um estabelecimento específico 
| GET | /api/Estabelecimentos/{id}/Veiculos/{veiculoId} | Retorna um veículo específico de um estabelecimento específico 
| POST | /api/Estabelecimentos/{id}/Veiculos | Adiciona um veículo novo à um estacionamento específico 
| PUT | /api/Estabelecimentos/{id}/Veiculos/{veiculoId} | Altera um veículo referente à estabelecimento específico 
| DELETE | /api/Estabelecimentos/{id}/Veiculos/{veiculoId} | Deleta um veículo referente à um estabelecimento específico 
<hr>

<div>
  <h3 id="arch">Arquitetura e Organização :open_file_folder:</h3>
  <div align="center" style="margin-top: 5px">
    <img height="400em" src="TesteFCamara.API\Assets\cleanarch.jpg"/>
  </div>
  <h3>Core</h3>
  <li><b>Domain:</b>&ensp;É no Domain que estarão as entidades e interfaces que encapsulam as regras de negócio, que são a lógica da nossa aplicação. Nessa API, as entidades são os modelos de Estabelecimento e de Veículo</li>
  <li><b>Application:</b>&ensp;A camada de Application é quem intermedia as interções entre o domínio e a interface de usuário, abrigando a lógica específica da aplicação.</li>
  <h3>Infrastructure</h3>
  <li><b>Persistence:</b>&ensp;Parte responsável por lidar com a persistência de informações no banco de dados. Garante que a manipulação de dados seja feita de forma desacoplada do resto do sistema, facilitando a manutenção e escalabilidade da API</li>
  <h3>Presentation</h3>
  <li><b>API:</b>&ensp;Na API estão as interfaces de entrada e saída da aplicação e é como elá irá se comunicar com terceiros. É responsável por adaptar os dados entre os casos de uso interno e os dispositivos externos.</li>
  <h3>Test</h3>
  <li><b>Tests:</b>&ensp;A camada de testes permeia todas as outras camadas da aplicação para verificar se o comportamento do sistema está de acordo com o planejado.</li>
</div>

<div>
  <h3 id="tech">Tecnologias Utilizadas :space_invader:</h3>
  <li><a href="https://dotnet.microsoft.com/pt-br/download/dotnet/6.0">.NET 6.0</a></li>
  <li><a href="https://learn.microsoft.com/pt-br/aspnet/core/introduction-to-aspnet-core?view=aspnetcore-8.0">ASP.NET</a></li>
  <li><a href="https://learn.microsoft.com/pt-br/ef/">Entity Framework</a></li>  
</div>
<hr>

<div>
  <h3 id="author">Autor :globe_with_meridians:</h3>
  <li><a href="www.linkedin.com/in/vitor-monteiro-de-franca">Vitor França</a></li>
</div>
