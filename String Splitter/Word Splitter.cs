using System.Collections.Generic;
using System.Linq;

namespace String_Splitter
{
    public class WordSplitter
    {
        readonly string[] _dictionary;

        //To boost performance
        List<IndexedString>[,] _substringsbuffer;

        public WordSplitter(IEnumerable<string> dictionary)
        {
            _dictionary = dictionary.OrderByDescending(x => x.Length).ToArray();
        }

        public string SplitToWords(string input)
        {

            _substringsbuffer = new List<IndexedString>[input.Length + 1, input.Length + 1];

            var stringtosplit = new IndexedString(0, input, false);


            var sortedlist = RecursiveWordSearch(stringtosplit, _dictionary).OrderBy(x => x.Index);

            return sortedlist.Aggregate("", (current, word) => current + word.Text + " ");
        }

        //
        // Private Methods
        //
        private IEnumerable<IndexedString> RecursiveWordSearch(
            IndexedString stringtosplit,
            IEnumerable<string> dictionary)
        {
            //
            // Checking the buffer
            //
            int length = stringtosplit.Text.Length;
            if (_substringsbuffer[stringtosplit.Index, length + stringtosplit.Index] != null)
                return _substringsbuffer[stringtosplit.Index, length + stringtosplit.Index];

            //
            // Initializing result list
            //
            var result = new List<IndexedString> {stringtosplit};

            //
            // Narrowing the dictionary
            //
            string[] newdictionary = dictionary.Where(x => stringtosplit.Text.Contains(x)).ToArray();

            //
            // Trivial case
            //
            if (newdictionary.Length < 1)
            {
                return result;
            }

            //
            // Non trivial case
            //
            foreach (string entry in newdictionary)
            {
                var temporarylist = new List<IndexedString>();

                //
                // Deviding the string to 3 parts: the entry, left and right 
                //
                IndexedString[] devidedBytheEntry = splitByEntry(stringtosplit, entry);

                IndexedString left = devidedBytheEntry[0];
                IndexedString middle = devidedBytheEntry[1];
                IndexedString right = devidedBytheEntry[2];

                //
                // Calling the method on the other two parts recursively
                //
                temporarylist.Add(middle);
                temporarylist.AddRange(RecursiveWordSearch(left, newdictionary));
                temporarylist.AddRange(RecursiveWordSearch(right, newdictionary));

                //
                // Comparing current score and temporary score
                //
                var temporaryScore = temporarylist.Where(x => x.Word);
                var currentScore = result.Where(x => x.Word);

                if (temporaryScore.Select(
                    x => x.Text.Length).Sum() > currentScore.Select(
                    x => x.Text.Length).Sum())
                {
                    result = temporarylist;
                }
            }
            _substringsbuffer[stringtosplit.Index, length + stringtosplit.Index] = result;
            return result;
        }

        private IndexedString[] splitByEntry(IndexedString source, string entry)
        {

            int indexofentry = source.Text.IndexOf(entry, System.StringComparison.Ordinal);
            var result = new IndexedString[3];

            //
            // Compute realitve indexes
            //
            int leftindex = source.Index;
            int entryindex = source.Index + indexofentry;
            int rightindex = source.Index + indexofentry + entry.Length;

            //
            // Generate substrings
            //
            string leftstring = source.Text.Substring(0, indexofentry);
            string entrystring = entry;
            string rightstring = source.Text.Substring(indexofentry + entry.Length);

            //
            // Generate results
            //
            result[0] = new IndexedString(leftindex, leftstring, false);
            result[1] = new IndexedString(entryindex, entrystring, true);
            result[2] = new IndexedString(rightindex, rightstring, false);
            return result;
        }

        private class IndexedString
        {
            public int Index { get; private set; }
            public string Text { get; private set; }
            public bool Word { get; private set; }

            public IndexedString(int index, string text, bool word)
            {
                Index = index;
                Text = text;
                Word = word;
            }
        }
    }
}
