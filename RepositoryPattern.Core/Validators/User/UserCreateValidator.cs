//using Chat.Core.Dto;
//using FluentValidation;

//namespace Chat.Core.Validators
//{
//    public class UserCreateValidator : AbstractValidator<UserCreate>
//    {
//        public UserCreateValidator()
//        {
//            RuleFor(x => x.FirstName)
//                .NotEmpty()
//                .WithName("First Name")
//                .WithMessage(ValidationErrorMessage.Required)
//                .MaximumLength(50)
//                .WithMessage(ValidationErrorMessage.MaxLength);

//            RuleFor(x => x.LastName)
//                .NotEmpty()
//                .WithName("Last Name")
//                .WithMessage(ValidationErrorMessage.Required)
//                .MaximumLength(50)
//                .WithMessage(ValidationErrorMessage.MaxLength);

//            RuleFor(x => x.Avatar)
//                .NotEmpty()
//                .WithMessage(ValidationErrorMessage.Required)
//                .MaximumLength(50)
//                .WithMessage(ValidationErrorMessage.MaxLength);
//        }
//    }
//}
