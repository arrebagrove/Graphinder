﻿namespace Localwire.Graphinder.Core.Algorithms
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using Graph;
    using Problems;

    public abstract class Algorithm : IAlgorithm
    {
        protected Algorithm(Graph graph, IProblem problem)
        {
            if (problem == null)
                throw new ArgumentNullException(nameof(problem));
            if (graph == null)
                throw new ArgumentNullException(nameof(graph));
            if (!graph.IsValid())
                throw new ArgumentException("Graph is invalid", nameof(graph));
            Graph = graph;
            Problem = problem;
            problem.Initialize(graph);
        }

        /// <summary>
        /// Problem for which algorithm will search for solution.
        /// </summary>
        public IProblem Problem { get; }

        /// <summary>
        /// Processor time cost in ticks (1 tick = 100 ns).
        /// </summary>
        public abstract long ProcessorTimeCost { get; }

        /// <summary>
        /// Current solution value.
        /// </summary>
        public abstract int CurrentSolution { get; }

        /// <summary>
        /// Graph on which algorithm operate.
        /// </summary>
        public Graph Graph { get; }

        /// <summary>
        /// Launches algorithm and searches for solution.
        /// Intended as template pattern.
        /// </summary>
        public void LaunchAlgorithm()
        {
            SearchForSolution();
        }

        /// <summary>
        /// Decides whether algorithm should accept new solution.
        /// </summary>
        /// <param name="proposedSolution">New solution found by algorithm.</param>
        /// <returns>Decision if algorithm should accept answer.</returns>
        public abstract bool CanAcceptAnswer(ICollection<Node> proposedSolution);


        /// <summary>
        /// Decides whether algorithm can proceed with next step of solution searching.
        /// </summary>
        /// <returns>Decision if algorithm can proceed.</returns>
        public abstract bool CanContinueSearching();

        /// <summary>
        /// Searches for solution for chosen problem.
        /// </summary>
        protected abstract void SearchForSolution();
    }
}
