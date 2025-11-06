using System.Collections.Generic;

namespace NeuralNetwork
{
    public static class TrainingData
    {
        public const double X = 0.5;
        public const double O = -0.5;

        public static Dictionary<int, VectorPair> Model
        {
            get
            {
                Dictionary<int, VectorPair> result = new Dictionary<int, VectorPair>();
                for (int i = 0; i < All.Length; i++)
                {
                    double[] output = new double[All.Length];
                    for (int j = 0; j < All.Length; j++)
                        output[j] = j == i ? X : O;
                    All[i].Print();
                    VectorPair vector = new VectorPair(All[i], new Vector(output));
                    result.Add(i, vector);
                }
                return result;
            }
        }

        private static Vector[] All => new Vector[] { Zero, One, Two, Three, Four, Five, Six, Seven, Eight, Nine };

        private static Vector Zero
        {
            get
            {
                double[][] matrix = new double[7][];
                matrix[0] = new double[5] { O, X, X, X, O };
                matrix[1] = new double[5] { X, O, O, O, X };
                matrix[2] = new double[5] { X, O, O, O, X };
                matrix[3] = new double[5] { X, O, O, O, X };
                matrix[4] = new double[5] { X, O, O, O, X };
                matrix[5] = new double[5] { X, O, O, O, X };
                matrix[6] = new double[5] { O, X, X, X, O };
                return new Vector(matrix);
            }
        }

        private static Vector One
        {
            get
            {
                double[][] matrix = new double[7][];
                matrix[0] = new double[5] { O, O, X, O, O };
                matrix[1] = new double[5] { O, X, X, O, O };
                matrix[2] = new double[5] { X, O, X, O, O };
                matrix[3] = new double[5] { O, O, X, O, O };
                matrix[4] = new double[5] { O, O, X, O, O };
                matrix[5] = new double[5] { O, O, X, O, O };
                matrix[6] = new double[5] { O, O, X, O, O };
                return new Vector(matrix);
            }
        }

        private static Vector Two
        {
            get
            {
                double[][] matrix = new double[7][];
                matrix[0] = new double[5] { O, X, X, X, O };
                matrix[1] = new double[5] { X, O, O, O, X };
                matrix[2] = new double[5] { O, O, O, X, O };
                matrix[3] = new double[5] { O, O, X, O, O };
                matrix[4] = new double[5] { O, X, O, O, O };
                matrix[5] = new double[5] { X, O, O, O, O };
                matrix[6] = new double[5] { X, X, X, X, X };
                return new Vector(matrix);
            }
        }

        private static Vector Three
        {
            get
            {
                double[][] matrix = new double[7][];
                matrix[0] = new double[5] { O, X, X, X, O };
                matrix[1] = new double[5] { X, O, O, O, X };
                matrix[2] = new double[5] { O, O, O, O, X };
                matrix[3] = new double[5] { O, X, X, X, O };
                matrix[4] = new double[5] { O, O, O, O, X };
                matrix[5] = new double[5] { X, O, O, O, X };
                matrix[6] = new double[5] { O, X, X, X, O };
                return new Vector(matrix);
            }
        }

        private static Vector Four
        {
            get
            {
                double[][] matrix = new double[7][];
                matrix[0] = new double[5] { O, O, X, X, O };
                matrix[1] = new double[5] { O, X, O, X, O };
                matrix[2] = new double[5] { X, O, O, X, O };
                matrix[3] = new double[5] { X, X, X, X, O };
                matrix[4] = new double[5] { O, O, O, X, O };
                matrix[5] = new double[5] { O, O, O, X, O };
                matrix[6] = new double[5] { O, O, O, X, O };
                return new Vector(matrix);
            }
        }

        private static Vector Five
        {
            get
            {
                double[][] matrix = new double[7][];
                matrix[0] = new double[5] { O, X, X, X, O };
                matrix[1] = new double[5] { X, O, O, O, O };
                matrix[2] = new double[5] { X, O, O, O, O };
                matrix[3] = new double[5] { O, X, X, X, O };
                matrix[4] = new double[5] { O, O, O, O, X };
                matrix[5] = new double[5] { O, O, O, O, X };
                matrix[6] = new double[5] { O, X, X, X, O };
                return new Vector(matrix);
            }
        }

        private static Vector Six
        {
            get
            {
                double[][] matrix = new double[7][];
                matrix[0] = new double[5] { O, X, X, X, O };
                matrix[1] = new double[5] { X, O, O, O, O };
                matrix[2] = new double[5] { X, O, O, O, O };
                matrix[3] = new double[5] { O, X, X, X, O };
                matrix[4] = new double[5] { X, O, O, O, X };
                matrix[5] = new double[5] { X, O, O, O, X };
                matrix[6] = new double[5] { O, X, X, X, O };
                return new Vector(matrix);
            }
        }

        private static Vector Seven
        {
            get
            {
                double[][] matrix = new double[7][];
                matrix[0] = new double[5] { X, X, X, X, X };
                matrix[1] = new double[5] { O, O, O, O, X };
                matrix[2] = new double[5] { O, O, O, X, O };
                matrix[3] = new double[5] { O, O, O, X, O };
                matrix[4] = new double[5] { O, O, X, O, O };
                matrix[5] = new double[5] { O, O, X, O, O };
                matrix[6] = new double[5] { O, O, X, O, O };
                return new Vector(matrix);
            }
        }

        private static Vector Eight
        {
            get
            {
                double[][] matrix = new double[7][];
                matrix[0] = new double[5] { O, X, X, X, O };
                matrix[1] = new double[5] { X, O, O, O, X };
                matrix[2] = new double[5] { X, O, O, O, X };
                matrix[3] = new double[5] { O, X, X, X, O };
                matrix[4] = new double[5] { X, O, O, O, X };
                matrix[5] = new double[5] { X, O, O, O, X };
                matrix[6] = new double[5] { O, X, X, X, O };
                return new Vector(matrix);
            }
        }

        private static Vector Nine
        {
            get
            {
                double[][] matrix = new double[7][];
                matrix[0] = new double[5] { O, X, X, X, O };
                matrix[1] = new double[5] { X, O, O, O, X };
                matrix[2] = new double[5] { X, O, O, O, X };
                matrix[3] = new double[5] { O, X, X, X, O };
                matrix[4] = new double[5] { O, O, O, O, X };
                matrix[5] = new double[5] { O, O, O, O, X };
                matrix[6] = new double[5] { O, X, X, X, O };
                return new Vector(matrix);
            }
        }
    }
}