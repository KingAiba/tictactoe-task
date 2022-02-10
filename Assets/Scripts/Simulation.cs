using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Simulation : MonoBehaviour
{
    
    void Start()
    {
        /*        Matrix matA = new Matrix(2, 3);
                matA.InsertRow(0, new int[] { 1, 2, 3 });
                matA.InsertRow(1, new int[] { 4, 5, 6 });
                matA.InsetValue(1, 1, 10);
                Debug.Log(matA.PrintMat());

                int[,] arr = new int[,] { { 7, 8 }, { 9, 10 }, { 11, 12 } };

                Matrix matB = new Matrix(arr);
                Debug.Log(matA.DotProduct(matB).PrintMat());

                int[] a = matA.GetRow(1);

                Debug.Log(printArray(a));

                Debug.Log(matB.PrintMat());

                Matrix matC = matA.AddMats(matB);
                Debug.Log(matC.PrintMat());

                matC = matB.SubMats(matA);
                Debug.Log(matC.PrintMat());

                matA.SwapCols(2, 1);
                Debug.Log(matA.PrintMat());

                Debug.Log(matB.PrintMat());
                matB.SwapRows(0, 1);
                Debug.Log(matB.PrintMat());
                Matrix matA = new Matrix(new int[,] { { 1, 2, 3, 4 }, { 1, 2, 3, 4 } });
                matA.SetInverseDiagonal(11);
                Debug.Log(matA.PrintMat());
                Debug.Log(matA.Determinant());*/

        /*        Matrix matB = new Matrix (new int[,] { {-1, -2, 3, 2 },
                    {0, 1, 4, -2 },
                    {3, -1, 4, 0 },
                    {2, 1, 0, 3 }
                                                        });
                Debug.Log(matB.Determinant());

                Matrix matA = new Matrix(new int[,] { { 1, 2, 4},
                                                        { 1, 4, 1},
                                                        { 4, 2, 3},
                                                        { 11, 3, 3},
                                                        { 1, 3, 10},
                                                        });
                Debug.Log(matA.IsInverseDiagonalSame());

                foreach(CellStatus c in System.Enum.GetValues(typeof(CellStatus)))
                {
                    Debug.Log((int)c);
                }

                List<List<int>> lst = new List<List<int>>();*/

        /*Matrix matA = new Matrix(new int[,] {   {1, 0, 0, 0},
                                                {0, 1, 0, 0},
                                                {0, 2, 1, 0},
                                                {0, 0, 0, 0},
                                                });
        Debug.Log(matA.IsDiagonalSame());
        Debug.Log(matA.IsInverseDiagonalSame());
        */
    }


    public string printArray(int[] arr)
    {
        string str = "";
        for (int x = 0; x < arr.Length; x++)
        {
            str += arr[x] + " ";
        }
        return str;
    }

    
}
