﻿namespace Localwire.Graphinder.Core.Tests.Algorithms.GeneticAlgorithm
{
    using Base;
    using Core.Algorithms.GeneticAlgorithm.SelectionStrategies;

    public class RouletteStrategyTests : ISelectionStrategyTests
    {
        public RouletteStrategyTests()
        {
            Strategy = new RouletteStrategy();
        }
    }
}
