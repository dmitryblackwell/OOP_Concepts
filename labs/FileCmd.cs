using System;
using System.IO;

namespace labs
{
    partial class ConsoleInterface
    {
        private void createFile(String name)
        {
            System.IO.Directory.CreateDirectory(SCRIPT_FOLDER);
            FileStream file = new FileStream(SCRIPT_FOLDER + name, FileMode.Create);
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
            writer.Close();
            file.Close();
        }
        private void deleteFile(String name)
        {
            Console.WriteLine("Are you sure you want to delete this file? [y/n]");
            String answer = Console.ReadLine();
            if (answer.Equals("y") || answer.Equals("Y"))
            {
                File.Delete(SCRIPT_FOLDER + name);
                Console.WriteLine("File deleted.");
            }
        }
        private void runFile(String name)
        {
            FileStream file = new FileStream(SCRIPT_FOLDER + name, FileMode.Open);
            StreamReader reader = new StreamReader(file);
            String cmdLine = reader.ReadLine();
            do
            {
                cmdLine += " ";
                String[] cmd = cmdLine.Split(new char[0]);
                performCmd(cmd);
                cmdLine = reader.ReadLine();
            }
            while(!cmdLine.Equals("quit"));
            reader.Close();
            file.Close();
        }
        
        private bool isMacros(String name)
        {
            name += ".txt";
            return File.Exists(SCRIPT_FOLDER + name);
        }
    }
}