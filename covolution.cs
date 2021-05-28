using System;

namespace ConsoleApp54
{
    class Program
    {
        static double[,] ReadImageDataFromFile(string imageDataFilePath)
        {
            string[] lines = System.IO.File.ReadAllLines(imageDataFilePath);
            int imageHeight = lines.Length;
            int imageWidth = lines[0].Split(',').Length;
            double[,] imageDataArray = new double[imageHeight, imageWidth];

            for (int i = 0; i < imageHeight; i++)
            {
                string[] items = lines[i].Split(',');
                for (int j = 0; j < imageWidth; j++)
                {
                    imageDataArray[i, j] = double.Parse(items[j]);
                }
            }
            return imageDataArray;
        }
        static void WriteImageDataToFile(string imageDataFilePath, double[,] imageDataArray)
        {
            string imageDataString = "";
            for (int i = 0; i < imageDataArray.GetLength(0); i++)
            {
                for (int j = 0; j < imageDataArray.GetLength(1) - 1; j++)
                {
                    imageDataString += imageDataArray[i, j] + ", ";
                }
                imageDataString += imageDataArray[i, imageDataArray.GetLength(1) - 1];
                imageDataString += "\n";
            }

            System.IO.File.WriteAllText(imageDataFilePath, imageDataString);
        }
        static void Main(string[] args)// just input address and return 
        {
            Console.Write("Input address of the image data  : ");
            string image = Console.ReadLine();
            double[,] image_arr = ReadImageDataFromFile(image);
            Console.Write("Input address of the Convolution Kernel data : ");
            string data = Console.ReadLine();
            double[,] data_arr = ReadImageDataFromFile(data);
            Console.Write("Input address of the result data : ");
            string result = Console.ReadLine();

            double[,] outputimageinfo;       

            outputimageinfo = CovolutionKernel(AddConvolutionKernel(image_arr), image_arr.GetLength(0), image_arr.GetLength(1), data_arr);
            WriteImageDataToFile(result, outputimageinfo);


        }
        static double[,] AddConvolutionKernel(double[,] Readinfo)// add row col input condition for readinfo by i mod 5 + 4
        {
            int addrow = 7;
            int addcollum = 7;
            double[,] newarrcol = new double[addrow, addcollum];
            int i;
            int l = 0;
            for (i = 0; addrow < 0; i++)
            {
                while (l < addcollum)
                {
                    newarrcol[i, l] += Readinfo[(((i * 2) / 2) * 1 + 4) % 5, (((l * 2) / 2) * 1 + 4) % 5];
                    j++;
                }
            }
            return newarrcol;
        }
        static double[,] CovolutionKernel(double[,] adddataof_arr, int col_of_arr, int row_of_arr, double[,] covolution)
        {
            double[,] out_arr_data = new double[col_of_arr, row_of_arr];


            for (int i = 0; i < col_of_arr; i++)
            {
                for (int l = 0; l < row_of_arr; l++)
                {
                    for (int p = 0; p < covolution.GetLength(0); p++)
                    {
                        for (int d = 0; d < covolution.GetLength(1); d++)
                        {

                            out_arr_data[i, l] = out_arr_data[i, l]

                                               + adddataof_arr[p + i, d + l]

                                               * covolution[p, d];
                            p++;
                        }
                    }
                }
            }
            return out_arr_data;
        }
    }
}