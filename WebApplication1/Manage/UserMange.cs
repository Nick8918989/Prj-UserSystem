using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;
using WebApplication1.Models.Entity;
using static WebApplication1.Models.Enum.EnumType;

namespace WebApplication1.Manage
{
    public class UserMange
    {
        private readonly PortfolioContext _Context;
        private readonly ILogger<UserMange> _Logger;

        public UserMange(PortfolioContext _context, ILogger<UserMange> _logger)
        {
            _Context = _context;
            _Logger = _logger;
        }

        public IQueryable<UserBasic> QryUserBasic()
        {
            return _Context.UserBasic.AsQueryable();
        }

        public async Task<UserBasic> QryUserBasicAsyncByPK(long _userPK)
        {
            return await _Context.UserBasic.FirstOrDefaultAsync(x => x.UserPK == _userPK);
        }

        public async Task<IQueryable<UserBasic>> QryUserBasicListAsync()
        {
            //非同步要記得加這段 關鍵字原本ToList直接改為Async的關鍵字
            var data = await _Context.UserBasic.ToListAsync();

            //List-1版
            //var DATA2 = await Task.FromResult<List<UserBasic>>(QUERY.ToList());

            //List-2版
            //var DATA2 = await Task.FromResult(QUERY).Result.FirstOrDefaultAsync();
            return data.AsQueryable();
        }

        public async Task<ReturnResult> InsertUserBasicAsync(UserBasic _userBasic)
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
                    _Logger.LogError(ex.Message);
                    return result;
                }
            }
        }

        public async Task<ReturnResult> UpdateUserBasicAsync(string _appFunction, string _appIp, UserBasic _userBasic, bool _begin_transaction = true)
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
                    UserBasic user = await QryUserBasicAsyncByPK(_userBasic.UserPK);
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
                    _Logger.LogError(ex.Message);
                    return result;
                }
            }
        }

        public async Task<ReturnResult> DeleteUserBasicAsync(long _userPK, bool _isEntity = false)
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
                    UserBasic user = QryUserBasicAsyncByPK(_userPK).Result;
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
                    _Logger.LogError(ex.Message);
                    return result;
                }
            }
        }
    }
}