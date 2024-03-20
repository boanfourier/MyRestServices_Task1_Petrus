using FluentValidation;

namespace MyRESTServices.BLL.DTOs.Validation
{
    public class ArticleUpdateDTOValidator : AbstractValidator<ArticleUpdateDTO>
    {
        public ArticleUpdateDTOValidator()
        {
            RuleFor(x => x.ArticleID).NotEmpty().WithMessage("Article ID harus diisi");

            RuleFor(x => x.Title).NotEmpty().WithMessage("Title harus diisi");
        }
    }
}
