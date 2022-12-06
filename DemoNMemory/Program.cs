using DemoNMemory.Entidade;
using NMemory.StoredProcedures;
using System;
using System.Linq;

namespace DemoNMemory
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MyDatabase myDatabase = new MyDatabase();

            var todasCidades = new SharedStoredProcedure<MyDatabase, Cidade>(d => d.Cidades);
            var todosEstados = new SharedStoredProcedure<MyDatabase, Estado>(d => d.Estados);

            var cidades = todasCidades.Execute(myDatabase, null).ToList();
            var estados = todosEstados.Execute(myDatabase, null).ToList();


            Console.WriteLine($"Total de Estados: {estados.Count}");
            Console.WriteLine($"Total de Cidades: {cidades.Count}");


        }
    }
}
