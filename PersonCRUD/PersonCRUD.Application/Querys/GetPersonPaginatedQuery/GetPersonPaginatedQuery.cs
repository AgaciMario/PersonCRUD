using MediatR;
using PersonCRUD.Application.DTOs;

namespace PersonCRUD.Application.Querys.GetPersonPaginatedQuery
{
    public class GetPersonPaginatedQuery : IRequest<GetPersonPaginatedDTO>
    {
        public GetPersonPaginatedQuery(int currentPage, int pageSize, string? nameFilter)
        {
            if(currentPage <= 0) 
                throw new ArgumentException("CurrentPage must be greater than zero.", nameof(CurrentPage));

            if (pageSize <= 0)
                throw new ArgumentException("PageSize must be greater than zero.", nameof(PageSize));

            CurrentPage = currentPage;
            PageSize = pageSize;
            NameFilter = nameFilter;
        }

        public int CurrentPage { get; } = 1;
        public int PageSize { get; } = 10;
        public string? NameFilter { get; }
    }
}
