namespace Wordstag.API.Requests.Common
{
    public class PaginationRequest
    {
        public string? GlobalSearch { get; set; }
        public int? PageSize { get; set; }
        public int? PageIndex { get; set; }
        public string? OrderBy { get; set; }
        public string? OrderDirection { get; set; }
    }
}
