# FastResults

- [Documentação EN](https://github.com/AkioSerizawa/FastResults/blob/main/README.md)
- [NuGet](https://www.nuget.org/packages/FastResults)

---

## Pacote criado para auxiliar no desenvolvimento e gerenciamento de resultados da API ao longo da aplicação

Este pacote foi concebido com base em três pilares fundamentais para a aplicação:
**Controller**, **Response**, **Error** e **Result entre camadas**.

---

## Controller:

O objetivo principal ao desenvolver o **BaseController** é proporcionar uma estrutura sólida e reutilizável para os
controladores dentro da aplicação. Este componente serve como uma base fundamental para os demais controladores,
oferecendo funcionalidades essenciais e padronizadas que facilitam o desenvolvimento e a manutenção do código.

- Componentes:
    - BaseResponse
    - BaseController

### BaseResponse:

- Este é o formato padrão de resposta da API, que inclui duas propriedades principais:
  - **TResponse:** Representa o conteúdo da resposta, que pode variar dependendo do contexto da solicitação.
  - **[Error](#error):** Erro mostrado na tela para o usuario.

### BaseController:

A `BaseController` é uma classe abstrata que serve como uma estrutura fundamental para os controladores na aplicação. 
Ela fornece métodos padrão para retorno de resposta, promovendo consistência e reutilização de código em todo o sistema.

- **Response:** Este método padrão é utilizado para retornar uma resposta genérica do controlador. Ele é útil quando não há necessidade de especificar o tipo de resposta.

- **Response<T>:** Este método sobrecarregado é utilizado quando é necessário retornar uma resposta com um tipo específico, identificado pelo parâmetro `T`. Isso oferece flexibilidade para lidar com diferentes tipos de respostas de forma genérica.

Esses métodos permitem que os controladores comuniquem-se de forma eficaz com as requisições recebidas pela API, 
fornecendo respostas consistentes e adequadas às necessidades específicas de cada contexto.

---

## Error:

- **Erro padrão da aplicação:** Este é um modelo de erro que pode ser utilizado em toda a aplicação para estabelecer um padrão consistente de tratamento de erros. Ele inclui as seguintes propriedades:
  - **Status Code:** O código de status HTTP que indica o tipo de erro que ocorreu.
  - **Tipo:** O tipo de erro, que pode ser usado para categorizar o problema.
  - **Mensagem:** Uma mensagem descritiva que fornece detalhes sobre o erro ocorrido.

---

## Result:
A comunicação entre as diferentes camadas de uma aplicação é crucial para o seu funcionamento eficiente. 
O componente Result entre camadas visa facilitar essa comunicação, fornecendo uma estrutura coesa e eficaz para o 
compartilhamento de resultados entre as diversas partes da aplicação. Com uma implementação sólida do Result entre camadas, 
é possível garantir uma troca de dados eficiente e confiável entre os diferentes módulos e componentes da aplicação.

--- 

## Implementando
```.ASP.NET (C#)
[Route("[controller]")]
public class HomeController : BaseController
{
    private readonly ProductServices _productServices = new ProductServices();

    [HttpGet]
    public ActionResult Get()
    {
        var result = _productServices.GetProduct(Guid.NewGuid());
        return Response(result);
    }
}

public class ProductServices()
{
    public BaseResult<ProductDto> GetProduct(Guid id)
    {
        var validate = Validate(id);
        if (validate.IsFailure)
        {
            return BaseResult.Failure<ProductDto>(validate.Error);
        }

        return BaseResult.Sucess(new ProductDto(id, "Test"));
    }

    private BaseResult Validate(Guid? id)
    {
        if (id is null)
        {
            return BaseResult.Failure("Not Found");
        }

        return BaseResult.Sucess();
    }
}

public record ProductDto(
    Guid Id,
    string Name);
```