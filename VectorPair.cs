namespace NeuralNetwork
{
    public class VectorPair
    {
        public readonly Vector Input;
        public readonly Vector Output;

        public VectorPair(Vector i, Vector o)
        {
            Input = i;
            Output = o;
        }
    }
}