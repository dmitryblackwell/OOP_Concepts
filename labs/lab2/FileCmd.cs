using System;
using System.IO;

namespace labs.lab2
{
    partial class ConsoleInterface
    {
        private void createFile(String name)
        {
            FileStream file = new FileStream(name, FileMode.Create);
            StreamWriter writer = new StreamWriter(file);
            Console.WriteLine("Enter all your cmds here. After you done enter: quit");
            String cmdLines = "";
            String cmd = "";
            
            while (!cmd.Equals("quit"))
            {
                cmd = Console.ReadLine();
                cmdLines += cmd + "\u000D\u000A";
            }
            writer.Write(cmdLines);
            writer.Close();
            Console.WriteLine("File " + name + " created and writed.");
        }
        private void deleteFile(String name)
        {
            Console.WriteLine("Are you sure you want to delete this file? [y/n]");
            String answer = Console.ReadLine();
            if (answer.Equals("y") || answer.Equals("Y"))
            {
                File.Delete(name);
                Console.WriteLine("File deleted.");
            }
        }
        private void runFile(String name)
        {
            FileStream file = new FileStream(name, FileMode.Open);
            StreamReader reader = new StreamReader(file);
            String cmd = reader.ReadLine();
            do
            {
                performCmd(cmd);
                cmd = reader.ReadLine();
            }
            while(!cmd.Equals("quit"));
        }
    }
}