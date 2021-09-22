using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordsCounter
{
    class Program
    {
        static bool IsCorrectWord(string str)
        {
            return !IsNumber(str) && !IsForbiddenWord(str);
        }
        static bool IsNumber(string str)
        {
            foreach (var ch in str)
            {
                if (ch < '0' || ch > '9')
                    return false;
            }
            return true;
        }
        static bool IsForbiddenWord(string str)
        {
            string[] forbiddenWords = { "в", "по", "на", "а", "—", "" };
            foreach (var word in forbiddenWords)
            {
                if (word == str)
                    return true;
            }
            return false;
        }

        static void Main(string[] args)
        {
            string str =  @"текущая пандемия, вызванная распространением коронавируса SARS-CoV-2[3].
                            Вспышка заболеваемости вирусом впервые была зафиксирована в Ухане, Китай, в декабре 2019 года[4][5][6][7].
                            30 января 2020 года Всемирная организация здравоохранения объявила эту вспышку чрезвычайной ситуацией в
                            области общественного здравоохранения, имеющей международное значение, а 11 марта — пандемией[8][9]. 
                            По состоянию на 20 сентября 2021 года зарегистрировано свыше 229 млн случаев заболевания по всему миру;
                            более 4,7 млн человек скончалось и более 206 млн выздоровело";
            char[] splitSymbols = {',', ' ', '.', ';', ':', '\'', '"', '\\', '/', '?', '!', '[', ']' };
            Dictionary<string, int> wordsCounter = new Dictionary<string, int>();
            string[] words = str.Split(splitSymbols, StringSplitOptions.RemoveEmptyEntries);
            


            foreach (var item in words.Where((string word) => IsCorrectWord(word) == true))
            {
                if (wordsCounter.ContainsKey(item))
                    wordsCounter[item]++;
                else
                    wordsCounter[item] = 1;
            }
            foreach (var item in wordsCounter)
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }
            Console.ReadKey();
        }
    }
}
