using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models.Entity
{
    public class UserRole : BaseEntity
    {
        /// <summary>
        /// 使用者身份唯一識別碼
        /// 說明：
        /// </summary>
        [Column("UserRolePK"), Display(Name = "使用者身份唯一識別碼")]
        [Key, Required, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long UserRolePK { get; set; }

        /// <summary>
        /// UserPK
        /// 說明：
        /// </summary>
        [Column("UserPK"), Display(Name = "UserPK")]
        [Required]
        public long UserPK { get; set; }

        /// <summary>
        /// UserAccountPK
        /// 說明：
        /// </summary>
        [Column("UserAccountPK"), Display(Name = "UserAccountPK")]
        [Required]
        public long UserAccountPK { get; set; }

        /// <summary>
        /// 帳號身份
        /// 說明：
        /// </summary>
        [Column("AccountRole"), Display(Name = "帳號身份")]
        [Required]
        public long AccountRole { get; set; }
    }
}