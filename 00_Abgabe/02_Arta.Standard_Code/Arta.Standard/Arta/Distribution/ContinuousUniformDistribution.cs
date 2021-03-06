﻿using MathNet.Numerics.Distributions;
using MathNet.Numerics.Random;

namespace Arta.Distribution
{
    public class ContinuousUniformDistribution : IBaseDistribution
    {
        private readonly ContinuousUniform continuousUniform;

        public ContinuousUniformDistribution()
        {
            continuousUniform = new ContinuousUniform(-1, 1);
        }
        public double InverseCumulativeDistribution(double p)
        {
            return continuousUniform.InverseCumulativeDistribution(p);
        }

        public double GetMean()
        {
            return continuousUniform.Mean;
        }

        public double GetVariance()
        {
            return continuousUniform.Variance;
        }

        public AbstractArtaProcess CreateArtaProcess(double[] artaCorrelationCoefficients, RandomSource random)
        {
            var dim = artaCorrelationCoefficients.Length;
            var arCorrelationCoefficients = new double[dim];
            for (var i = 0; i < dim; i++)
            {
                arCorrelationCoefficients[i] = 2 * System.Math.Sin(System.Math.PI * artaCorrelationCoefficients[i] / 6);
            }
            ArProcess ar = ArProcessFactory.CreateArProcess(arCorrelationCoefficients, random);
            return new ArtaProcessUniform(ar, continuousUniform.LowerBound, continuousUniform.UpperBound);
        }

        public override string ToString()
        {
            return " Continuousuniform";
        }
    }
}
