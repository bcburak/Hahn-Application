﻿using Hahn.ApplicatonProcess.July2021.Data.Interfaces;
using Hahn.ApplicatonProcess.July2021.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hahn.ApplicatonProcess.July2021.Data.Infrastructure
{
    public class UserRepository: Repository<Users>, IUserRepository
    {

        public UserRepository(MainDbContext context, ILogger logger) : base(context, logger) {
        
        }

        //public override async Task<List<Users>> ListAllAsync()
        //{
        //    try
        //    {
        //        return await _dbSet.ToListAsync();
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError(ex, "{Repo} All function error", typeof(UserRepository));
        //        return new List<Users>();
        //    }
        //}
    }
}
