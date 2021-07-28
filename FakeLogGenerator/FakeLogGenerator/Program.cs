using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;

namespace FakeLogGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            ///////////////////////////////////////////////////////////
            //-ing Words
            ///////////////////////////////////////////////////////////
            //List<Word> Words = new List<Word>();
            ////Get file directory
            //string path = GetFileDirectory();
            //path += "\\ingWords.json";
            ////Load existing -ing words:
            //string currentWords;
            //using (var tw = new StreamReader(path, true))
            //{
            //    currentWords = tw.ReadToEnd();
            //    tw.Close();
            //}
            ////Clear file for writing later
            //File.WriteAllText(path, string.Empty);
            //List<Word> ExistingWords = JsonConvert.DeserializeObject<List<Word>>(currentWords);
            //if(ExistingWords != null)
            //{
            //    Words.AddRange(ExistingWords);
            //}

            ////Create -ing Words
            ////continue until intentionally ended, but keep count
            //int start = ExistingWords == null ? 0 : Words[Words.Count - 1].Id + 1;
            //for (int i = start; ; i++)
            //{
            //    Console.Write(">> ");
            //    string inputWord = Console.ReadLine();
            //    if (inputWord == "save")
            //    {
            //        break;
            //    }
            //    else if (inputWord.Substring(inputWord.Length - 3, 3) != "ing")
            //    {
            //        Console.WriteLine("invalid input. word not saved");
            //        continue;
            //    }
            //    else
            //    {
            //        inputWord = inputWord.ToLower();
            //        var alreadyAdded = Words.Where(m => m.Value == inputWord).FirstOrDefault();
            //        if(alreadyAdded != null)
            //        {
            //            Console.WriteLine("word already added");
            //            continue;
            //        }
            //        Word word = new Word(i, inputWord);
            //        Words.Add(word);
            //    }
            //}

            ////Write all words to file
            //using (var tw = new StreamWriter(path, true))
            //{
            //    tw.Write(JsonConvert.SerializeObject(Words));
            //    tw.Close();
            //}

            ///////////////////////////////////////////////////////////
            //Phrases
            ///////////////////////////////////////////////////////////

            //List<Word> Words = new List<Word>();
            ////Get file directory
            //string path = GetFileDirectory();
            //path += "\\phrases.json";
            ////Load existing -ing words:
            //string currentWords;
            //using (var tw = new StreamReader(path, true))
            //{
            //    currentWords = tw.ReadToEnd();
            //    tw.Close();
            //}
            ////Clear file for writing later
            //File.WriteAllText(path, string.Empty);
            //List<Word> ExistingWords = JsonConvert.DeserializeObject<List<Word>>(currentWords);
            //if (ExistingWords != null)
            //{
            //    Words.AddRange(ExistingWords);
            //}

            ////Create -ing Words
            ////continue until intentionally ended, but keep count
            //int start = ExistingWords == null ? 0 : Words[Words.Count - 1].Id + 1;
            //for (int i = start; ; i++)
            //{
            //    Console.Write(">> ");
            //    string inputWord = Console.ReadLine();
            //    if (inputWord == "save")
            //    {
            //        break;
            //    }
            //    else
            //    {
            //        inputWord = inputWord.ToLower();
            //        var alreadyAdded = Words.Where(m => m.Value == inputWord).FirstOrDefault();
            //        if (alreadyAdded != null)
            //        {
            //            Console.WriteLine("word already added");
            //            continue;
            //        }
            //        Word word = new Word(i, inputWord);
            //        Words.Add(word);
            //    }
            //}

            ////Write all words to file
            //using (var tw = new StreamWriter(path, true))
            //{
            //    tw.Write(JsonConvert.SerializeObject(Words));
            //    tw.Close();
            //}

            ///////////////////////////////////////////////////////////
            //Printing stuff
            ///////////////////////////////////////////////////////////

            List<Word> IngWords = new List<Word>();
            List<Word> Phrases = new List<Word>();
            //Get file directory
            string path = GetFileDirectory();
            string ingWordsPath = path + "\\ingWords.json";
            string phrasesPath = path + "\\phrases.json";
            //Load existing -ing words:
            string fileContents;
            using (var tw = new StreamReader(ingWordsPath, true))
            {
                fileContents = tw.ReadToEnd();
                tw.Close();
            }
            List<Word> ExistingWords = JsonConvert.DeserializeObject<List<Word>>(fileContents);
            if (ExistingWords != null)
            {
                IngWords.AddRange(ExistingWords);
            }

            //Load existing phrases
            using (var tw = new StreamReader(phrasesPath, true))
            {
                fileContents = tw.ReadToEnd();
                tw.Close();
            }
            ExistingWords = JsonConvert.DeserializeObject<List<Word>>(fileContents);
            if (ExistingWords != null)
            {
                Phrases.AddRange(ExistingWords);
            }

            //Create random phrases by randomly selecting from the two lists
            Random random = new Random();
            while(true)
            {
                string ingWord = IngWords[random.Next(IngWords.Count)].Value;
                string phrase = Phrases[random.Next(Phrases.Count)].Value;
                PrintLog(ingWord + " " + phrase, random);
            }
        }

        static string GetFileDirectory()
        {
            //get path
            string path = Directory.GetCurrentDirectory();
            //Moves up 3 parents to be in same directory as files
            return Directory.GetParent(Directory.GetParent(Directory.GetParent(path).FullName).FullName).FullName;
        }

        static void PrintLog(string line, Random random)
        {
            Console.Write("\r>> ");
            var chars = line.ToCharArray();
            //print out string one character at a time
            foreach(var ch in chars)
            {
                Console.Write(ch);
                Thread.Sleep(50);
            }
            Console.WriteLine();
            Console.Write(">> ");

            //pause before starting next line.
            int timeoutMilli = random.Next(100, 1000);
            Thread.Sleep(timeoutMilli);
        }
    }
}
