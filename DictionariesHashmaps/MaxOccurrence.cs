class MainClass
    {
 
        static void MaxOccurrence(int[] array, Hashtable hs)
        {
            int mostCommom = array[0];
            int occurences = 0;
            foreach (int num in array)
            {
                if (!hs.ContainsKey(num))
                {
                    hs.Add(num, 1);
                }
                else
                {
                    int tempOccurences = (int)hs[num];
                    tempOccurences++;
                    hs.Remove(num);
                    hs.Add(num, tempOccurences);
 
                    if (occurences < tempOccurences)
                    {
                        occurences = tempOccurences;
                        mostCommom = num;
                    }
                }
            }
            foreach (DictionaryEntry entry in hs)
            {
                Console.WriteLine("{0}, {1}", entry.Key, entry.Value);
            }
            Console.WriteLine("The commmon numer is " + mostCommom + " And it appears " + occurences + " times");
        }
 
        public static void Main(string[] args)
        {
 
            int[] array = new int[20] { 3, 6, 8, 5, 3, 5, 7, 6, 4, 3, 2, 3, 5, 7, 6, 4, 3, 4, 5, 7 };
            Hashtable hs = new Hashtable();
            MaxOccurrence(array, hs);
 
        }
    }