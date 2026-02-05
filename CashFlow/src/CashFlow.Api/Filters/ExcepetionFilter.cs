using CashFlow.Communication.Responses;
using CashFlow.Exception;
using CashFlow.Exception.ExceptionBase;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace CashFlow.Api.Filters;

public class ExcepetionFilter : IExceptionFilter
{
  public void OnException(ExceptionContext context)
  {
    if (context.Exception is CashFlowException)
    {
      HandleProjectException(context);
    }

    else
    {
      ThrowUnkownError(context);
    }
  }

  private void HandleProjectException(ExceptionContext context)
  {
    var cashFlowException = (CashFlowException)context.Exception;
    var errorResponse = new ResponseErrorJson(cashFlowException.GetErros());

    context.HttpContext.Response.StatusCode = cashFlowException.StatusCode;
    context.Result = new ObjectResult(errorResponse);

  }

  private void ThrowUnkownError(ExceptionContext context)
  {
    var errorResponse = new ResponseErrorJson(ResourceErrorMessages.UNKNOW_ERROR);

    context.HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
    context.Result = new ObjectResult(errorResponse);

  }
}
