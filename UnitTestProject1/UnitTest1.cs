using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1 {

    [TestClass]
    public class UnitTest1 {

        [TestMethod]
        public void QSort() {
            int[] array = { 12, 30, 22, 17, 5, 6, 0, 53, 1, 71 };

            QuickSort(array, 0, array.Length - 1);
        }

        void QuickSort(int[] array, int low, int high) {
            if (high - low > 1) {
                int p = Partition(array, low, high);
                QuickSort(array, low, p - 1);
                QuickSort(array, p + 1, high);
            }
        }

        int GetPivot(int low, int high) {
            return new Random().Next(low, high + 1);
        }

        void Swap(int[] array, int low, int high) {
            int temp = array[low];
            array[low] = array[high];
            array[high] = temp;
        }

        int Partition(int[] array, int low, int high) {
            //Swap(array, low, GetPivot(low, high));

            int border = low + 1;
            for (int i = border; i <= high; i++) {
                if (array[i] > array[low])
                    Swap(array, i, border++);
            }

            Swap(array, low, border - 1);
            return border - 1;
        }


            [TestMethod]
            public void TestMethod1() {
                var queryCount = int.Parse(Console.ReadLine());
                var queue = new Queue<int>();
    
                for (int i = 0; i < queryCount; i++) {
                    var query = Console.ReadLine().Split(' ');
                    var command = int.Parse(query[0]);
                    var value = query.Length == 2 ? int.Parse(query[1]) : 0;
    
                    switch (command) {
                        case 1:
                            queue.Enqueue(value);
                            break;
                        case 2:
                            queue.Dequeue();
                            break;
                        case 3:
                            Console.Write(queue.Front());
                            break;
                    }
                }
            }
    
    
            public class Queue<T> {
    
                private readonly Stack<T> inStack = new Stack<T>();
                private readonly Stack<T> outstack = new Stack<T>();
    
                public void Enqueue(T t) {
                    inStack.Push(t);
                }
    
                public T Dequeue() {
                    if (!outstack.Any()) {
                        while (inStack.Any()) {
                            outstack.Push(inStack.Pop());
                        }
                    }
    
                    return outstack.Any() ? outstack.Pop() : default(T);
                }
    
                public T Front() {
                    if (!outstack.Any()) {
                        while (inStack.Any()) {
                            outstack.Push(inStack.Pop());
                        }
                    }
    
    
                    return outstack.Any() ? outstack.Peek() : default(T);
                }
    
            }



        public class Node {

            public void Add(string word) {
                if (word.Length > 1) {
                    if (NodeList.ContainsKey(word[1])) {
                        var node = NodeList[word[1]];
                        node.Add(word.Substring(1));
                    }
                    else {
                        var node = new Node();
                        node.Add(word.Substring(1));
                        NodeList.Add(word[1], node);
                    }
                }
                else {
                    Count++;
                }
            }
            public int Count { get; set; }
            public SortedList<char, Node> NodeList { get; } = new SortedList<char, Node>();
        }

        public class Trie {

            SortedList<char, Node> rootList = new SortedList<char, Node>();

            public void Add(string sentence) {
                foreach (string word in sentence.Split(' ')) {
                    if (rootList.ContainsKey(word[0])) {
                        var node = rootList[word[0]];
                        node.Add(word);
                    }
                    else {
                        var node = new Node();
                        node.Add(word);
                        rootList.Add(word[0], node);
                    }
                }
            }

            private Dictionary<string, int> occuranceCounts;
            private Node lastNodeOfPartial;
            private StringBuilder stringBuilder;
            public Dictionary<string, int> OccurancesOf(string partial) {
                if (string.IsNullOrEmpty(partial) || !rootList.ContainsKey(partial[0]))
                    return null;

                occuranceCounts = new Dictionary<string, int>();
                lastNodeOfPartial = null;

                var headNode = rootList[partial[0]];
                WalkPartial(headNode, partial.Substring(1));

                if (lastNodeOfPartial == null)
                    return null;

                stringBuilder = new StringBuilder(partial);
                TranverseAndCount(lastNodeOfPartial);

                return occuranceCounts;
            }

            private void TranverseAndCount(Node node) {
                if(node.Count > 0)
                    occuranceCounts.Add(stringBuilder.ToString(), node.Count);

                foreach (var kvp in node.NodeList) {
                    stringBuilder.Append(kvp.Key);
                    TranverseAndCount(kvp.Value);
                    stringBuilder.Remove(stringBuilder.Length - 1, 1);
                } 
            }

            private void WalkPartial(Node node, string partial) {
                if (partial.Length == 0) {
                    lastNodeOfPartial = node;
                    return;
                }

                if (!node.NodeList.ContainsKey(partial[0]))
                    return;

                var n = node.NodeList[partial[0]];

                WalkPartial(n, partial.Substring(1));
            }
        }

        [TestMethod]
        public void TrieTest() {
            var sentence = "tee too monk monkey monkies motion motor";
            var trie = new Trie();
            trie.Add(sentence);

            var counts = trie.OccurancesOf("mo");
            
        }
    }

}
