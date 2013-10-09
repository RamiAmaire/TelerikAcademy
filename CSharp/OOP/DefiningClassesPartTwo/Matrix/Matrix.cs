using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Matrix<T>
    where T : struct, IComparable
{
    private T[,] mat;
    private int rows = 0;
    private int cols = 0;
    static int rowIndex = 0;
    static int colIndex = 0;
    public int Rows
    {
        get { return this.rows; }
    }
    public int Cols
    {
        get { return this.cols; }
    }
    public Matrix(int row, int col)
    {
        this.rows = row;
        this.cols = col;
        mat = new T[row, col];
        rowIndex = 0;
        colIndex = 0;
    }
    public void Add(T element) //method
    {
        if (rowIndex == this.rows)
        {
            Console.WriteLine("Matrix is full, cannot add more items.");
            return;
        }
        mat[rowIndex, colIndex++] = element;
        if (colIndex == this.cols)
        {
            rowIndex++;
            colIndex = 0;
        }
    }
    public void PrintMatrix() //method
    {
        for (int i = 0; i < this.rows; i++)
        {
            for (int j = 0; j < this.cols; j++)
            {
                Console.Write(mat[i, j] + " ");
            }
            Console.WriteLine();
        }
    }
    public T this[int i, int j] //indexer
    {
        get
        {
            if (i < 0 || i >= rows || j < 0 || j >= cols)
            {
                throw new IndexOutOfRangeException();
            }
            return mat[i, j];
        }
        set
        {
            if (i < 0 || i >= rows || j < 0 || j >= cols)
            {
                throw new IndexOutOfRangeException();
            }
            mat[i, j] = value;
        }
    }
    public static Matrix<T> operator -(Matrix<T> mat1, Matrix<T> mat2) // operator
    {
        if (mat1.rows == mat2.rows && mat1.cols == mat2.cols)
        {
            Matrix<T> tempMatrix = new Matrix<T>(mat1.rows, mat1.cols);
            for (int i = 0; i < tempMatrix.rows; i++)
            {
                for (int j = 0; j < tempMatrix.cols; j++)
                {
                    tempMatrix[i, j] = (dynamic)mat1[i, j] - mat2[i, j];
                }
            }
            return tempMatrix;
        }
        else
        {
            throw new ArgumentOutOfRangeException("Matrices aren't the same size and the method cannot execute !");
        }
    }
    public static Matrix<T> operator +(Matrix<T> mat1, Matrix<T> mat2) // operator
    {
        if (mat1.rows == mat2.rows && mat1.cols == mat2.cols)
        {
            Matrix<T> tempMatrix = new Matrix<T>(mat1.rows, mat1.cols);
            for (int i = 0; i < tempMatrix.rows; i++)
            {
                for (int j = 0; j < tempMatrix.cols; j++)
                {
                    tempMatrix[i, j] = (dynamic)mat1[i, j] + mat2[i, j];
                }
            }
            return tempMatrix;
        }
        else
        {
            throw new ArgumentOutOfRangeException("Matrices aren't the same size and the method cannot execute !");
        }
    }
    public static Matrix<T> operator *(Matrix<T> mat1, Matrix<T> mat2) // operator
    {
        if (mat1.rows == mat2.rows && mat1.cols == mat2.cols)
        {
            Matrix<T> tempMatrix = new Matrix<T>(mat1.rows, mat1.cols);
            for (int i = 0; i < tempMatrix.rows; i++)
            {
                for (int j = 0; j < tempMatrix.cols; j++)
                {
                    tempMatrix[i, j] = (dynamic)mat1[i, j] * mat2[i, j];
                }
            }
            return tempMatrix;
        }
        else
        {
            throw new ArgumentOutOfRangeException("Matrices aren't the same size and the method cannot execute !");
        }
    }
    public static Boolean operator true(Matrix<T> matrix) // operator
    {
        int zero = 0;
        for (int i = 0; i < matrix.rows; i++)
        {
            for (int j = 0; j < matrix.cols; j++)
            {
                if ((dynamic)matrix[i, j] == zero)
                {
                    return false;
                    break;
                }
            }
        }
        return true;
    }
    public static Boolean operator false(Matrix<T> matrix) // operator
    { 
        int zero = 0;
        for (int i = 0; i < matrix.rows; i++)
        {
            for (int j = 0; j < matrix.cols; j++)
            {
                if ((dynamic)matrix[i, j] == zero)
                {
                    return false;
                    break;
                }
            }
        }
        return true;
    }
}
