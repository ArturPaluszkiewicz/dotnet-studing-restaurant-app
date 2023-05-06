using FluentValidation;
using RestaurantApi.Entities;

namespace RestaurantApi.Models.Validators
{
    public class CreateUserDtoValidator : AbstractValidator<CreateUserDto>
    {
        public CreateUserDtoValidator(RestaurantDbContext dbContext)
        {
            RuleFor(r => r.Email)
                .NotEmpty()
                .EmailAddress();
            
            RuleFor(r => r.Password)
                .MinimumLength(6);

            RuleFor(r => r.ConfirmPassword)
                .Equal(e => e.Password);

            RuleFor(r => r.Email)
                .Custom((value, context) => {
                    var emailInUse = dbContext.Users.Any(u => u.Email == value);
                    if(emailInUse){
                        context.AddFailure("Email","That Email is already in use");
                    }
                });
        }
    }
}