using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using AForge.Neuro;
using AForge.Neuro.Learning;
using System.Windows.Media;

namespace NeuralNetwork
{
    public partial class MainWindow : Window
    {
        private readonly Dictionary<int, VectorPair> Model;
        private readonly int InputCount;
        private readonly int NeuronCount;
        private readonly ActivationNetwork Network;
        private readonly BackPropagationLearning Teacher;
        private readonly double[][] LearningInputs;
        private readonly double[][] LearningOutputs;
        private int Epochs;
        private int LearningRate;

        public MainWindow()
        {
            InitializeComponent();
            Model = TrainingData.Model;
            InputCount = Model.First().Value.Input.Size;
            NeuronCount = Model.Count;
            Network = new ActivationNetwork(new BipolarSigmoidFunction(2.0), InputCount, NeuronCount);
            Network.Randomize();
            Teacher = new BackPropagationLearning(Network) { LearningRate = 0.5 };
            LearningInputs = new double[NeuronCount][];
            LearningOutputs = new double[NeuronCount][];
            int counter = 0;
            foreach (VectorPair pair in Model.Values)
            {
                LearningInputs[counter] = pair.Input.GetVector();
                LearningOutputs[counter++] = pair.Output.GetVector();
            }
            Epochs = 0;
            LearningRate = 100000;
            Learn(0);
        }

        private void Learn(int iterations, double threashold = 0.1)
        {
            Dispatcher.Invoke(() => bLearn.IsEnabled = false);
            for (int i = 0; i < iterations; i++)
            {
                double error = Teacher.RunEpoch(LearningInputs, LearningOutputs);
                Epochs++;
                if (error <= threashold)
                    break;
            }
            Dispatcher.Invoke(() =>
            {
                tbLearned.Text = string.Format("{0} Learning Epochs", Epochs);
                bLearn.IsEnabled = true;
            });
        }

        private int Recognize(Vector input, out int accuracy)
        {
            double[] output = Network.Compute(input.GetVector());
            double max = output[0];
            int maxindex = 0;
            for (int i = 1, n = output.Length; i < n; i++)
            {
                if (output[i] > max)
                {
                    max = output[i];
                    maxindex = i;
                }
            }
            accuracy = (int)Math.Abs(max * 100);
            return maxindex;
        }

        private Vector GetInputVector(int width, int height)
        {
            IEnumerable<Button> buttons = gPixels.Children.OfType<Button>();
            double[][] matrix = new double[height][];
            for (int h = 0; h < height; h++)
            {
                double[] vector = new double[width];
                for (int w = 0; w < width; w++)
                {
                    Button target = buttons.Where(x => x.Name == string.Format("b{0}_{1}", w, h)).First();
                    vector[w] = target.Background == Brushes.Black ? TrainingData.X : TrainingData.O;
                }
                matrix[h] = vector;
            }
            return new Vector(matrix);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            if (button == bLearn)
            {
                Task.Run(() => Learn(LearningRate));
                if (Epochs >= 1000000)
                    LearningRate = 1000000;
                if (Epochs >= 10000000)
                    LearningRate = 10000000;
                return;
            }
            if (button == bRecognize)
            {
                Vector input = GetInputVector(5, 7);
                input.Print();
                int recognized = Recognize(input, out int accuracy);
                tbResult.Text = string.Format("Recognized Number: {0} ({1}% accuracy)", recognized, accuracy);
                return;
            }
            button.Background = button.Background == Brushes.Black ? Brushes.White : Brushes.Black;
        }
    }
}