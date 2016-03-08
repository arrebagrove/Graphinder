﻿namespace Localwire.Graphinder.Core.Tests.Algorithms.GeneticAlgorithm.Base
{
    using System;
    using System.Collections.Generic;
    using Core.Algorithms.GeneticAlgorithm;
    using Core.Algorithms.GeneticAlgorithm.SelectionStrategies;
    using Core.Graph;
    using Core.Problems;
    using Exceptions;
    using Providers;
    using Providers.SubstituteData;
    using Providers.TestData;
    using Xunit;

    public abstract class ISelectionStrategyTests
    {
        protected ISelectionStrategy Strategy;
        protected readonly ITestDataProvider<Individual> IndividualProvider = new TestIndividualProvider();
        protected readonly ITestDataProvider<Graph> GraphDataProvider = new TestGraphProvider();
        protected readonly ISubstituteProvider<IProblem> ProblemProvider = new ProblemSubstituteProvider(); 

        protected ISelectionStrategyTests()
        {
        }

        [Fact]
        public void ISelectionStrategy_Set_ThrowsOnNullPopulation()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Strategy.Set(null);
            });

            Strategy.Set(new List<Individual>());
        }

        [Fact]
        public void ISelectionStrategy_Set_ThrowsOnProblemMismatch()
        {
            Assert.Throws<AlgorithmException>(() =>
            {
                var graph = GraphDataProvider.ProvideValid();
                var problem = ProblemProvider.ProvideSubstitute();
                var individuals = new List<Individual>
                {
                    new Individual(graph, problem),
                    new Individual(graph, ProblemProvider.ProvideSubstitute())
                };
                Strategy.Set(individuals);
            });
        }

        [Fact]
        public void ISelectionStrategy_Set_ThrowsOnGraphMismatch()
        {
            Assert.Throws<AlgorithmException>(() =>
            {
                var graph = GraphDataProvider.ProvideValid();
                var problem = ProblemProvider.ProvideSubstitute();
                var individuals = new List<Individual>
                {
                    new Individual(graph, problem),
                    new Individual(GraphDataProvider.ProvideValid(), problem)
                };
                Strategy.Set(individuals);
            });
        }

        [Fact]
        public void ISelectionStrategy_Next_ThrowsOnEmptyPopulation()
        {
            Strategy.Set(new List<Individual>());
            Assert.Throws<InvalidOperationException>(() =>
            {
                Strategy.Next();
            });
        }

        [Fact]
        public void ISelectionStrategy_Next_ReturnsValid()
        {
            var individuals = new List<Individual>
            {
                IndividualProvider.ProvideValid(),
                IndividualProvider.ProvideValid(),
                IndividualProvider.ProvideValid()
            };
            Strategy.Set(individuals);
            Assert.Contains(individuals, i => i.Equals(Strategy.Next()));
        }

        [Fact]
        public void ISelectionStrategy_Next_ReturnsProperValueIfOneIndividualPopulation()
        {
            var individuals = new List<Individual> {IndividualProvider.ProvideValid()};
            Strategy.Set(individuals);
            Assert.Contains(individuals, i => i.Equals(Strategy.Next()));
        }

        [Fact]
        public void ISelectionStrategy_NextCouple_ReturnsValid()
        {
            var individuals = new List<Individual>
            {
                IndividualProvider.ProvideValid(),
                IndividualProvider.ProvideValid(),
                IndividualProvider.ProvideValid()
            };
            Strategy.Set(individuals);
            var couple = Strategy.NextCouple();
            Assert.Contains(individuals, i => i.Equals(couple.Item1));
            Assert.Contains(individuals, i => i.Equals(couple.Item2));
            Assert.NotEqual(couple.Item1, couple.Item2);
        }

        [Fact]
        public void ISelectionStrategy_NextCouple_ThrowOnPopulationLessThanTwo()
        {
            var individuals = new List<Individual> { IndividualProvider.ProvideValid() };
            Strategy.Set(individuals);
            Assert.Throws<InvalidOperationException>(() => Strategy.NextCouple());
        }

    }
}
