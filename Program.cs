using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintAnagramsTogether
{
    class Storage
    {
        public int index;
        public string word;

        public Storage ()
        {

        }
        public Storage(int idx, string wd)
        {
            index = idx;
            word = wd;
        }        
    }

    class Program
    {
        static void Main(string[] args)
        {
            string[] wordArr = { "cat", "dog", "tac", "god", "act" };

            int size = wordArr.Length;
            string[] answerArr = PrintAnagramsTogether(wordArr, size);

            for (int i = 0; i < size; i++)
            {
                Console.WriteLine(answerArr[i]);
            }

            Console.ReadKey();
        }

        static string[] PrintAnagramsTogether(string[] givenStrings, int size)
        {
            string[] tempArr = new string[size];
            string tempString;

            List<Storage> myStorage = new List<Storage>();

            for (int i = 0; i < size; i++)
            {
                tempArr[i] = givenStrings[i];

                // another approach
                myStorage.Add(new Storage(i, SortString(givenStrings[i])));
            }


            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (i != j && (myStorage[i].word.CompareTo(myStorage[j].word) < 0))
                    {
                        Storage st = new Storage(myStorage[i].index, myStorage[i].word);
                        myStorage[i] = myStorage[j];
                        myStorage[j] = st;

                    }
                }
            }
            
            for (int i = 0; i < size; i++)
            {
                //Console.WriteLine(myStorage[i].index + ": " + myStorage[i].word);
                tempArr[i] = givenStrings[myStorage[i].index];
            }

            //Console.WriteLine("Before leaving the function.");

            return tempArr;
        }

        static string SortString(string str)
        {
            string[] tmpStr = new string[str.Length];
            char[] tmpChars = { };
            string tmpchar;


            for (int i = 0; i < str.Length; i++)
            {
                tmpStr[i] = char.ToString(str.ElementAt(i));
            }
            
            for (int i = 0; i < tmpStr.Length; i++)
            {
                for (int j = 0; j < tmpStr.Length; j++)
                {
                    if (tmpStr[j].CompareTo(tmpStr[i]) > 0)
                    {
                        tmpchar = tmpStr[i];
                        tmpStr[i] = tmpStr[j];
                        tmpStr[j] = tmpchar;
                    }
                }
            }

            StringBuilder stringToReturn = new StringBuilder();
            
            for (int i = 0; i < str.Length; i++)
            {
                stringToReturn.Append(tmpStr[i]);
            }

            return stringToReturn.ToString();
        }
    }
}
