using FluentValidation;

namespace MyRESTServices.BLL.DTOs.Validation
{
    public class ArticleCreateDTOValidator : AbstractValidator<ArticleCreateDTO>
    {
        public ArticleCreateDTOValidator()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("Title harus diisi");
            RuleFor(x => x.Title).MaximumLength(100).WithMessage("Title maksimal 50 karakter");
        }
    }
}
