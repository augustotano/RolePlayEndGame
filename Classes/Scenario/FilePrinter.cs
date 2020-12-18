using System;
using System.IO;
using System.Collections.Generic;

namespace Classes
{
    /*
    Mayor información en la clase abstracta.
    */
    public class FilePrinter : IPrinter
    {
        public FilePrinter()
        {
        }

        public void Print(List<string> txt)
        {
            System.IO.File.WriteAllLines(@"Scenario.txt", txt);
        }
    }
}