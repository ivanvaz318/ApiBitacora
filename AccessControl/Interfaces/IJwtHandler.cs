using AccessControl.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessControl.Interfaces
{
    public interface IJwtHandler
    {
        JsonWebToken Create(string username);
    }
}
