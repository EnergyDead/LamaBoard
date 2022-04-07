using FluentValidation;

namespace Application.Projects.Queries;

public class GetProjectsWithPaginationQueryValidator : AbstractValidator<GetProjectsWithPaginationQuery>
{
    public GetProjectsWithPaginationQueryValidator()
    {
        RuleFor( x => x.ListId )
            .NotEmpty().WithMessage( "ListId is required." );

        RuleFor( x => x.PageIndex )
            .GreaterThanOrEqualTo( 1 ).WithMessage( "PageIndex at least greater than or equal to 1." );

        RuleFor( x => x.PageSize )
            .GreaterThanOrEqualTo( 1 ).WithMessage( "PageSize at least greater than or equal to 1." );
    }
}
