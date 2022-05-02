using System;
using System.IO;

namespace TextEditor
{
    class Program
    {
        static void Main(String[] args)
        {
            Menu();
        }

        static void Menu()
        {
            Console.Clear();
            Console.WriteLine("O que você deseja fazer?");
            Console.WriteLine("1 - Abrir Arquivo");
            Console.WriteLine("2 - Criar Novo Arquivo");
            Console.WriteLine("3 - Excluir um arquivo");
            Console.WriteLine("0 - Sair");
            short option = short.Parse(Console.ReadLine()!);

            switch(option)
            {
                case 0 : 
                    Console.WriteLine("Saindo..."); 
                    Thread.Sleep(1000); 
                    Environment.Exit(0); 
                    break;
                case 1 : Open(); break;
                case 2 : Edit(); break;
                case 3 : Delete(); break;
                default: Menu(); break;
            }
        }

        static void Open()
        {
            Console.Clear();
            Console.WriteLine("Qual o caminho do arquivo que você deseja abrir");
            var path = Console.ReadLine();
            
            Console.WriteLine($"Abrindo: {path}...");

            using(var file = new StreamReader(path!))
            {
                string text = file.ReadToEnd();
                Console.WriteLine(text);
            }

            Console.WriteLine("");
            Console.ReadLine();
            Menu();
        }

        static void Edit()
        {
            Console.Clear();
            Console.WriteLine("Digite seu texto abaixo (esc para sair)");
            Console.WriteLine("---------------------------------------");
            string text = "";

            // Faça isso
            do{
                text += Console.ReadLine();
                text += Environment.NewLine; // Colocando nova linha 
            }
            while (Console.ReadKey().Key != ConsoleKey.Escape); // Enquanto o usuário não clicar no "esc"

            Save(text);
        }
        
        static void Save(string text)
        {
            Console.Clear();
            string spaceWhite = "_";
            Console.WriteLine($" {spaceWhite} Qual o caminho para salvar o arquivo e qual o nome do arquivo (C:exemplo/example.txt)?");
            var path = Console.ReadLine(); // Caminho do arquivo passado pelo user

            // O using abre e fecha o arquivo de forma automática
            using (var file = new StreamWriter(path!)) // StreamWriter pede o caminho do arquivo
            {
                file.Write(text);
            }

            Console.WriteLine($"Arquivo {path} salvo com sucesso!");
            Console.ReadLine();
            Menu();
        }

        static void Delete()
        {
            Console.Clear();
            Console.WriteLine("Digite o caminho do arquivo que você deseja excluir:");
            var path = Console.ReadLine();
            bool result = File.Exists(path);

            if (result == true)
            {
                Console.WriteLine("Arquivo Encontrado");
                File.Delete(path!);
                Console.WriteLine("Arquivo deletado com sucesso!");
                Thread.Sleep(1000);
                Menu();
            }
            else
            {
                Console.WriteLine("Arquivo não encontrado");
                Menu();
            }
        }
    }
}

