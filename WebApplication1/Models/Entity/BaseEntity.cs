using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using static WebApplication1.Models.Enum.EnumType;

namespace WebApplication1.Models.Entity
{
    public class BaseEntity
    {
        /// <summary>
        /// 資料建立日期
        /// 說明：
        /// </summary>
        [Column("CreateDate"), Display(Name = "資料建立日期")]
        [Required]
        public DateTime CreateDate { get; set; }

        /// <summary>
        /// 資料修改日期
        /// 說明：
        /// </summary>
        [Column("ModifyDate"), Display(Name = "資料修改日期")]
        public DateTime? ModifyDate { get; set; }

        /// <summary>
        /// 建立者UserPK
        /// 說明：
        /// </summary>
        [Column("CreateUserPK"), Display(Name = "建立者UserPK")]
        [Required]
        public long CreateUserPK { get; set; }

        /// <summary>
        /// 修改者UserPK
        /// 說明：
        /// </summary>
        [Column("ModifyUserPK"), Display(Name = "修改者UserPK")]
        public long? ModifyUserPK { get; set; }

        /// <summary>
        /// 資料狀態
        /// 說明：[0=正常(預設)], [1=刪除]
        /// </summary>
        [Column("DataStatus"), Display(Name = "資料狀態")]
        [Required]
        public DataStatus DataStatus { get; set; }
    }
}
