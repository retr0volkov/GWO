using System;
using System.Collections.Generic;
using System.Linq;

namespace GWO
{
    public class GreyWolfOptimizer
    {
        private int populationSize;
        private int maxIterations;
        private double lowerBound;
        private double upperBound;
        private Func<double[], double> objectiveFunction;

        public double[][] wolves;
        public double[] alpha;
        public double[] beta;
        public double[] delta; 

        public double[] BestPosition { get; private set; }
        public double BestScore { get; private set; }
        public int IterationCount { get; private set; }

        public GreyWolfOptimizer(int populationSize, int maxIterations, double lowerBound,
            double upperBound, Func<double[], double> objectiveFunction)
        {
            this.populationSize = populationSize;
            this.maxIterations = maxIterations;
            this.lowerBound = lowerBound;
            this.upperBound = upperBound;
            this.objectiveFunction = objectiveFunction;

            // Инициализируем популяцию
            wolves = new double[populationSize][];
            for (int i = 0; i < populationSize; i++)
            {
                wolves[i] = InitializePosition();
            }

            // Инициализируем альфа, бета и дельта волков
            alpha = new double[2];
            beta = new double[2];
            delta = new double[2];

            // Сортируем волков по их подходимости
            var sortedWolves = wolves.OrderBy(w => objectiveFunction(w)).ToArray();
            alpha = sortedWolves[0];
            beta = sortedWolves[1];
            delta = sortedWolves[2];

            BestPosition = (double[])alpha.Clone();
            BestScore = objectiveFunction(alpha);
        }

        public void Optimize()
        {
            for (IterationCount = 0; IterationCount < maxIterations; IterationCount++)
            {
                OptimizeOneIteration();
            }
        }

        public void OptimizeOneIteration()
        {
            double a = 2.0 - IterationCount * (2.0 / maxIterations);
            for (int i = 0; i < populationSize; i++)
            {
                var wolf = wolves[i];
                var newPosition = new double[wolf.Length];
                for (int j = 0; j < wolf.Length; j++)
                {
                    double r1 = new Random().NextDouble();
                    double r2 = new Random().NextDouble();

                    double A1 = 2 * a * r1 - a;
                    double C1 = 2 * r2;
                    double D_alpha = Math.Abs(C1 * alpha[j] - wolf[j]);
                    double X1 = alpha[j] - A1 * D_alpha;

                    r1 = new Random().NextDouble();
                    r2 = new Random().NextDouble();
                    double A2 = 2 * a * r1 - a;
                    double C2 = 2 * r2;
                    double D_beta = Math.Abs(C2 * beta[j] - wolf[j]);
                    double X2 = beta[j] - A2 * D_beta;

                    r1 = new Random().NextDouble();
                    r2 = new Random().NextDouble();
                    double A3 = 2 * a * r1 - a;
                    double C3 = 2 * r2;
                    double D_delta = Math.Abs(C3 * delta[j] - wolf[j]);
                    double X3 = delta[j] - A3 * D_delta;

                    newPosition[j] = (X1 + X2 + X3) / 3;
                }
                wolves[i] = ClampPosition(newPosition);
            }

            var sortedWolves = wolves.OrderBy(w => objectiveFunction(w)).ToArray();
            alpha = sortedWolves[0];
            beta = sortedWolves[1];
            delta = sortedWolves[2];

            if (objectiveFunction(alpha) < BestScore)
            {
                BestPosition = (double[])alpha.Clone();
                BestScore = objectiveFunction(alpha);
            }

            IterationCount++;
        }

        private double[] InitializePosition()
        {
            var position = new double[2];
            var rand = new Random();
            for (int i = 0; i < position.Length; i++)
            {
                position[i] = lowerBound + rand.NextDouble() * (upperBound - lowerBound);
            }
            return position;
        }

        private double[] ClampPosition(double[] position)
        {
            for (int i = 0; i < position.Length; i++)
            {
                if (position[i] < lowerBound) position[i] = lowerBound;
                if (position[i] > upperBound) position[i] = upperBound;
            }
            return position;
        }
    }
}