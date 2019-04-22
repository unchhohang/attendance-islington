using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace attendance_beta2.Models
{
    public class ApplicationUserRolesViewModel
    {
        public virtual string UserId { get; set; }
        public virtual string RoleId { get; set; }
    }
}