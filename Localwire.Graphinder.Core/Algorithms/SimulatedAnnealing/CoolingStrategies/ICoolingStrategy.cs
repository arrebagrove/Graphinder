﻿namespace Localwire.Graphinder.Core.Algorithms.SimulatedAnnealing.CoolingStrategies
{
    using System;

    /// <summary>
    /// Interface representing behaviour of cooling strategy.
    /// </summary>
    public interface ICoolingStrategy
    {
        /// <summary>
        /// Cools system until it reaches minimal, targeted temperature.
        /// </summary>
        /// <param name="algorithm">Simulated annealing algorithm being cooled.</param>
        /// <param name="coolingAction">Delegate of action to cool system by one step of cooling ratio.</param>
        /// <returns>Processor time cost</returns>
        long Cool(IAlgorithm algorithm, Action coolingAction);
    }
}
