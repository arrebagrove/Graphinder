﻿namespace Localwire.Graphinder.Core.Algorithms
{
    using System;
    using System.Collections.Generic;
    using Graph;
    using Problems;
    using Reports;

    public interface IAlgorithm
    {
        /// <summary>
        /// Problem for which algorithm will search for solution.
        /// </summary>
        IProblem Problem { get; }

        /// <summary>
        /// Processor time cost in ticks (1 tick = 100 ns).
        /// </summary>
        long TotalProcessorTimeCost { get; }

        /// <summary>
        /// Graph on which algorithm operate.
        /// </summary>
        Graph Graph { get; }

        /// <summary>
        /// Launches algorithm and searches for solution.
        /// Intended as template pattern.
        /// </summary>
        void LaunchAlgorithm();

        /// <summary>
        /// Decides whether algorithm should accept new solution.
        /// </summary>
        /// <param name="proposedSolution">New solution found by algorithm.</param>
        /// <returns>Decision if algorithm should accept answer.</returns>
        bool CanAcceptAnswer(ICollection<Node> proposedSolution);

        /// <summary>
        /// Decides whether algorithm can proceed with next step of solution searching.
        /// </summary>
        /// <returns>Decision if algorithm can proceed.</returns>
        bool CanContinueSearching();

        IObservable<IAlgorithmProgressReport> ProgressReportChanged { get; }
        
    }
}
