using Book.Infra.CrossCutting.Dtos;
using FluentValidation;

namespace Book.Infra.CrossCutting.Validators;

public class BookFilterDtoValidator : AbstractValidator<BookFilterDto>
{
    public BookFilterDtoValidator()
    {
        RuleFor(dto => dto)
            .Must(HaveAtLeastOnePropertyWithValue)
            .WithMessage("Needs to have at least one property with value");
    }
    
    private static bool HaveAtLeastOnePropertyWithValue(BookFilterDto dto)
    {
        return !string.IsNullOrWhiteSpace(dto.AuthorName) ||
               !string.IsNullOrWhiteSpace(dto.Title) ||
               dto.MinPrice.HasValue ||
               dto.MaxPrice.HasValue ||
               dto.MinDate.HasValue ||
               dto.MaxDate.HasValue;
    }
}