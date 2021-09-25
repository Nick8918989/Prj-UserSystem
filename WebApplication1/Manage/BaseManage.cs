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

        Task<T> QryAsyncByPK(long pk);

        Task<List<T>> QryListAsync();

        Task<ReturnResult> InsertAsync(T data, bool isTran);

        Task<ReturnResult> UpdateAsync(T data, bool isTran);

        Task<ReturnResult> DeleteAsync(long pk, bool isEntity);
    }
}