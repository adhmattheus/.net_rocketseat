using CashFlow.Application.UseCases.Expenses.GetAll;
using CashFlow.Application.UseCases.Expenses.Register;
using CashFlow.Communication.Requests;
using CashFlow.Communication.Responses;
using Microsoft.AspNetCore.Mvc;

namespace CashFlow.Api.Controllers;

[Route("api/expenses")]
[ApiController]
public class ExpensesController : ControllerBase
{
  [HttpPost]
  [ProducesResponseType(typeof(ResponseRegisterExpenseJson), StatusCodes.Status201Created)]
  [ProducesResponseType(typeof(ResponseRegisterExpenseJson), StatusCodes.Status400BadRequest)]
  public async Task<IActionResult> Register(
    [FromServices] IRegisterExpenseUseCase useCase,
    [FromBody] RequestRegisterExpenseJson request)
  {
    var response = await useCase.Execute(request);

    return Created(string.Empty, response);
  }

  [HttpGet]
  [ProducesResponseType(typeof(ResponseExpensesJson), StatusCodes.Status200OK)]
  [ProducesResponseType(StatusCodes.Status404NotFound)]
  public async Task<IActionResult> GetAllExpenses([FromServices] IGetAllExpenseUseCase useCase)
  {
    var response = await useCase.Execute();

    if (response.Expenses.Any())
      return Ok(response);

    return NotFound();
  }
}
