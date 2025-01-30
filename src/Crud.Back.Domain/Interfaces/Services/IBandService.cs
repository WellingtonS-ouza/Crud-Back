﻿using Crud.Back.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Crud.Back.Domain.Interfaces.Services
{

    public interface IBandService 
    {
        Task<IEnumerable<Band>> GetAll();
    }
}