    using CashFlow.Communication.Enums;
    using CashFlow.Communication.Requests;
    using CashFlow.Communication.Responses;
    using CashFlow.Exception.ExceptionBase;
    using System.Data;

    namespace CashFlow.Application.UseCases.Expenses.Register;
    public class RegisterExpenseUseCase
    {
        public static ResponseRegisterExpenseJson Execute(RequestRegisterExpenseJson request) 
        {
            Validate(request);
        return new ResponseRegisterExpenseJson
        {
            Title = request.Title
        };
    }

        private static void Validate(RequestRegisterExpenseJson request)
        {
            var validator = new RegisterExpenseValidator();
            var result = validator.Validate(request);

            if (!result.IsValid)
            {
                var errorMessages = result.Errors.Select(f => f.ErrorMessage).ToList();

                throw new ErrorOnValidationException(errorMessages);
            }
        }
    }
