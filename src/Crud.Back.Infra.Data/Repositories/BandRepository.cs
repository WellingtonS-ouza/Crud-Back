﻿using Crud.Back.Domain.Entities;
using Crud.Back.Domain.Interfaces.Repositories;
using Crud.Back.Infra.Data.Context;

namespace Crud.Back.Infra.Data.Repositories
{
    public class BandRepository : BaseRepository<Band>, IBandRepository
    {
        private readonly CrudBackContext _context;
        
        public BandRepository(CrudBackContext context) : base(context)
        {
            _context = context;
        }
    }
}
