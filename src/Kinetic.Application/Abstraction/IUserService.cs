using Kinetic.Core.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kinetic.Application.Abstraction
{
    public interface IUserService
    {
        User GetCurrentUser(HttpContext context);
    }
}
