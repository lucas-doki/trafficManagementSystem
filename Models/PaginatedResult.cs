using System.Collections.Generic;

namespace TrafficManagementSystem.Models
{
    public class PaginatedResult<T>
    {
        public int TotalCount { get; set; }
        public int PageSize { get; set; }
        public int CurrentPage { get; set; }
        public List<T> Items { get; set; }
    }
}
