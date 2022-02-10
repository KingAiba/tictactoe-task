using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Matrix 
{
    public int[,] mat;

    public int rows;
    public int cols;

    public bool isSquareMat = false;

    public Matrix(int SizeX, int SizeY)
    {
        SetMat(new int[SizeX, SizeY]);
    }

    public Matrix(int[,] arr)
    {
        SetMat(arr);
    }

    public void SetMat(int[,] arr)
    {
        rows = arr.GetLength(0);
        cols = arr.GetLength(1);

        if (rows == cols)
        {
            isSquareMat = true;
        }
        else
        {
            isSquareMat = false;
        }

        mat = arr;
    }

    public void SetMatValuesTo(int num)
    {
        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < cols; col++)
            {
                InsetValue(row, col, num);
            }
        }
    }

    public void SetRowValuesTo(int row, int val)
    {
        for (int j = 0; j < cols; j++)
        {
            InsetValue(row, j, val);
        }
    }

    public void SetColValuesTo(int col, int val)
    {
        for (int i = 0; i < rows; i++)
        {
            InsetValue(i, col, val);
        }
    }

    public void SetDiagonal(int num)
    {
        for (int i = 0; i < rows; i++)
        {
            if (i > cols - 1)
            {
                break;
            }

            InsetValue(i, i, num);
        }
    }

    public void SetInverseDiagonal(int num)
    {
        int col = cols - 1;
        for (int i = 0; i < rows; i++)
        {
            if (col - i < 0)
            {
                break;
            }
            InsetValue(i, col - i, num);
        }
    }

    public bool IsRowSame(int row)
    {
        if (cols == 1)
        {
            return true;
        }
        for (int j = 1; j < cols; j++)
        {
            if (mat[row, j - 1] != mat[row, j])
            {
                return false;
            }
        }
        return true;
    }

    public bool IsColSame(int col)
    {
        if (rows == 1)
        {
            return true;
        }
        for (int i = 1; i < rows; i++)
        {
            if (mat[i - 1, col] != mat[i, col])
            {
                return false;
            }
        }
        return true;
    }

    public bool IsDiagonalSame()
    {
        if (rows == 1 || cols == 1)
        {
            return true;
        }
        for (int i = 1; i < rows; i++)
        {
            if (i > cols - 1)
            {
                break;
            }
            if (mat[i - 1, i - 1] != mat[i, i])
            {
                return false;
            }

        }
        return true;
    }

    public bool IsInverseDiagonalSame()
    {
        if (rows == 1 || cols == 1)
        {
            return true;
        }

        int col = cols - 1;
        for (int i = 1; i < rows; i++)
        {
            if (col - i < 0)
            {
                break;
            }
            if (mat[i - 1, col - i + 1] != mat[i, col - i])
            {
                return false;
            }
        }

        return true;
    }

    public void InsertRow(int row, int[] arr)
    {
        if (row < rows)
        {
            if (arr.Length == cols)
            {
                for (int i = 0; i < cols; i++)
                {
                    mat[row, i] = arr[i];
                }
            }
            else
            {
                Debug.Log("Incorrect arr size");
            }
        }
        OnMatrixUpdate();

    }

    public int[] GetRow(int row)
    {
        int[] output = new int[cols];
        if (row < rows)
        {
            for (int j = 0; j < cols; j++)
            {
                output[j] = mat[row, j];
            }
        }
        else
        {
            Debug.Log("Index out of range");
            return null;
        }

        return output;
    }

    public int GetValue(int row, int col)
    {
        if (row < rows && row >= 0 && col < cols && col >= 0)
        {
            return mat[row, col];
        }
        else
        {
            Debug.Log("Index out of range");
            return 0;
        }
    }

    public void InsetValue(int row, int col, int val)
    {
        if (row < rows && row >= 0 && col < cols && col >= 0)
        {
            mat[row, col] = val;
        }
        else
        {
            Debug.Log("Index out of range");
        }
        OnMatrixUpdate();
    }

    public string PrintMat()
    {
        string str = "";

        for (int r = 0; r < rows; r++)
        {
            for (int c = 0; c < cols; c++)
            {
                str += mat[r, c] + " ";
            }
            str += "\n";
        }

        return str;
    }

    public void SwapRows(int rowInd1, int rowInd2)
    {
        if (rowInd1 < rows && rowInd1 >= 0 && rowInd2 < rows && rowInd2 >= 0)
        {
            for (int j = 0; j < cols; j++)
            {
                int temp = mat[rowInd1, j];
                mat[rowInd1, j] = mat[rowInd2, j];
                mat[rowInd2, j] = temp;

            }
        }
        else
        {
            Debug.Log("Index out of range");
        }

        OnMatrixUpdate();

    }

    public void SwapCols(int colInd1, int colInd2)
    {
        if (colInd1 < cols && colInd1 >= 0 && colInd2 < cols && colInd2 >= 0)
        {
            for (int i = 0; i < rows; i++)
            {
                int temp = mat[i, colInd1];
                mat[i, colInd1] = mat[i, colInd2];
                mat[i, colInd2] = temp;

            }
        }
        else
        {
            Debug.Log("Index out of range");
        }

        OnMatrixUpdate();
    }

    public Matrix AddMats(Matrix mat2)
    {
        if (rows == mat2.rows && cols == mat2.cols)
        {
            Matrix output = new Matrix(rows, cols);
            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < cols; c++)
                {
                    output.InsetValue(r, c, GetValue(r, c) + mat2.GetValue(r, c));
                }
            }
            return output;

        }
        else
        {
            Debug.Log("Both matices must have the same dimensions");
        }

        return null;
    }

    public Matrix SubMats(Matrix mat2)
    {
        if (rows == mat2.rows && cols == mat2.cols)
        {
            Matrix output = new Matrix(rows, cols);
            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < cols; c++)
                {
                    output.InsetValue(r, c, GetValue(r, c) - mat2.GetValue(r, c));
                }
            }
            return output;

        }
        else
        {
            Debug.Log("Both matices must have the same dimensions");
        }

        return null;
    }

    public Matrix DotProduct(Matrix mat2)
    {
        if (rows == mat2.cols)
        {
            Matrix output = new Matrix(rows, mat2.cols);
            // loop through rows of first matrix
            for (int i = 0; i < rows; i++)
            {
                // loop through cols of second matrix
                for (int j = 0; j < mat2.cols; j++)
                {
                    int product = 0;
                    // loop through each value in ith row of first and jth col of second
                    for (int k = 0; k < cols; k++)
                    {
                        product += GetValue(i, k) * mat2.GetValue(k, j);
                    }
                    output.InsetValue(i, j, product);

                }
            }
            return output;
        }
        else
        {
            Debug.Log("rows of mat1 need to be the same as columns of mat2");
        }
        return null;
    }

    public Matrix GetMinor(int[,] mat, int curRow, int curCol)
    {
        Matrix minor = new Matrix(new int[rows - 1, cols - 1]);
        int currMinorRow = 0;
        int currMinorCols = 0;

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                if (i != curRow && j != curCol)
                {
                    minor.mat[currMinorRow, currMinorCols] = mat[i, j];
                    currMinorCols += 1;

                    if (currMinorCols == cols - 1)
                    {
                        currMinorCols = 0;
                        currMinorRow += 1;
                    }

                }
            }
        }

        return minor;
    }

    public int Cofactor(int[,] mat)
    {
        if (isSquareMat && rows == 2)
        {
            return (mat[0, 0] * mat[1, 1]) - (mat[0, 1] * mat[1, 0]);
        }
        return 0;
    }

    public int Determinant()
    {
        if (!isSquareMat)
        {
            Debug.Log("determinant cannot be calculated of a non square mat");
            return 0;
        }

        if (rows == 2)
        {
            return Cofactor(mat);
        }

        int sign = 1;
        int determinant = 0;

        for (int i = 0; i < rows; i++)
        {
            determinant += sign * mat[0, i] * GetMinor(mat, 0, i).Determinant();
            sign = -sign;
        }

        return determinant;
    }

    public virtual void OnMatrixUpdate(int Row = -1, int Col = -1)
    {

    }
}
