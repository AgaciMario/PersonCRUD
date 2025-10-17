namespace PersonCRUD.Application.DTOs
{
    public class GetPersonPaginatedDTO(int totalCount, int pageSize, int currentPage, List<PersonDTO> data)
    {
        public int TotalCount { get; } = totalCount;
        public int PageSize { get; } = pageSize;
        public int CurrentPage { get; } = currentPage;
        public List<PersonDTO> Data { get; } = data;
    }
}
