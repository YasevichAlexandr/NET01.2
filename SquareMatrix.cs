namespace SquareMatrix
{
    public class SquareMatrix<T>
    {
        private T[] elements;
        private int size;

        public event Action<int, int, T> ElementChanged;

        public SquareMatrix(int size)
        {
            if (size <= 0)
                throw new ArgumentException("Size must be a positive integer.");

            this.size = size;
            elements = new T[size * size];
        }

        public T this[int i, int j]
        {
            get
            {
                if (i < 0 || i >= size || j < 0 || j >= size)
                throw new IndexOutOfRangeException();

                return elements[i * size + j];
            }
            set
            {
                if (i < 0 || i >= size || j < 0 || j >= size)
                    throw new IndexOutOfRangeException();

                T oldValue = elements[i * size + j];
                if (!Equals(oldValue, value))
                {
                    elements[i * size + j] = value;
                    ElementChanged?.Invoke(i, j, oldValue);
                }
            }
        }
    }
}