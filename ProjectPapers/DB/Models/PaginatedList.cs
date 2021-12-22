using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ProjectPapers.DB.Models
{
    public class PaginatedList<TSource>
    {
        public uint CurrentPage { get; private set; }
        public uint From { get; private set; }
        public List<TSource> Items { get; private set; }
        public uint PageSize { get; private set; }
        public uint To { get; private set; }
        public uint TotalCount { get; private set; }
        public uint TotalPages { get; private set; }
        public PaginatedList(List<TSource> items, uint count, uint currentPage, uint pageSize)
        {
            CurrentPage = currentPage;
            TotalPages = (uint)Math.Ceiling(count / (double)pageSize);
            TotalCount = count;
            PageSize = pageSize;
            From = ((currentPage - 1) * pageSize) + 1;
            To = (From + pageSize) - 1;
            Items = items;
        }
        public bool HasPreviousPage
        {
            get
            {
                return (CurrentPage > 1);
            }
        }
        public bool HasNextPage
        {
            get
            {
                return (CurrentPage < TotalPages);
            }
        }
        public static async Task<PaginatedList<TSource>> CreateAsync(
            IQueryable<TSource> source, uint currentPage, uint pageSize)
        {
            var count = (uint)await source.CountAsync();
            source = source.Skip((int)((currentPage - 1) * pageSize))
                .Take((int)pageSize);
            var items = await source.ToListAsync();
            return new PaginatedList<TSource>(items, count, currentPage, pageSize);
        }
    }
}
