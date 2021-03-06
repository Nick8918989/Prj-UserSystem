using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using WebApplication1.Models;
using WebApplication1.Models.Entity;
using WebApplication1.Utilities;
using static WebApplication1.Models.Enum.EnumType;

namespace WebApplication1.Manage
{
    public class UserMange : IBaseManage<UserBasic>
    {
        private readonly PortfolioContext _Context;
        private readonly ILogger<UserMange> _Logger;

        public UserMange(PortfolioContext _context, ILogger<UserMange> _logger)
        {
            _Context = _context;
            _Logger = _logger;
        }

        public IQueryable<UserBasic> Qry()
        {
            return _Context.UserBasic.AsQueryable();
        }

        public async Task<UserBasic> QryAsyncByPK(long _userPK)
        {
            return await _Context.UserBasic.FirstOrDefaultAsync(x => x.UserPK == _userPK);
        }

        public async Task<List<UserBasic>> QryListAsync()
        {
            return await _Context.UserBasic.ToListAsync();
        }

        public async Task<ReturnResult> InsertAsync(UserBasic _userBasic, bool _begin_transaction = true)
        {
            ReturnResult result = new ReturnResult();
            using (IDbContextTransaction transaction = _Context.Database.BeginTransaction())
            {
                try
                {
                    if (string.IsNullOrEmpty(_userBasic.UserName))
                    {
                        throw new Exception("新增資料錯誤.SaveUserBasic-未填寫姓名");
                    }
                    _userBasic.CreateDate = DateTime.Now;
                    _userBasic.CreateUserPK = 0;
                    _Context.UserBasic.Add(_userBasic);
                    await _Context.SaveChangesAsync();
                    transaction.Commit();

                    result.ID = _userBasic.UserPK;
                    result.ResultStatus = ResultStatus.Success;
                    result.Message = "新增成功！！";
                    return result;
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    result.ResultStatus = ResultStatus.Failure;
                    result.Message = ex.Message;
                    _Logger.LogError(ex.Message + "=>" + _userBasic.ToJson());
                    return result;
                }
            }
        }

        public async Task<ReturnResult> UpdateAsync(UserBasic _userBasic, bool _begin_transaction = true)
        {
            ReturnResult result = new ReturnResult();
            using (IDbContextTransaction transaction = _Context.Database.BeginTransaction())
            {
                try
                {
                    if (_userBasic.UserPK == 0)
                    {
                        throw new Exception("更新資料錯誤-未帶入UserPK");
                    }
                    if (string.IsNullOrEmpty(_userBasic.UserName))
                    {
                        throw new Exception("更新資料錯誤-未填寫姓名");
                    }
                    UserBasic user = await QryAsyncByPK(_userBasic.UserPK);
                    if(user != null)
                    {
                        user.UserName = _userBasic.UserName;
                        user.UserEngName = _userBasic.UserEngName;
                        user.UserJobTitle = _userBasic.UserJobTitle;
                        user.ModifyDate = DateTime.Now;
                        user.ModifyUserPK = 0;

                        _Context.UserBasic.Update(user);
                        await _Context.SaveChangesAsync();
                        transaction.Commit();

                        result.ID = _userBasic.UserPK;
                        result.ResultStatus = ResultStatus.Success;
                        result.Message = "編輯成功！！";
                    }
                    else
                    {
                        result.ID = user.UserPK;
                        result.ResultStatus = ResultStatus.Error;
                        result.Message = "編輯資料錯誤-未找到相關人員";
                    }
                    return result;
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    result.ResultStatus = ResultStatus.Failure;
                    result.Message = ex.Message;
                    _Logger.LogError(ex.Message + "=>" + _userBasic.ToJson());
                    return result;
                }
            }
        }

        public async Task<ReturnResult> DeleteAsync(long _userPK, bool _isEntity = false)
        {
            ReturnResult result = new ReturnResult();
            using (IDbContextTransaction transaction = _Context.Database.BeginTransaction())
            {
                try
                {
                    if (_userPK == 0)
                    {
                        throw new Exception("刪除資料錯誤-未帶入UserPK");
                    }
                    UserBasic user = QryAsyncByPK(_userPK).Result;
                    if (user != null)
                    {
                        if (_isEntity)
                        {
                            _Context.UserBasic.Remove(user);
                        }
                        else
                        {
                            user.DataStatus = DataStatus.Deleted;
                            user.ModifyDate = DateTime.Now;
                            user.ModifyUserPK = 0;
                            _Context.UserBasic.Update(user);
                        }
                        await _Context.SaveChangesAsync();
                        transaction.Commit();
                        result.ID = _userPK;
                        result.ResultStatus = ResultStatus.Success;
                        result.Message = "刪除成功！！";
                    }
                    else
                    {
                        result.ID = _userPK;
                        result.ResultStatus = ResultStatus.Error;
                        result.Message = "未找到該人員！！";
                    }
                    return result;
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    result.ResultStatus = ResultStatus.Failure;
                    result.Message = ex.Message;
                    _Logger.LogError(ex.Message + "=>" + _userPK.ToJson());
                    return result;
                }
            }
        }
    }
}