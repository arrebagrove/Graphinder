﻿namespace Localwire.Graphinder.Algorithms.DataAccess.Mappers.Problems
{
    using System.Linq;
    using Core.Graph;
    using Core.Problems.OptimizationProblems;
    using Entities.Graph;
    using Entities.Problems;
    using Graph;

    internal static class MinimumVertexCoverMapper
    {
        public static MinimumVertexCover AsDomainModel(this MinimumVertexCoverEntity entity, Graph graph = null)
        {
            var problem = new MinimumVertexCover(entity.Id);
            problem.Initialize(graph ?? entity.Graph.AsDomainModel());
            problem.SetNewSolution(entity.CurrentSolution.AsDomainModel(problem.Graph).ToList());
            return problem;
        }

        public static MinimumVertexCoverEntity AsEntityModel(this MinimumVertexCover model, GraphEntity graph = null)
        {
            var outputGraph = graph ?? model.Graph.AsEntityModel();
            return new MinimumVertexCoverEntity
            {
                Id = model.Id,
                Graph = outputGraph,
                CurrentSolution = model.CurrentSolution.AsEntityModel(outputGraph).ToList()
            };
        }
    }
}
