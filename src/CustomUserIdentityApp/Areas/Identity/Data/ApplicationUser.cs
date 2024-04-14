using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace CustomUserIdentityApp.Areas.Identity.Data;

// Add profile data for application users by adding properties to the CustomAppUser class
public class ApplicationUser : IdentityUser<long>
{
    [PersonalData]
    public string? Name { get; set; }
    [PersonalData]
    public DateTime? DOB { get; set; }
    
    public virtual ICollection<ApplicationUserClaim> Claims { get; set; }
    public virtual ICollection<ApplicationUserLogin> Logins { get; set; }
    public virtual ICollection<ApplicationUserToken> Tokens { get; set; }
    public virtual ICollection<ApplicationUserRole> UserRoles { get; set; }
}

public class ApplicationRole : IdentityRole<long>
{
    public virtual ICollection<ApplicationUserRole> UserRoles { get; set; }
    public virtual ICollection<ApplicationRoleClaim> RoleClaims { get; set; }
}

public class ApplicationUserRole : IdentityUserRole<long>
{
    public virtual ApplicationUser User { get; set; }
    public virtual ApplicationRole Role { get; set; }
}

public class ApplicationUserClaim : IdentityUserClaim<long>
{
    public virtual ApplicationUser User { get; set; }
}

public class ApplicationRoleClaim : IdentityRoleClaim<long>
{
    public virtual ApplicationRole Role { get; set; }
}

public class ApplicationUserLogin : IdentityUserLogin<long>
{
    public virtual ApplicationUser User { get; set; }
}

public class ApplicationUserToken : IdentityUserToken<long>
{
    public virtual ApplicationUser User { get; set; }
}