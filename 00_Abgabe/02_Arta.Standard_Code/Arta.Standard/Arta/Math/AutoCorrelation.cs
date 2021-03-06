﻿using Arta.Util;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.Statistics;
using System;

namespace Arta.Math
{
    public static class AutoCorrelation
    {

        public static double CalculateAcf(double[] data, int lag)
        {
            var acc = 0.0;
            var length = data.Length;
            if (lag < 0)
                throw new ArgumentException("Negative Lags are not allowed");
            if (lag > length)
                throw new ArgumentException("Lag exceeds sample size");
            if (lag == 0)
                acc = 1.0;
            else
                acc = Correlation.Pearson(data.CopyOfRange(0, length - lag), data.CopyOfRange(lag, length));
            return acc;
        }

        public static double[] CalculateAcfs(double[] data, int maxLag)
        {
            var accs = new double[maxLag + 1];
            for (var lag = 0; lag <= maxLag; lag++)
            {
                accs[lag] = CalculateAcf(data, lag);
            }
            return accs;
        }

        public static Matrix<double> GetCorrelationMatrix(double[] autocorrelations)
        {
          
            var dim = autocorrelations.Length;
            var psivalues = new double[dim, dim];
            for (var row = 0; row < dim; row++)
            {
                for (var col = row; col < dim; col++)
                {
                    if (row == col)
                    {
                        psivalues[col, row] = 1.0;
                    }
                    else
                    {
                        psivalues[col, row] = autocorrelations[col - row - 1];
                        psivalues[row, col] = autocorrelations[col - row - 1];
                    }
                }
            }
            
            return CreateMatrix.DenseOfArray<double>(psivalues); 
        }

        public static double[] CalculatePacfs(double[] acfs)
        {
            var size = acfs.Length;
            var pacfs = new double[size];
            var a = new double[size, size];
            var v = new double[size];
            a[0,0] = acfs[0];
            a[1,1] = acfs[1] / acfs[0];
            v[1] = a[1,1] / acfs[1];
            for (var k = 2; k < size; k++)
            {
                double sum = 0;
                for (var j = 1; j < k; j++)
                {
                    sum += a[j,j] * acfs[k - j];
                }
                a[k,k] = (acfs[k] - sum) / v[k - 1];
                for (var j = 1; j < k; j++)
                {
                    a[j,k] = a[j,k] - a[k,k] * a[k - j,k - 1];
                }

                v[k] = v[k - 1] * (1 - a[k,k] * a[k,k]);
            }
            for (var i = 0; i < size; i++)
            {
                pacfs[i] = a[i,i];
            }
            return pacfs;
        }
    }
}
