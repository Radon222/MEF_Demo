using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using SimpleCalculator.Core;
using System.IO;

namespace SimpleCalculator3
{

    class Program
    {
        private CompositionContainer _container;

        [Import(typeof(ICalculator))]
        public ICalculator calculator;
        
        private Program()
        {
            //An aggregate catalog that combines multiple catalogs
            var catalog = new AggregateCatalog();
            //Adds all the parts found in the same assembly as the Program class
            catalog.Catalogs.Add(new AssemblyCatalog(typeof(Program).Assembly));
            var extensionDir = $@"{Environment.CurrentDirectory}\Extensions";
            if (Directory.Exists(extensionDir))
                catalog.Catalogs.Add(new DirectoryCatalog(extensionDir));
            else
                Console.WriteLine($"{extensionDir} does not exist, program will go without extensions");
            
            //Create the CompositionContainer with the parts in the catalog
            _container = new CompositionContainer(catalog);

            //Fill the imports of this object
            try
            {
                this._container.ComposeParts(this);
            }
            catch (CompositionException compositionException)
            {
                Console.WriteLine(compositionException.ToString());
            }
        }


        static void Main(string[] args)
        {
            Program p = new Program(); //Composition is performed in the constructor
            String s;
            Console.WriteLine("Enter Command (like '5+ 6', '15% 7'):");
            while (true)
            {
                s = Console.ReadLine();
                Console.WriteLine(p.calculator.Calculate(s));
            }
        }
    }
}
