using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebSite
{
    public class PaginatedList<T>:List<T>
    {
        private int _countPosts;
        private int _countPages;
        private int _currentPageIndex = 0;

        //Индекс текущей страницы
        public int CurrentPageIndex 
        {
            get { return _currentPageIndex; }
        }
        //общее количество постов
        public int CountPosts
        {
            get { return _countPosts; }
        }
        //количество постов на странице
        public int CountPerPage { get; set; } = 3;
        
        //количество страниц
        public int CountPages
        {
            get { return (int) Math.Ceiling(_countPosts / (double)CountPerPage); }
        }

        public bool HasNextPage
        {
            get { return (CurrentPageIndex + 1 < CountPages); }
        }

        public bool HasPreviousPage
        {
            get { return (CurrentPageIndex - 1 >= 0); }
        }

        public PaginatedList(IQueryable<T> data, int pageIndex, int countPerPage)
        {
            _countPosts = data.Count();
            CountPerPage = countPerPage;
            if(pageIndex >= 0 && pageIndex < CountPages)
            {
                _currentPageIndex = pageIndex;
            }
            this.AddRange(data.Skip(_currentPageIndex * CountPerPage).Take(CountPerPage));
        }
    }
}