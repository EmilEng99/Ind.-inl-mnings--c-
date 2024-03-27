namespace Individuell_Inlämning
{
    internal class Program
    {
        //Creates a generic list with words that begins with user selected letter
        public static List<string> OutputAsList(string[] a_words, string letter)
        {
            List<string> arrayList = new List<string>();

            foreach (var word in a_words)
            {
                if (word.StartsWith(letter.ToLower()) || (word.StartsWith(letter.ToUpper())))
                {
                    arrayList.Add(word);
                }
            }
            return arrayList;
        }

        //Takes the list of words and writes to a txt.file. Replace the location-path to you preferred choise to see result
        public static void WriteToTxt(List<string> result)
        {
            using (StreamWriter writeWords = new StreamWriter("C:\\Users\\emile\\Desktop\\C-sharp\\VS Community\\Individuell Inlämning\\Individuell Inlämning\\File.txt"))
            {
                foreach (var words in result)
                {
                    writeWords.WriteLine(words);
                }
                writeWords.Close();

            }
        }
        static void Main(string[] args)
        {
            bool inputFromUser = false;
            do
            {
                //User defined letter 
                Console.WriteLine("Skriv in första bokstaven för orden du vill leta efter: ");
                string letter = Console.ReadLine();
                int letterLength = letter.Length;

                if (letterLength > 1 || letterLength < 1)
                {
                    //Checks that only a single letter is written
                    inputFromUser = false;
                }
                else
                {
                    inputFromUser = true;

                    //User can choose to write a sentence to find words with selected letter
                    Console.WriteLine("Skriv en mening: ");
                    string sentence = Console.ReadLine();
                    string[] wordsInSentence = sentence.Split(' ');

                    //Creates a list from the return och OutputAsList-method
                    List<string> result = OutputAsList(wordsInSentence, letter);

                    WriteToTxt(result);
                }
            }
            while (inputFromUser == false);
        }
    }
}
