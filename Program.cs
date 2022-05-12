using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace TranscriptGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            //string line = Console.ReadLine();
            //string line = LoadFromFile();
            string output = "";
            foreach (string i in LoadFromFile())
            {
                string[] splitLine = i.Split('\t');
                
                switch (splitLine[0].Trim())
                {
                    case "//":
                    case "":
                    case "CHOICE":
                    case "FLAG":
                    case "JUMP":
                        break;
                    default:

                        if (splitLine.Length == 1)
                        {
                            output += splitLine[0].Trim() + "\n";
                        }
                        else
                        {
                            output += splitLine[0].Trim() + ": \"" + splitLine[1].Trim() + "\"\n";
                        }
                        break;
                }
                
            }

            output = output.Replace("VAR_name", "Cheese").Replace("VAR_LyName", "Lyson");

            Console.WriteLine(output);
        }

        static List<string> LoadFromFile()
        {
            string fullText = "";
            string line = "";
            List<string> fullLine = new List<string>();
            StreamReader sr = new StreamReader("C:\\Users\\22GaddieR\\OWO speak input.txt");
            //Read the first line of text
            line = sr.ReadLine();
            //Continue to read until you reach end of file
            while (line != null)
            {
                fullText += line + "\n";

                //write the line to console window
                //Console.WriteLine(line);
                fullLine.Add(line);
                //Read the next line
                line = sr.ReadLine();

            }
            //close the file
            sr.Close();

            return fullLine;

        }
    }
}
