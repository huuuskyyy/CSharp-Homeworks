using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

class Program
{
    public class CharNode
    {
        private char letter;
        private Dictionary<char, CharNode> letters;
        private int occurences;

        public CharNode(char letter)
        {
            this.letter = letter;
            this.letters = new Dictionary<char, CharNode>();
            this.occurences = 1;
        }

        public char Letter
        {
            get
            {
                return this.letter;
            }

        }

        public int Occurences
        {
            get
            {
                return this.occurences;
            }
            set
            {
                this.occurences = value;
            }
        }

        public int WordLength()
        {
            return this.letters['|'].Occurences;
        }

        public void Add(char letter)
        {
            if (!this.letters.ContainsKey(letter))
            {
                this.letters.Add(letter, new CharNode(letter));
            }
            else
            {
                letters[letter].Occurences++;
            }

        }

        public CharNode this[char nodeLetter]
        {
            get
            {
                return this.letters[nodeLetter];
            }
        }

        public bool ContainsLetter(char letterToCheck)
        {
            return this.letters.ContainsKey(letterToCheck);
        }
    }

    public class WordsTree
    {
        private Dictionary<char, CharNode> letters;

        public WordsTree()
        {
            this.letters = new Dictionary<char, CharNode>();
        }

        public void Add(string word)
        {
            char letter = word[0];

            if (word.Length == 1)
            {
                if (!this.letters.ContainsKey(letter))
                {
                    this.letters.Add(letter, new CharNode(letter));
                }
                else
                {
                    this.letters[letter].Occurences++;
                }

                return;
            }

            char currentLetterToAdd = word[1];

            int position = 1;

            if (!this.letters.ContainsKey(letter))
            {

                this.letters.Add(letter, new CharNode(letter));
            }

            AddLetters(this.letters[letter], currentLetterToAdd, word, position);
        }

        public int SearchOccurences(string word)
        {
            int position = 0;
            char currentLetter = word[position];
            int occurences = 0;

            if (!this.letters.ContainsKey(currentLetter))
            {
                return 0;
            }

            FindOccurence(this.letters[currentLetter], word, position, ref occurences);
            return occurences;
        }

        private void FindOccurence(CharNode currentNode, string word, int position, ref int occurences)
        {
            position++;

            if (position == word.Length - 1)
            {
                occurences = currentNode.Occurences;
                return;
            }
            else if (!currentNode.ContainsLetter(word[position]))
            {
                occurences = 0;
                return;
            }
            else
            {
                FindOccurence(currentNode[word[position]], word, position, ref occurences);
            }
        }

        private void AddLetters(CharNode currentNode, char letterToAdd, string word, int position)
        {
            currentNode.Add(letterToAdd);
            char letter = letterToAdd;
            position++;

            if (position == word.Length)
            {
                currentNode.Add('|');
                return;
            }
            letterToAdd = word[position];

            AddLetters(currentNode[letter], letterToAdd, word, position);
        }
    }

    static void Main()
    {
        string fileLocation = "@../../text.txt";
        StreamReader reader = new StreamReader(fileLocation);
        string text;

        using(reader)
        {
            text = reader.ReadToEnd();
        }

        char[] separators = new char[] { '.', ',', ' ', '?', '!', '-', '(', ')' };

        string[] words = text.Split(separators, StringSplitOptions.RemoveEmptyEntries);

        WordsTree tree = new WordsTree();
        Dictionary<string, int> dict = new Dictionary<string, int>();

        Stopwatch watch = new Stopwatch();
        watch.Start();

        foreach (var word in words)
        {
            tree.Add(word);
        }

        Console.WriteLine(tree.SearchOccurences("sit"));
        watch.Stop();
        Console.WriteLine("Time elapsed trie structure: {0}", watch.Elapsed);

        watch.Reset();
        watch.Start();

        foreach (var word in words)
        {
            if (dict.ContainsKey(word))
            {
                dict[word]++;
            }
            else
            {
                dict.Add(word, 1);
            }
        }
      
        Console.WriteLine(dict["sit"]);
        watch.Stop();
        Console.WriteLine("Time elapsed dictionary: {0}", watch.Elapsed);
    }
}
