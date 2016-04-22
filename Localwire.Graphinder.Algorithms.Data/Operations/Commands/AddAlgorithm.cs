﻿namespace Localwire.Graphinder.Algorithms.DataAccess.Operations.Commands
{
    using System;
    using System.Threading.Tasks;
    using Core.Algorithms;
    using Mappers.Algorithms;

    public class AddAlgorithm : SqlServerOperation
    {
        private IAlgorithm _algorithm;

        public AddAlgorithm(IAlgorithm algorithm)
        {
            if (algorithm == null)
                throw new ArgumentNullException(nameof(algorithm));
            _algorithm = algorithm;
        }

        public async Task<bool> ExecuteAsync()
        {
            var resolvedEntity = _algorithm.AsEntityModelResolved();
            if (resolvedEntity == null)
                 return false;
            Context.Algorithms.Add(resolvedEntity);
            await Context.SaveChangesAsync();
            return true;
        }

        public bool Execute()
        {
            var resolvedEntity = _algorithm.AsEntityModelResolved();
            if (resolvedEntity == null)
                return false;
            Context.Algorithms.Add(resolvedEntity);
            Context.SaveChanges();
            return true;
        }
    }
}
