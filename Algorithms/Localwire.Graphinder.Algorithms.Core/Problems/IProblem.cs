﻿namespace Localwire.Graphinder.Core.Problems
{
    using System.Collections.Generic;
    using Graph;

    public interface IProblem : IOperableOn<Graph>
    {
        /// <summary>
        /// Problem solution criteria.
        /// </summary>
        ProblemCriteria Criteria { get; }

        /// <summary>
        /// Is current solution correct for the problem.
        /// </summary>
        bool IsCurrentSolutionCorrect { get; }

        /// <summary>
        /// Current outcome of the solution.
        /// </summary>
        int CurrentOutcome { get; }

        /// <summary>
        /// Current solution of the problem.
        /// </summary>
        ICollection<Node> CurrentSolution { get; }

        /// <summary>
        /// Graph representing problem.
        /// </summary>
        Graph Graph { get; }

        /// <summary>
        /// Sets new solution of the problem.
        /// </summary>
        /// <param name="nodes">Collection of nodes representing new solution.</param>
        void SetNewSolution(ICollection<Node> nodes);

        /// <summary>
        /// Checks passed solution for correctness.
        /// </summary>
        /// <param name="nodes">Collection of nodes representing new solution.</param>
        /// <returns>Outcome of correctness check.</returns>
        bool IsSolutionCorrect(ICollection<Node> nodes);

        /// <summary>
        /// Checks passed solution encoded binary for correctness.
        /// </summary>
        /// <param name="nodesEncodedBinary">Collection of nodes representing new solution encoded binary.</param>
        /// <returns>Outcome of correctness check.</returns>
        bool IsSolutionCorrect(bool[] nodesEncodedBinary);

        /// <summary>
        /// Outputs outcome of provided solution.
        /// </summary>
        /// <param name="nodes">Proposed solution.</param>
        /// <returns>Solution outcome if correct. Default solution if incorrect.</returns>
        int SolutionOutcome(ICollection<Node> nodes);
    }

    public enum ProblemCriteria
    {
        BiggerIsBetter,
        SmallerIsBetter
    }
}
