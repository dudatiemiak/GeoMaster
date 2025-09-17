📐 GeoMaster API

API desenvolvida em .NET 6/7 para cálculos e validações geométricas em 2D e 3D.
Permite calcular área, perímetro, volume e verificar se uma forma pode ser contida dentro de outra.

🚀 Funcionalidades

Cálculos em 2D

Área e perímetro de círculo

Área e perímetro de retângulo

Cálculos em 3D

Área superficial e volume de esfera

Validações geométricas

Verificar se uma forma cabe dentro da outra

Exemplo:

Círculo raio 5 dentro de Retângulo 10x10 ✅

Retângulo 7x7 dentro de Retângulo 6x5 ❌

📦 Tecnologias utilizadas

.NET 6 / 7 (ASP.NET Core Web API)

Swagger / Swashbuckle (documentação e testes)

C# 10/11

Arquitetura em camadas (Api, Application, Domain, Infrastructure)

⚙️ Como rodar o projeto

Clone o repositório:

git clone https://github.com/seu-usuario/GeoMaster.git
cd GeoMaster


Restaure as dependências:

dotnet restore


Rode a aplicação:

dotnet run --project GeoMaster.Api


Acesse o Swagger UI:

https://localhost:7213/swagger

🔗 Endpoints principais
📌 Cálculos (/api/v1/calculos)

POST /area → calcula área de uma forma

POST /perimetro → calcula perímetro de uma forma 2D

POST /volume → calcula volume de uma forma 3D

Exemplo de request:

{
  "tipo": "circulo",
  "raio": 5
}

📌 Geometria (/api/geometry)

GET /area2d/circulo?raio=5

GET /area2d/retangulo?largura=4&altura=6

GET /perimetro2d/circulo?raio=7

GET /area3d/esfera?raio=10

GET /volume3d/esfera?raio=10

📌 Validações (/api/v1/validacoes)

POST /forma-contida → verifica se uma forma cabe dentro da outra

Exemplo de request:

{
  "formaInterna": { "tipo": "circulo", "raio": 5 },
  "formaExterna": { "tipo": "retangulo", "largura": 10, "altura": 10 }
}


Exemplo de resposta:

{
  "resultado": true,
  "mensagem": "✅ A forma interna pode ser contida dentro da forma externa."
}

🛠 Estrutura do projeto
GeoMaster.Api
 ┣ Controllers
 ┣ DTOs
GeoMaster.Application
 ┣ Interfaces
 ┣ Services
GeoMaster.Domain
 ┣ Entities
 ┣ Factories
 ┣ ValueObjects

👨‍💻 Autor

Projeto desenvolvido para fins acadêmicos por Eduarda Tiemi Akamini Machado (rm554756) e Victor Henrique Estrella Carracci (rm556206).
