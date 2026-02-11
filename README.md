# Lojinha no Console (Ecommerce-API)

Aplicativo de console em C#/.NET 6 que simula um mini e-commerce: baixa uma lista de produtos públicos, permite navegar, buscar, filtrar com LINQ, montar um carrinho e “pagar” com direito a sugestões inteligentes de itens relacionados via OpenAI.

## Principais funcionalidades
- Lista 100 produtos reais de teste da API pública DummyJSON.
- Busca por título e exibe detalhes formatados de cada item.
- Filtros e ordenações com LINQ (por categoria, preço crescente/decrescente).
- Carrinho completo: adicionar, remover, ver total e limpar após pagamento.
- Checkout com recomendações de produtos relacionadas usando OpenAI (opcional, via `OPENAI_API_KEY`).
- Interface em console com logo ASCII para tornar a experiência mais divertida.

## Tecnologias e pacotes
- .NET 6 (C# 10)
- `HttpClient` + `System.Text.Json` para consumir e desserializar o DummyJSON.
- LINQ para filtros e ordenações.
- Pacote `OpenAI` 1.11.0 para gerar recomendações.
- Estrutura simples em camadas: `Menus/`, `Filters/`, `models/`, `Dtos/`.

## Como rodar localmente
1. **Pré-requisitos**: .NET 6 SDK instalado e acesso à internet.
2. **(Opcional) OpenAI**: defina a chave se quiser recomendações no checkout  
   - PowerShell: `setx OPENAI_API_KEY "sua-chave-aqui"` ou só para a sessão ` $env:OPENAI_API_KEY="sua-chave"`  
   - bash/zsh: `export OPENAI_API_KEY="sua-chave"`
3. **Instale dependências** (restaura o pacote OpenAI):  
   ```bash
   dotnet restore
   ```
4. **Execute a aplicação**:  
   ```bash
   dotnet run --project Ecommerce-API
   ```
5. **Use o menu**:  
   - `1` listar produtos  
   - `2` buscar por título  
   - `3` adicionar ao carrinho  
   - `4` remover do carrinho  
   - `5` pagar (mostra recomendações se a chave OpenAI estiver configurada)  
   - `-1` sair

## Estrutura do projeto
- `Program.cs` — ponto de entrada; busca produtos do DummyJSON e inicia o menu.
- `models/` — `Product`, `Cart` (total calculado por LINQ).
- `Dtos/ProductsResponse.cs` — mapeamento da resposta da API.
- `Menus/` — lógica de UI em console (exibição, busca, carrinho, pagamento).
- `Filters/` — utilidades de filtro e ordenação com LINQ.

## Dependências externas
- **DummyJSON**: https://dummyjson.com/products?limit=100 (fonte dos dados).
- **OpenAI**: requer `OPENAI_API_KEY`; sem a chave, a etapa de recomendação falhará. Se quiser rodar sem recomendações, basta comentar o bloco correspondente em `Menus/PaymentMenu.cs`.

## Dicas de uso e testes rápidos
- Para explorar filtros: acesse `1` (listar) → escolha ordenar/filtrar e teste categorias como `laptops`, `smartphones` ou `fragrances`.
- Verifique o fluxo completo: adicione 2–3 itens, remova um, pague e veja se o carrinho é limpo após o sucesso.
- Se a API externa estiver offline, a aplicação exibirá o erro no console; tente novamente mais tarde.

## Próximos passos sugeridos
- Persistir o carrinho em arquivo ou banco (SQLite) para reabrir a sessão.
- Tratar ausência de `OPENAI_API_KEY` com fallback elegante (pular recomendações).
- Adicionar testes unitários para regras de carrinho e filtros LINQ.
- Gerar binários “self-contained” para distribuição sem requerer .NET instalado.

---
Feito para praticar C# e LINQ no console. Boa diversão!
