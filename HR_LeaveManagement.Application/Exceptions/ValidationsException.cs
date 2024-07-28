using FluentValidation.Results;

namespace HR_LeaveManagement.Application.Exceptions
{
    public class ValidationExceptions : ApplicationException
    {
        public List<string> Errors { get; set; } = new List<string>();
        public ValidationExceptions(ValidationResult validationResult)
        {
            foreach (var error in validationResult.Errors)
            {
                Errors.Add(error.ErrorMessage);
            }
        }
    }
}
