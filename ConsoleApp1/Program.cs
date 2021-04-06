using System;
using System.Collections.Generic;
namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            string filepath = Console.ReadLine();
            Console.WriteLine(filepath.Remove(filepath.IndexOf('.')));
            Solution fs = new Solution();
            fs.FindFile2();
            //fs.printFileList();
            //fs.printFileTypeList();
            fs.GenerateConfJS();
        }
    }
}
