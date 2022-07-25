﻿using CleanArhitectureNetCore.Application.Common.Contracts.Repositories;
using CleanArhitectureNetCore.Domain.Entities;
using CleanArhitectureNetCore.Infrastructure.Persistence.Common;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArhitectureNetCore.Infrastructure.Persistence.Dapper.Repositories
{
    public class ValuesRepository : RepositoryBase, IValuesRepository
    {


        public ValuesRepository(IDbTransaction transaction) : base(transaction)
        {
        }
        public Value Add(Value entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity");

            return base.AddOrUpdate<Value>(Procedures.InsertValue, new { val = entity.Val });
        }

        public Value Delete(long Id)
        {
            throw new NotImplementedException();
        }

        public Value Get(long Id)
        {
            return base.Get<Value>(Procedures.GetValue, Id);
        }

        public IEnumerable<Value> Get()
        {
            return Connection.Query<Value>(
                Procedures.GetAllValues,
                param: null,
                transaction: base.Transaction,
                commandType: CommandType.StoredProcedure
            );
        }

        public Value Update(Value entity)
        {
            throw new NotImplementedException();
        }
    }
}
