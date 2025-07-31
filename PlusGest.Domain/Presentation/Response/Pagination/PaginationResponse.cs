namespace PlusGest.Domain.Presentation.Response.Pagination
{
    public class PaginationResponse<T>
    {
        #region Propriedades
        public IEnumerable<T> List { get; set; } = [];
        public int Page { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; } 
        #endregion
    }
}