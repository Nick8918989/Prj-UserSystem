using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Manage
{
    interface IBaseManage<T>
    {
        IQueryable<T> Qry();

        Task<T> QryAsyncByPK(long PK);

        Task<IQueryable<T>> QryListAsync();

        Task<ReturnResult> InsertAsync(T Data, bool isTran);

        Task<ReturnResult> UpdateAsync(T Data, bool isTran);

        Task<ReturnResult> DeleteAsync(long PK, bool isEntity);
    }
}