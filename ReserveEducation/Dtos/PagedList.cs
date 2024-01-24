using System;
using System.Collections.Generic;
using System.Linq;

namespace ReserveEducation.Dtos
{
    public class PagedList<T>
    {
        public int TotalCount { get; set; }
        public int TotalPage { get; set; }
        public List<T> Data { get; set; }
        public PagedList(List<T> data, int pageNumber, int pageSize, int totalCount)
        {
            int totalPage = (int)Math.Ceiling((double)totalCount / pageSize);
            TotalCount = totalCount;
            TotalPage = totalPage > 0 ? totalPage : 1;
            Data = data.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
        }
    }
}
