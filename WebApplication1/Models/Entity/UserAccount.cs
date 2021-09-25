using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models.Entity
{
    public class UserAccount : BaseEntity
    {
        /// <summary>
        /// 使用者帳號唯一識別碼
        /// 說明：
        /// </summary>
        [Column("UserAccountPK"), Display(Name = "使用者帳號唯一識別碼")]
        [Key, Required, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long UserAccountPK { get; set; }

        /// <summary>
        /// UserPK
        /// 說明：
        /// </summary>
        [Column("UserPK"), Display(Name = "UserPK")]
        [Required]
        public long UserPK { get; set; }

        /// <summary>
        /// 帳號
        /// 說明：
        /// </summary>
        [Column("AccountID"), Display(Name = "帳號"), MaxLength(50)]
        [Required]
        public string AccountID { get; set; }

        /// <summary>
        /// 密碼
        /// 說明：
        /// </summary>
        [Column("AccountPWD"), Display(Name = "密碼"), MaxLength(50)]
        [Required]
        public string AccountPWD { get; set; }
    }
}