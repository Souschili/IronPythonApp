using IronPython.Hosting;
using Microsoft.Scripting.Hosting;

namespace IronPythonApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var path = @"Script";
            // создали исполнитель скрипта
            ScriptEngine scriptEngine = Python.CreateEngine();
            // скрипт выполняется напрямую как строка
            scriptEngine.Execute("print('Hello Ilon Mask!! from script engine ')");

            Console.WriteLine("Hello World!! from c#");

            //from file
            Console.WriteLine();
            scriptEngine.ExecuteFile(Path.Combine(path, "Hello.py"));

            // send variable to script
            int y = 25;
            ScriptScope scope = scriptEngine.CreateScope();
            scope.SetVariable("y", y);
            scriptEngine.ExecuteFile("Script/Hello2.py", scope);

            //output variables from Hello2.py
            dynamic x= scope.GetVariable("x");
            dynamic z= scope.GetVariable("z");
            Console.WriteLine($"{x}+{y} = {z}");

            // call function from square.py
            
            int n = 11;
            string s = "MY NAME IS HAOS";

            scriptEngine.ExecuteFile($"Script/square.py", scope);
            dynamic square=scope.GetVariable("square");
            dynamic low=scope.GetVariable("low");
            // call function for square
            dynamic result = square(n);
            dynamic str = low(s);

            

            Console.WriteLine(result);
            Console.WriteLine(str);

            // how set you search path for modules
            //ICollection<string> searchPaths = scriptEngine.GetSearchPaths();
            //searchPaths.Add("..\\..");
            //scriptEngine.SetSearchPaths(searchPaths);

            // show search path
            foreach (var e in scriptEngine.GetSearchPaths())
            {
                Console.WriteLine(e);
            }




        }
    }
}