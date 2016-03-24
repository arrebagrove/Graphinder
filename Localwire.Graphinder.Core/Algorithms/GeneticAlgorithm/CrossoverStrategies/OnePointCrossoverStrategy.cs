﻿using System;

namespace Localwire.Graphinder.Core.Algorithms.GeneticAlgorithm.CrossoverStrategies
{
    using Exceptions;
    using Graph;
    using Problems;

    /// <summary>
    /// Class representing crossover strategy based on random division in single point.
    /// </summary>
    public class OnePointCrossoverStrategy : ICrossoverStrategy
    {
        /// <summary>
        /// Minimal crossover point of genotype (percent of genotype).
        /// </summary>
        public const double CrossoverPointMin = 0.2;
        /// <summary>
        /// Maximum crossover point of genotype (percent of genotype).
        /// </summary>
        public const double CrossoverPointMax = 0.8;

        private readonly Random _random = new Random();
        private readonly Graph _graph;

        public OnePointCrossoverStrategy(Graph graph)
        {
            if (graph == null)
                throw new ArgumentNullException(nameof(graph));
            if (!graph.IsValid())
                throw new ArgumentException("Graph is invalid!");
            _graph = graph;
            RandomizeCrossoverPoint();
        }

        /// <summary>
        /// Point of crossing over individual's genotype.
        /// </summary>
        public int CrossoverPointIndex { get; private set; }

        /// <summary>
        /// Perform cross over two individuals' genotypes.
        /// </summary>
        /// <param name="leftParent">Left parent for new genotype.</param>
        /// <param name="rightParent">Right parent for new genotype.</param>
        /// <returns>Result of crossing over - new offspring.</returns>
        public Individual PerformCrossover(Individual leftParent, Individual rightParent)
        {
            CanPerform(leftParent, rightParent);
            var length = leftParent.CurrentSolution.Length;
            var outputSolution = new bool[length];

            for (int i = 0; i < length; i++)
            {
                if (i < CrossoverPointIndex)
                    outputSolution[i] = leftParent.CurrentSolution[i];
                else
                    outputSolution[i] = rightParent.CurrentSolution[i];
            }
            return new Individual(_graph, leftParent.Problem, outputSolution);
        }

        private void CanPerform(Individual leftParent, Individual rightParent)
        {
            if (leftParent == null)
                throw new ArgumentNullException(nameof(leftParent));
            if (rightParent == null)
                throw new ArgumentNullException(nameof(rightParent));
            if (leftParent.Equals(rightParent))
                throw new AlgorithmException("Performing genetic crossover", "Crossover individuals are the same");
            if (leftParent.Graph != rightParent.Graph)
                throw new AlgorithmException("Performing genetic crossover", "Crossover individuals represent solutions for different graph");
            if (leftParent.Problem != rightParent.Problem)
                throw new AlgorithmException("Performing genetic crossover", "Crossover individuals represent solutions for different problem");
            if (leftParent.CurrentSolution.Length != rightParent.CurrentSolution.Length)
                throw new AlgorithmException("Performing genetic crossover", "Crossover individuals' solutions have different lenghts");
        }

        private void RandomizeCrossoverPoint()
        {
            //Pick random crossover point between allowed boundries
            double randomized = 0;
            while (randomized < CrossoverPointMin || randomized > CrossoverPointMax)
                randomized = _random.NextDouble();

            var randomIndex = (int)(randomized * _graph.TotalNodes);
            if (randomIndex >= _graph.TotalNodes) randomIndex--;

            CrossoverPointIndex = randomIndex;
        }
    }
}
