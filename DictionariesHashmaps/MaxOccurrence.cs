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
		
		
		static void CommonOccurrence(int[] numbers) {
			var counts = new Dictionary<int, int>();
			foreach (int number in numbers) {
				int count;
				counts.TryGetValue(number, out count);
				count++;
				//Automatically replaces the entry if it exists;
				//no need to use 'Contains'
				counts[number] = count;
			}
			int mostCommonNumber = 0, occurrences = 0;
			foreach (var pair in counts) {
				if (pair.Value > occurrences ) {
					occurrences = pair.Value;
					mostCommonNumber = pair.Key;
				}
			}
			Console.WriteLine ("The most common number is {0} and it appears {1} times",
				mostCommonNumber, occurrences);
		}
 
        public static void Main(string[] args)
        {
 
            int[] array = new int[20] { 3, 6, 8, 5, 3, 5, 7, 6, 4, 3, 2, 3, 5, 7, 6, 4, 3, 4, 5, 7 };
            Hashtable hs = new Hashtable();
            MaxOccurrence(array, hs);
 
        }
    }
	
	
	
	