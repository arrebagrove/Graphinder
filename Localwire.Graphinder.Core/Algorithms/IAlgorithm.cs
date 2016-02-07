﻿namespace Localwire.Graphinder.Core.Algorithms
{
    using Graph;
    using Problems;

    public interface IAlgorithm
    {
        /// <summary>
        /// Problem for which algorithm will search for solution.
        /// </summary>
        IProblem Problem { get; }

        /// <summary>
        /// Processor time cost in ticks (1 tick = 100 ns).
        /// </summary>
        long ProcessorTimeCost { get; }

        /// <summary>
        /// Current solution value.
        /// </summary>
        int CurrentSolution { get; }

        /// <summary>
        /// Graph on which algorithm operate.
        /// </summary>
        Graph Graph { get; }

        /// <summary>
        /// Launches algorithm and searches for solution.
        /// Intended as template pattern.
        /// </summary>
        void LaunchAlgorithm();
    }
}
