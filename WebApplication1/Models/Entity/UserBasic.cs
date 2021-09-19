using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models.Entity
{
    public class UserBasic : BaseEntity
    {
        /// <summary>
        /// 使用者唯一識別碼
        /// 說明：
        /// </summary>
        [Column("UserPK"), Display(Name = "使用者唯一識別碼")]
        [Key, Required, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long UserPK { get; set; }

        /// <summary>
        /// 姓名
        /// 說明：
        /// </summary>
        [Column("UserName"), Display(Name = "姓名"), MaxLength(120)]
        [Required]
        public string UserName { get; set; }

        /// <summary>
        /// 英文姓名
        /// 說明：
        /// </summary>
        [Column("UserEngName"), Display(Name = "英文姓名"), MaxLength(150)]
        public string UserEngName { get; set; }

        /// <summary>
        /// 職稱
        /// 說明：
        /// </summary>
        [Column("UserJobTitle"), Display(Name = "職稱"), MaxLength(100)]
        public string UserJobTitle { get; set; }
    }
}