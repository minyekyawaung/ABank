using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
namespace aplus_back_seed.Models
{
    public class AplusContext : DbContext
    {
        
         public AplusContext(DbContextOptions<AplusContext> options) : base(options)  
        {  
            //to allow Datetime UTC (Time with Time Zone)
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
            
        }  
        public DbSet<User>? users { get; set; }

    }

    #region User
    public class User
    {

        [Key]
        public int UID { get; set; }

        public string? NRC { get; set; }
        public string? Mobile_no { get; set; }

        public string? Email { get; set; }

        public string? PIN { get; set; }

        public string? UserType { get; set; }

        public string? Status { get; set; }

       public Boolean? ForcedChangePIN { get; set; }

       public Boolean? DeleteFlag { get; set; }

       public DateTimeOffset? EditedAt { get; set; }

       public DateTimeOffset? CreatedAt { get; set; }
    
    }
    #endregion

    

   
}