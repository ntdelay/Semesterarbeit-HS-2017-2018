﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Arta.Math
{
    class BivariateStandardNormal
    {
        private BivariateStandardNormal() { }

        public static double GetDensity(double x, double y, double rho)
        {
            double d = 1.0 - rho * rho;
            return System.Math.Exp(-(x * x - 2.0 * rho * x * y + y * y) / (2 * d)) / (2 * System.Math.PI * System.Math.Sqrt(d));
        }
    }
}