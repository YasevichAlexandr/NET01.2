

namespace DiagonalMatrix
{
    public class DiagonalMatrix<T>
    {
        private T[] elements;
        private int size;

        public event Action<int, int, T> ElementChanged;

        public DiagonalMatrix(int size)
        {
            if (size <= 0)
                throw new ArgumentException("Size must be a positive integer.");

            this.size = size;
            elements = new T[size];
        }

        public T this[int i, int j]
        {
            get
            {
                if (i < 0 || i >= size || j < 0 || j >= size)
                    throw new IndexOutOfRangeException();

                return i == j ? elements[i] : default(T);
            }
            set
            {
                if (i < 0 || i >= size || j < 0 || j >= size)
                    throw new IndexOutOfRangeException();

                T oldValue = i == j ? elements[i] : default(T);
                if (!Equals(oldValue, value))
                {
                    elements[i] = value;
                    ElementChanged?.Invoke(i, j, oldValue);
                }
            }
        }
    }
}
