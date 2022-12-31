using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IRepositories
{
    public interface _IGenericService<TDTO> where TDTO : class
    {
        TDTO GetByID(Guid id);
        void Insert(TDTO dto);
    }
}
