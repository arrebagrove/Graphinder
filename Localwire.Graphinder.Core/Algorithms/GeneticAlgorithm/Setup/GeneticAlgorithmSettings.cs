﻿namespace Localwire.Graphinder.Core.Algorithms.GeneticAlgorithm.Setup
{
    using System;
    using Helpers;

    /// <summary>
    /// Represents settings for <see cref="T:Localwire.Graphinder.Core.Algorithms.GeneticAlgorithm.GeneticAlgorithm"/> solution finding. 
    /// </summary>
    public class GeneticAlgorithmSettings : ISelfValidable
    {
        /// <summary>
        /// Defines how big will each population for each generation be
        /// </summary>
        public readonly uint PopulationSize;

        /// <summary>
        /// Defines how many generations will algorithm breed before it stops
        /// </summary>
        public readonly uint GenerationsToCome;

        /// <summary>
        /// Defines how likely selected couple will breed new individual
        /// </summary>
        public readonly double CrossoverProbability;

        /// <summary>
        /// Defines how likely newly bred individual will mutate
        /// </summary>
        public readonly double MutationProbability;

        /// <summary>
        /// Creats settings for <see cref="T:Localwire.Graphinder.Core.Algorithms.GeneticAlgorithm.GeneticAlgorithm"/> solution finding. 
        /// </summary>
        /// <param name="generationsToCome">How many generations will algorithm breed before it stops</param>
        /// <param name="populationSize">How big should each population for each generation be</param>
        /// <param name="crossoverProbability">How likely chosen couple will crossover and breed new individual</param>
        /// <param name="mutationProbability">How likely newly bred individual will mutate</param>
        public GeneticAlgorithmSettings(uint generationsToCome = 20, uint populationSize = 50, double crossoverProbability = 0.5f, double mutationProbability = 0.1f)
        {
            if (populationSize <= 1)
                throw new ArgumentOutOfRangeException(nameof(populationSize), populationSize, "Population size is too small");
            if (generationsToCome == 0)
                throw new ArgumentOutOfRangeException(nameof(generationsToCome), generationsToCome, "Generations to come cannot be 0");
            if (crossoverProbability <= 0 || crossoverProbability > 1)
                throw new ArgumentOutOfRangeException(nameof(crossoverProbability), crossoverProbability, "Crossover probability should be more than 0, yet no more than 1");
            if (mutationProbability <= 0 || mutationProbability > 1)
                throw new ArgumentOutOfRangeException(nameof(mutationProbability), mutationProbability, "Mutation probability should be more than 0, yet no more than 1");

            PopulationSize = populationSize;
            GenerationsToCome = generationsToCome;
            CrossoverProbability = crossoverProbability;
            MutationProbability = mutationProbability;
        }

        /// <summary>
        /// Decides if state of object is valid.
        /// </summary>
        public bool IsValid()
        {
            return PopulationSize > 1 && GenerationsToCome > 0
                && CrossoverProbability > 0 && CrossoverProbability <= 1
                && MutationProbability > 0 && MutationProbability <= 1;
        }
    }
}
