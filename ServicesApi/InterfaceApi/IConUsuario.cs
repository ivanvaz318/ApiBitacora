﻿using ModelsApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesApi.InterfaceApi
{
    public interface IConUsuario
    {
        public ModelApiResponse ConUser(int idUser);
    }
}
