# FastResults

---

- [Documentation PT-BR](https://github.com/AkioSerizawa/FastResults/blob/main/README-PT.md)

## Package created to assist in the development and management of API results throughout the application.

This package was designed based on three fundamental pillars for the application:
**Controller**, **Response**, **Error**, and **Result between layers**.

---

## Controller:


The main goal in developing the BaseController is to provide a solid and reusable structure for controllers within the 
application. This component serves as a fundamental foundation for other controllers, 
offering essential and standardized functionalities that facilitate code development and maintenance.

- Components:
    - BaseResponse
    - BaseController

### BaseResponse:

- This is the standard format for API responses, which includes two main properties:
  - **TResponse:** Represents the content of the response, which may vary depending on the context of the request.
  - **[Error](#error):** Error displayed on the screen for the user.
    
### BaseController:

The BaseController is an abstract class that serves as a fundamental structure for controllers in the application. 
It provides standard methods for response return, promoting consistency and code reuse throughout the system.

- **Response:** This standard method is used to return a generic response from the controller. It is useful when there is no need to specify the type of response.

- **Response<T>:** This overloaded method is used when it's necessary to return a response with a specific type, identified by the parameter `T`. This provides flexibility to handle different types of responses in a generic manner.

These methods allow controllers to effectively communicate with the requests received by the API, 
providing consistent responses tailored to the specific needs of each context.

---

## Error:

- **Default Application Error**: This is an error model that can be used throughout the application to establish a consistent error handling pattern. It includes the following properties:
  - **Status Code:** The HTTP status code indicating the type of error that occurred.
  - **Type:** The error type, which can be used to categorize the issue.
  - **Message:** A descriptive message providing details about the error that occurred.

---

## Result:
Communication between different layers of an application is crucial for its efficient operation. 
The Result between layers component aims to facilitate this communication by providing a cohesive and effective structure 
for sharing results among various parts of the application. With a solid implementation of the Result between layers, 
it is possible to ensure efficient and reliable data exchange between different modules and components of the application.

--- 

## Implementantion
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
