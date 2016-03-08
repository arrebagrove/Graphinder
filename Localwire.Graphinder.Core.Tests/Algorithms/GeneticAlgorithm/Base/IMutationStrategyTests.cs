﻿namespace Localwire.Graphinder.Core.Tests.Algorithms.GeneticAlgorithm.Base
{
    using System;
    using Core.Algorithms.GeneticAlgorithm;
    using Core.Algorithms.GeneticAlgorithm.MutationStrategies;
    using Providers;
    using Providers.TestData;
    using Xunit;

    public abstract class IMutationStrategyTests
    {
        protected IMutationStrategy Strategy;
        protected ITestDataProvider<Individual> IndividualProvider; 

        protected IMutationStrategyTests()
        {
            IndividualProvider = new TestIndividualProvider();
        }

        [Fact]
        public void IMutationStrategy_Mutate_ThrowsOnNullIndividual()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Strategy.Mutate(null);
            });

            Strategy.Mutate(IndividualProvider.ProvideValid());
        }
    }
}
