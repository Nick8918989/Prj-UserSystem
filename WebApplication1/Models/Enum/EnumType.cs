using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models.Enum
{
    public class EnumType
    {
        public enum DataStatus
        {
            /// <summary>
            /// 正常。
            /// </summary>
            [Description("啟用")]
            Normal = 0,

            /// <summary>
            /// 刪除
            /// </summary>
            [Description("刪除")]
            Deleted = 1,

            /// <summary>
            /// 停用
            /// </summary>
            [Description("停用")]
            Disabled = 2
        }

        /// <summary>
        /// 資料庫回傳狀態
        /// </summary>
        public enum ResultStatus
        {
            /// <summary>
            /// 失敗。
            /// </summary>
            [Description("失敗")]
            Failure = 0,
            /// <summary>
            /// 成功
            /// </summary>
            [Description("成功")]
            Success = 1,
            /// <summary>
            /// 異常
            /// </summary>
            [Description("異常")]
            Error = 2,
        }
    }
}