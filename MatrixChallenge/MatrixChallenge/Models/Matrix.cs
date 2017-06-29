using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MatrixChallenge.Models
{
    public class Matrix
    {
        public int[][] Grid { get; set; }

        public Matrix(){}

        public Matrix(int rows, int cols)
        {
            Grid = new int[rows][];
            for (int i = 0; i < rows; i++)
            {
                Grid[i] = new int[cols];
            }
        }

        public Matrix Add(Matrix input)
        {
            if(input.Grid.Length != this.Grid.Length)
                throw new ApplicationException("Matrices must be of same size");


            for (int i = 0; i < input.Grid.Length; i++)
            {
                for (int j = 0; j < input.Grid[i].Length; j++)
                {
                    this.Grid[i][j] += input.Grid[i][j];
                }
            }
            return this;
        }


    }


}