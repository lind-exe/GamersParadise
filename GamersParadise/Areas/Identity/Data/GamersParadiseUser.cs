using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace GamersParadise.Areas.Identity.Data;

// Add profile data for application users by adding properties to the GamersParadiseUser class
[Index(nameof (NickName), IsUnique = true)]
public class GamersParadiseUser : IdentityUser
{
    [PersonalData]
    public string FirstName { get; set; }
    [PersonalData]
    public string LastName { get; set; }
    [PersonalData]
    public string NickName { get; set; }
    [PersonalData]
    public int BirthYear { get; set; }
}

