using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public interface ITestRepo<T> where T : class
    {
         IEnumerable<T> GetEntities(
            Expression<Func<T, bool>> where,
            Func<IQueryable<T>, IIncludableQueryable<T, object>> includes
            );
    }
}
