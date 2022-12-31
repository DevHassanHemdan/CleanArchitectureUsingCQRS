using Application.IRepositories;
using Presistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repositories
{
    public class _GenericService<TDTO> : _IGenericService<TDTO> where TDTO : class
    {
        private readonly DataContext _context;
        public _GenericService(DataContext context)
        {
            _context = context;
        }

        public TDTO GetByID(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Insert(TDTO dto)
        {
            _context.Set<TDTO>().Add(dto);
        }
    }
}
