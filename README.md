# Desafio Back-End FCamara
### Introdução
A aplicação consiste em um gerenciador de múltipos estacionamentos de carros e motos. Essa API REST foi desenvolvida para a solução do desafio de back-end proposto pela FCamara! 
### Instalação e Uso
* Clone [esse](https://github.com/VitorDeFranca/backend-test-dotnet.git) repositório.
* Execute o comando dotnet run dentro da pasta TesteFCamara.API e aguarde.
* Navegue para [este](https://localhost:7048/swagger/index.html) endereço para explorar os endpoints da API.
### Endpoints da API
| Verbos HTTP | Endpoints | Ação |
| --- | --- | --- |
| GET | /api/Estabelecimentos | Retorna todos os estabelecimentos |
| GET | /api/Estabelecimentos/{id} | Retorna um estabelecimento específico |
| POST | /api/Estabelecimentos | Cria um novo estabelecimento |
| PUT | /api/Estabelecimentos/{id} | Altera um estabelecimento específico |
| DELETE | /api/Estabelecimentos/{id} | Deleta um estabelecimento específico |
| GET | /api/Estabelecimentos/{id}/Veiculos | Retorna todos os veículos de um estabelecimento específico |
| GET | /api/Estabelecimentos/{id}/Veiculos/{veiculoId} | Retorna um veículo específico de um estabelecimento específico |
| POST | /api/Estabelecimentos/{id}/Veiculos | Adiciona um veículo novo à um estacionamento específico |
| PUT | /api/Estabelecimentos/{id}/Veiculos/{veiculoId} | Altera um veículo referente à estabelecimento específico |
| DELETE | /api/Estabelecimentos/{id}/Veiculos/{veiculoId} | Deleta um veículo referente à um estabelecimento específico |
### Tecnologias Utilizadas
* [.NET 6.0](https://dotnet.microsoft.com/pt-br/download/dotnet/6.0) 
### Autor
* [Vitor França](https://github.com/VitorDeFranca)
