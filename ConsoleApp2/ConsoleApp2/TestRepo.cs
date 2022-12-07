using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal class TestRepo<T> : ITestRepo<T> where T : class
    {
        internal TestContext context;
        internal DbSet<T> dbSet;
        public TestRepo(TestContext testContext) { 
            this.context = testContext;
            this.dbSet = context.Set<T>();
        }

        public virtual IEnumerable<T> GetEntities(
             Expression<Func<T, bool>> where,
             Func<IQueryable<T>, IIncludableQueryable<T, object>> includes
             )
        {
            IQueryable<T> query = dbSet;

            if (where != null)
            {
                query = query.Where(where);
            }

            if (includes != null)
            {
                query.AsSplitQuery();
                query = includes(query);

            }

            return query.ToList();
        }
    }
}
