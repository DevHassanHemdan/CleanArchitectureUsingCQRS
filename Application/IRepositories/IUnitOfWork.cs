using Domain;
using Presistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IRepositories
{
    public interface IUnitOfWork
    {
        public _IGenericRepository<Product> Products { get; }
        public _IGenericRepository<Categories> Categories { get;  }
        Task Save();
    }
}
