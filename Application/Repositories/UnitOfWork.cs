using Application.IRepositories;
using Domain;
using HotelListing.Core.Repository;
using Presistance;

namespace Application.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        public DataContext _context { get; set; }
        private _IGenericRepository<Product> _products;
        private _IGenericRepository<Categories> _categories;

        public UnitOfWork(DataContext context)
        {
            _context = context;
        }
        public _IGenericRepository<Product> Products => _products ??= new _GenericRepository<Product>(_context);
        public _IGenericRepository<Categories> Categories => _categories ??= new _GenericRepository<Categories>(_context);

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}
