﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesComponents
{
    public interface IRepository
    {

        void Add(string beer);
        string Get();
    }
}
