using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Task2
{
    static class Message
    {
        private static string RemovePunctuation(string message)
        {
            return Regex.Replace(message, @"[ ,.!?(){}\[\]-]", " ");
        }

        private static string[] ConvertToWordArray(string message)
        {
            message = RemovePunctuation(message);
            return message.Split(new char[] { ' ' });
        }

        public static string MaxWordSizeMessage(string message, int maxWordSize)
        {
            string[] wordArray = ConvertToWordArray(message);

            StringBuilder resultMessage = new StringBuilder();
            for (int i = 0; i < wordArray.Length; ++i)
            {
                if (0 == wordArray[i].Length)
                    continue;

                if (wordArray[i].Length <= maxWordSize)
                {
                    if (0 == resultMessage.Length)
                        resultMessage.AppendFormat(wordArray[i]);
                    else
                        resultMessage.AppendFormat(", {0}", wordArray[i]);
                }
            }

            return resultMessage.ToString();
        }

        public static string RemoveWordsWithEnd(string message, char symbol)
        {
            StringBuilder pattern = new StringBuilder();
            pattern.AppendFormat(@"\b[a-zA-Z0-9]*{0}\b", symbol);

            return Regex.Replace(message, pattern.ToString(), String.Empty);
        }

        public static string MaxSizeWord(string message)
        {
            string[] wordArray = ConvertToWordArray(message);

            if (0 == wordArray.Length)
                return string.Empty;

            string maxSizeWord = wordArray[0];
            for (int i = 0; i < wordArray.Length; ++i)
                if (maxSizeWord.Length < wordArray[i].Length)
                    maxSizeWord = wordArray[i];

            return maxSizeWord;
        }

        public static string GetMaxSizeWords(string message)
        {
            string[] wordArray = ConvertToWordArray(message);

            if (0 == wordArray.Length)
                return string.Empty;

            int maxSize = wordArray[0].Length;
            
            for (int i = 0; i < wordArray.Length; ++i)
                if (maxSize < wordArray[i].Length)
                    maxSize = wordArray[i].Length;

            StringBuilder result = new StringBuilder();
            for (int i = 0; i < wordArray.Length; ++i)
                if (maxSize == wordArray[i].Length)
                    result.AppendFormat("{0} ", wordArray[i]);

            return result.ToString();
        }

        public static void FrequencyAnalyze(string messageText, 
            string words, IDictionary<string, int> dictionary)
        {
            string[] wordArray = ConvertToWordArray(words);
            for (int i = 0; i < wordArray.Length; ++i)
            {
                string targetWord = wordArray[i];
                if (0 == targetWord.Length)
                    continue;

                int wordsCount = 0;
                int startIndex = 0;
                while (true)
                {
                    startIndex = messageText.IndexOf(targetWord, startIndex);
                    if (-1 == startIndex)
                        break;
                    ++startIndex;
                    ++wordsCount;
                }
                dictionary[targetWord] = wordsCount;
            }
        }

    }
}
