using ApiDnaMutant.BusinessLogic.IBusinessLogic;
using ApiDnaMutant.Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiDnaMutant.BusinessLogic
{
    public class DnaLogic : IDnaLogic
    {
        private const string letterA = "A", letterT = "T", letterC = "C", letterG = "G";

        //valid que la secuencia enviada sea correcta
        public bool ValidateDna(DnaDto dnaDto)
        {
            bool validateDna = false;

            var length = dnaDto.dna[0].Length;

            if (dnaDto.dna.Length == length && (dnaDto.dna.Length >= 4 && length >= 4))
            {
                for (int i = 0; i < dnaDto.dna.Length; i++)
                {
                    for (int j = 0; j < dnaDto.dna[i].Length; j++)
                    {
                        string letter = Convert.ToString(dnaDto.dna[i][j]);
                        var lengthJ = dnaDto.dna[i].Length;

                        if (lengthJ == length)
                        {
                            if ((letter == letterA || letter == letterT || letter == letterC || letter == letterG))
                            {
                                validateDna = true;
                            }
                            else
                            {
                                validateDna = false;
                                return validateDna;
                            }
                        }
                        else
                        {
                            validateDna = false;
                            return validateDna;
                        }
                    }
                }
            }

            return validateDna;
        }
        public string[,] Matriz(DnaDto dnaDto)
        {
            string[,] matrizDna = new string[0,0];
            if (dnaDto.dna != null)
            {
               matrizDna = new string[dnaDto.dna.Length, dnaDto.dna[0].Length];

                for (int rows = 0; rows < matrizDna.GetLength(0); rows++)
                {
                    for (int col = 0; col < matrizDna.GetLength(1); col++)
                    {
                        matrizDna[rows, col] = Convert.ToString(dnaDto.dna[rows][col]);
                    }
                }
            }
            return matrizDna;

        }
        public bool IsMutant(DnaDto dnaDto)
        {
            int countMutant = 0;
            
            bool isMutant = false;
            bool validateTopDiagonal = false;
            bool validateSecondaryDiagonal = false;

            //convierte la secuencia en matriz
            string[,] matrizDna = Matriz(dnaDto);

            //retorna un arreglo con la diagonal superior
            string[] vArrayTopDiagonal = arrayTopDiagonal(matrizDna);

            //valida si es mutante en la diagonal superior
            validateTopDiagonal = ValidateIsMutant(vArrayTopDiagonal);
            if (validateTopDiagonal)
            {
                countMutant = countMutant + 1;                
            }
            //retorna un arreglo con la diagonal secundaria
            string[] vArraySecondaryDiagonal =  arraySecondaryDiagonal(matrizDna);
            //valida si es mutante en la diagonal secundaria
            validateSecondaryDiagonal = ValidateIsMutant(vArraySecondaryDiagonal);
            if (validateSecondaryDiagonal)
            {
                countMutant = countMutant + 1;
            }

            //recorre las filas y trae un arreglo de cada fila para validar si es mutante
            for (int rows = 0; rows < matrizDna.GetLength(0); rows++)
            {
                string[] vArrayRow = arrayRow(matrizDna, rows);
                bool validateRow = ValidateIsMutant(vArrayRow);

                if (validateRow)
                {
                    countMutant = countMutant + 1;
                }
            }

            //recorre las columnas y trae un arreglo de cada columna para validar si es mutante
            for (int col = 0; col < matrizDna.GetLength(1); col++)
            {
                string[] vArrayCol = arrayColumn(matrizDna, col); 
                bool validateCol = ValidateIsMutant(vArrayCol);

                if (validateCol)
                {
                    countMutant = countMutant + 1;
                }
            }

            if (countMutant > 1)
            {
                isMutant = true;
            }
            
            return isMutant;
        }

        //obtengo la columna en un arreglo enviando el numero de posicion de la misma
        public string[] arrayColumn(string[,] matrizDna, int position)
        {
            string[] arrayColumn = new string[matrizDna.GetLength(0)];

            for (var i = 0; i < matrizDna.GetLength(0); i++)
            {
                arrayColumn[i] = matrizDna[i, position];
            }

            return arrayColumn;
        }

        //obtengo la fila en un arreglo enviando el numero de posicion de la fila
        public string[] arrayRow(string[,] matrizDna, int position)
        {
            string[] arrayRow = new string[matrizDna.GetLength(1)];

            for (var i = 0; i < matrizDna.GetLength(1); i++)
            {
                arrayRow[i] = matrizDna[position, i];

            }

            return arrayRow;

        }

        //obtengo la diagonal superior en un arreglo
        public string[] arrayTopDiagonal(string[,] matrizDna)
        {
            string[] arrayColumn = new string[matrizDna.GetLength(1)];

            for (var row = 0; row < matrizDna.GetLength(0); row++)
            {
                for (var col = 0; col <= matrizDna.GetLength(1) - 1; col++)
                {
                    if (row == col)
                    {
                        arrayColumn[col] = matrizDna[row,col];
                    }
                }                    
            }

            return arrayColumn;

        }

        //obtengo la diagonal secundaria en un arreglo
        public string[] arraySecondaryDiagonal(string[,] matrizDna)
        {
            string[] arrayColumn = new string[matrizDna.GetLength(1)];

            int matrizRow = matrizDna.GetLength(0);
            int matrizCol = matrizDna.GetLength(1);

            for (var row = 0; row <= matrizRow - 1; row++)
            {
                for (var col = matrizCol - 1; col < matrizCol  && col >=0; col--)
                {
                    if (row + col == matrizRow - 1)
                    {
                        arrayColumn[col] = matrizDna[row, col];
                    }
                }
            }
            return arrayColumn;
        }               

        //valida si es mutante comparando la secuencia
        public bool ValidateIsMutant(string[] array)
        {
            bool isMutant = false;           
            int countLeta = 0;

            for (int i = 0; i < array.Length; i++)
            {
                string letter = Convert.ToString(array[i]);
                int position = i >0 ? i - 1: i;
                string previousLetter = Convert.ToString(array[position]);

                if (letter == previousLetter)
                {
                    countLeta = countLeta + 1;
                    if (countLeta == 4)
                    {
                        isMutant = true;
                        return isMutant;
                    }
                }
                else
                {
                    countLeta = 0;
                }
            }

            return isMutant;
        }
    }
}
