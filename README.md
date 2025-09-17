# 📐 GeoMaster API

**GeoMaster** é uma API desenvolvida em **.NET 6/7** para realizar cálculos e validações geométricas em formas 2D e 3D.  
Ela permite calcular área, perímetro, volume e verificar se uma forma pode ser contida dentro de outra.

---

## 🚀 Funcionalidades

### 🔷 Cálculos em 2D
- Área e perímetro de **círculo**
- Área e perímetro de **retângulo**

### 🔶 Cálculos em 3D
- Área superficial e volume de **esfera**

### ✅ Validações geométricas
- Verificar se uma forma pode ser contida dentro de outra

#### Exemplos:
- Círculo raio `5` dentro de Retângulo `10x10` → ✅
- Retângulo `7x7` dentro de Retângulo `6x5` → ❌

---

## 📦 Tecnologias Utilizadas

- .NET 8(ASP.NET Core Web API)
- Swagger / Swashbuckle(documentação e testes)
- Arquitetura em camadas:
  - `Api`
  - `Application`
  - `Domain`
  - `Infrastructure`

---

## ⚙️ Como Rodar o Projeto

### 1. Clone o repositório

```bash
git clone https://github.com/dudatiemiak/GeoMaster.git
cd GeoMaster
```
### 2. Restaure as dependências

```bash
dotnet restore
```
### 3. Rode a aplicação

```bash
dotnet run --project GeoMaster.Api
```
### 4. Acesse o Swagger
🔗https://localhost:7213/swagger

---

## 🔗 Endpoints Principais
### 📌 Cálculos (/api/v1/calculos)
- POST /area → Calcula área de uma forma
- POST /perimetro → Calcula perímetro de uma forma 2D
- POST /volume → Calcula volume de uma forma 3D
  ### Exemplo de request
  ```json
  {
  "tipo": "circulo",
  "raio": 5
  }
  ```
### 📌 Geometria (/api/geometry)
- GET /area2d/circulo?raio=5
- GET /area2d/retangulo?largura=4&altura=6
- GET /perimetro2d/circulo?raio=7
- GET /area3d/esfera?raio=10
- GET /volume3d/esfera?raio=10

### 📌 Validações (/api/v1/validacoes)
- POST /forma-contida → Verifica se uma forma cabe dentro da outra
  ### Exemplo de request:
  ```json
  {
  "formaInterna": { "tipo": "circulo", "raio": 5 },
  "formaExterna": { "tipo": "retangulo", "largura": 10, "altura": 10 }
  }
  ```
  ### Exemplo de resposta:
  ```json
  {
  "resultado": true,
  "mensagem": "A forma interna pode ser contida dentro da forma externa."
  }
  ```
---
### 👨‍💻 Autores
Projeto desenvolvido para fins acadêmicos por:
  - Eduarda Tiemi Akamini Machado (rm554756)
  - Victor Henrique Estrella Carracci (rm556206)

