using SquareMatrix;

namespace TestProject2
{
    public class SquareMatrixTests
    {
  
        public void SquareMatrix_SetInvalidIndex_ThrowsIndexOutOfRangeException()
        {
            SquareMatrix<int> matrix = new SquareMatrix<int>(3);

            Assert.Throws<IndexOutOfRangeException>(() => matrix[-1, 0] = 1);
            Assert.Throws<IndexOutOfRangeException>(() => matrix[0, -1] = 1);
            Assert.Throws<IndexOutOfRangeException>(() => matrix[3, 0] = 1);
            Assert.Throws<IndexOutOfRangeException>(() => matrix[0, 3] = 1);
        }

        public void SquareMatrix_SetAndGetElement_ReturnsCorrectValue()
        {
            SquareMatrix<int> matrix = new SquareMatrix<int>(2);

            matrix[0, 0] = 1;
            matrix[0, 1] = 2;
            matrix[1, 0] = 3;
            matrix[1, 1] = 4;

            Assert.AreEqual(1, matrix[0, 0]);
            Assert.AreEqual(2, matrix[0, 1]);
            Assert.AreEqual(3, matrix[1, 0]);
            Assert.AreEqual(4, matrix[1, 1]);
        }


        public void SquareMatrix_ElementChangedEvent_IsRaised()
        {
            SquareMatrix<int> matrix = new SquareMatrix<int>(2);
            int eventCount = 0;

            matrix.ElementChanged += (i, j, oldValue) =>
            {
                eventCount++;
            };

            matrix[0, 0] = 1;
            matrix[1, 1] = 2;
            matrix[0, 1] = 3; 
            matrix[0, 1] = 3; 

            Assert.AreEqual(1, eventCount);
        }
    }
}
