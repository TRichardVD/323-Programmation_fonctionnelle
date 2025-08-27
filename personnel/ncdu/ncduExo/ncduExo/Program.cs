using System;
using System.IO;
using System.Runtime.CompilerServices;
using static System.Net.Mime.MediaTypeNames;

namespace MyApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Afficher les résultat du dossier actuel
            if (args.Length == 0)
            {
                showFolderInformations(AppDomain.CurrentDomain.BaseDirectory);
            }
            else
            {
                showFolderInformations(args[0]);
            }



            // REPL



        }

        static long getDirectorySize(string path)
        {
            long size = 0;
            foreach (string file in Directory.GetFiles(path))
            {
                FileInfo fileInfo = new FileInfo(file);
                size += fileInfo.Length;
            }

            foreach(string directory in Directory.GetDirectories(path))
            {
                size += getDirectorySize(directory);
            }

            return size;
        }


        static void writeInfoItemConsole(long size, string relativePath)
        {
            Console.WriteLine($"{size} [#] {relativePath}");
        }

        static void showFolderInformations(string path)
        {
            if (!Directory.Exists(path))
            {
                throw new DirectoryNotFoundException(path);
            }

            foreach(string file in Directory.GetFiles(path))
            {
                FileInfo fileInfo = new FileInfo(file);
                writeInfoItemConsole (fileInfo.Length, fileInfo.Name);
                
            }

            foreach (string directory in Directory.GetDirectories(path))
            {
                DirectoryInfo directoryInfo = new DirectoryInfo(directory);
                writeInfoItemConsole(getDirectorySize(directory), directoryInfo.Name);
                

            }
        }

    }
}