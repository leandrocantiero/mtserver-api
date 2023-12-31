﻿namespace mtvendors_api.Models.Helpers
{
    public class PagedResult<T>
    {
        public IEnumerable<T> Data { get; set; }

        public int Count { get; set; }

        public PagedResult()
        {
            Data = new List<T>();
            Count = 0;
        }
    }
}
