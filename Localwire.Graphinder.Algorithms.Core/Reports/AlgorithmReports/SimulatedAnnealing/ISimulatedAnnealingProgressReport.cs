﻿namespace Localwire.Graphinder.Core.Reports.AlgorithmReports.SimulatedAnnealing
{
    public interface ISimulatedAnnealingProgressReport : IAlgorithmProgressReport
    {
        /// <summary>
        /// Current temperature of <see cref="T:Localwire.Graphinder.Core.Algorithms.SimulatedAnnealing.SimulatedAnnealing"/> algorithm
        /// </summary>
        double CurrentTemperature { get; }
    }
}
