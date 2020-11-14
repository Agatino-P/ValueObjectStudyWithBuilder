using FluentValidation;

namespace Core
{
    public partial class PrgParam
    {
        public class Validator : AbstractValidator<PrgParam>
        {
            public Validator()
            {
                RuleFor(pp => pp.Number).InclusiveBetween(1,79);
                RuleFor(pp => pp.Desc).NotNull();
            }

        }
    }
}
