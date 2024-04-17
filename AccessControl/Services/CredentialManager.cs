using AccessControl.Interfaces;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessControl.Services
{
    public class CredentialManager : ICredentialManager
    {
        public CredentialManager() { }

        public bool addRegister(string key, string value)
        {
            return false;
        }

        public bool removeRegister(string key)
        {
            return true;
        }

        public bool registerExists(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return false;
            }

            var handler = new JwtSecurityTokenHandler();
            if (handler.CanReadToken(value))
            {
                var jsonToken = handler.ReadToken(value) as JwtSecurityToken;
                if (jsonToken != null && jsonToken.ValidTo > DateTime.Now)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
