using System;

namespace erp_ecommerce.Models
{
    public class PagedResponse<T>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalPages { get; set; }
        public int TotalRecords { get; set; }
        public T Data { get; set; }
        public PagedResponse(T data, int pageNumber, int pageSize, int totalRecords, int totalPages)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
            TotalRecords = totalRecords;
            TotalPages = totalPages;
            Data = data;
        }
    }
}
