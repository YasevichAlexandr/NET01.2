
using DiagonalMatrix;

namespace TestProject2
{
    public class DiagonalMatrixTests
    {
        public void DiagonalMatrix_SetInvalidIndex_ThrowsIndexOutOfRangeException()
        {
            DiagonalMatrix<double> matrix = new DiagonalMatrix<double>(2);

            Assert.Throws<IndexOutOfRangeException>(() => matrix[-1, 0] = 1.5);
            Assert.Throws<IndexOutOfRangeException>(() => matrix[0, -1] = 1.5);
            Assert.Throws<IndexOutOfRangeException>(() => matrix[2, 0] = 1.5);
            Assert.Throws<IndexOutOfRangeException>(() => matrix[0, 2] = 1.5);
        }

        public void DiagonalMatrix_SetAndGetElement_ReturnsCorrectValue()
        {
            DiagonalMatrix<double> matrix = new DiagonalMatrix<double>(3);

            matrix[0, 0] = 1.1;
            matrix[1, 1] = 2.2;
            matrix[2, 2] = 3.3;
            
            Assert.AreEqual(1.1, matrix[0, 0]);
            Assert.AreEqual(0.0, matrix[0, 1]);
            Assert.AreEqual(0.0, matrix[0, 2]);
            Assert.AreEqual(0.0, matrix[1, 0]);
            Assert.AreEqual(2.2, matrix[1, 1]);
            Assert.AreEqual(0.0, matrix[1, 2]);
            Assert.AreEqual(0.0, matrix[2, 0]);
            Assert.AreEqual(0.0, matrix[2, 1]);
            Assert.AreEqual(3.3, matrix[2, 2]);
        }
        public void DiagonalMatrix_ElementChangedEvent_IsRaised()
        {
            DiagonalMatrix<double> matrix = new DiagonalMatrix<double>(3);
            int eventCount = 0;

            matrix.ElementChanged += (i, j, oldValue) =>
            {
                eventCount++;
            };

            matrix[0, 0] = 1.1;
            matrix[1, 1] = 2.2;
            matrix[2, 2] = 3.3;
            matrix[1, 1] = 2.2; // Не генерируется событие, значение осталось неизменным

            Assert.AreEqual(2, eventCount);
        }
    }
}