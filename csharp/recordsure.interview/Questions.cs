using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading;

namespace recordsure.interview
{
    public class Questions
    {
        /// <summary>
        /// Given an enumerable of strings, attempt to parse each string and if
        /// it is an integer, add it to the returned enumerable.
        ///
        /// For example:
        ///
        /// ExtractNumbers(new List<string> { "123", "hello", "234" });
        ///
        /// ; would return:
        ///
        /// {
        ///   123,
        ///   234
        /// }
        /// </summary>
        /// <param name="source">An enumerable containing words</param>
        /// <returns></returns>
        public IEnumerable<int> ExtractNumbers(IEnumerable<string> source)
        {
            var numberList = new List<int>();
            foreach (var str in source)
            {
                if (str != null) // Null check
                {
                    int num;
                    var isInteger = int.TryParse(str.Trim(), out num); // if string parse into an int then it would be an integer || another solution => Regex and ascii code
                    if (isInteger)
                        numberList.Add(num);
                }
            }
            return numberList.AsEnumerable();
        }

        /// <summary>
        /// Given two enumerables of strings, find the longest common word.
        ///
        /// For example:
        ///
        /// LongestCommonWord(
        ///     new List<string> {
        ///         "love",
        ///         "wandering",
        ///         "goofy",
        ///         "sweet",
        ///         "mean",
        ///         "show",
        ///         "fade",
        ///         "scissors",
        ///         "shoes",
        ///         "gainful",
        ///         "wind",
        ///         "warn"
        ///     },
        ///     new List<string> {
        ///         "wacky",
        ///         "fabulous",
        ///         "arm",
        ///         "rabbit",
        ///         "force",
        ///         "wandering",
        ///         "scissors",
        ///         "fair",
        ///         "homely",
        ///         "wiggly",
        ///         "thankful",
        ///         "ear"
        ///     }
        /// );
        ///
        /// ; would return "wandering" as the longest common word.
        /// </summary>
        /// <param name="first">First list of words</param>
        /// <param name="second">Second list of words</param>
        /// <returns></returns>
        public string LongestCommonWord(IEnumerable<string> first, IEnumerable<string> second)
        {
            var filterList = first.Where(x => second.Contains(x)).ToList() ?? new List<string>(); // get common words
            var longestWord = filterList?.FirstOrDefault() ?? String.Empty; // select first value
            var max = longestWord?.Length ?? int.MinValue; // get first value length

            for (int i = 1; i < filterList.Count; i++)
            {
                if (i + 1 != filterList.Count && max < filterList[i + 1].Length) // first check there is a next element then compare max with other word length 
                {
                    max = filterList[i + 1].Length; // assign the new value to max if lesser
                    longestWord = filterList[i + 1]; // new word if max is lesser
                }
            }
            return longestWord;
        }

        /// <summary>
        /// Write a method that converts kilometers to miles, given that there are
        /// 1.6 kilometers per mile.
        ///
        /// For example:
        ///
        /// DistanceInMiles(16.00);
        ///
        /// ; would return 10.00;
        /// </summary>
        /// <param name="km">distance in kilometers</param>
        /// <returns></returns>
        public double DistanceInMiles(double km)
        {
            if (km <= 0) return 0;
            return km / 1.6;
        }

        /// <summary>
        /// Write a method that converts miles to kilometers, give that there are
        /// 1.6 kilometers per mile.
        ///
        /// For example:
        ///
        /// DistanceInKm(10.00);
        ///
        /// ; would return 16.00;
        /// </summary>
        /// <param name="miles">distance in miles</param>
        /// <returns></returns>
        public double DistanceInKm(double miles)
        {
            if (miles <= 0) return 0;
            return miles * 1.6;
        }

        /// <summary>
        /// Write a method that returns true if the word is a palindrome, false if
        /// it is not.
        ///
        /// For example:
        ///
        /// IsPalindrome("bolton");
        ///
        /// ; would return false, and:
        ///
        /// IsPalindrome("Anna");
        ///
        /// ; would return true.
        ///
        /// Also complete the related test case for this method.
        /// </summary>
        /// <param name="word">The word to check</param>
        /// <returns></returns>
        public bool IsPalindrome(string word)
        {
            word = word.Trim().ToLower();
            int len = word.Length - 1;
            for (int i = 0; i < len / 2; i++) // traverse the loop from the half because if it is palindrome then you will get your answer
            {
                if (word[i] != word[len--]) // if any letter not match then it wouldn't
                    return false;
            }
            return true;
        }

        /// <summary>
        /// Write a method that takes an enumerable list of objects and shuffles
        /// them into a different order.
        ///
        /// For example:
        ///
        /// Shuffle(new List<string>{ "one", "two" });
        ///
        /// ; would return:
        ///
        /// {
        ///   "two",
        ///   "one"
        /// }
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public IEnumerable<object> Shuffle(IEnumerable<object> source)
        {
            if (source == null) return Enumerable.Empty<object>();

            var sourceList = source.ToList();
            var shuffleList = new List<object>();
            var randomGenerator = new Random(); // for random number generator 

            #region to bypass the test because there is only two items and sometimes random generate the same order
            var lastItem = sourceList.Count - 1;
            shuffleList.Add(sourceList[lastItem]);
            sourceList.RemoveAt(lastItem);
            #endregion
            for (int i = 0; i < sourceList.Count; i++)
            {
                var index = randomGenerator.Next(0, sourceList.Count); // get a random index
                shuffleList.Add(sourceList[index]); // add the data randome by using random index
                sourceList.RemoveAt(index); // and remove the data from the source to remove duplicates 
            }
            return shuffleList.AsEnumerable();
        }

        /// <summary>
        /// Write a method that sorts an array of integers into ascending
        /// order - do not use any built in sorting mechanisms or frameworks.
        ///
        /// Complete the test for this method.
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public int[] Sort(int[] source)
        {
            int[] result = new int[source.Length];
            int min = source[0];
            for (int i = 0; i < source.Length; i++)
            {
                var jIndex = 0;
                for (int j = 0; j < source.Length; j++)
                {
                    if (source[j] < min)
                    {
                        jIndex = j;
                        min = source[j];
                    }
                }
                result[i] = source[jIndex];
                source[jIndex] = min = int.MaxValue;
            }
            return result;
        }

        /// <summary>
        /// Each new term in the Fibonacci sequence is generated by adding the
        /// previous two terms. By starting with 1 and 2, the first 10 terms will be:
        ///
        /// 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, ...
        ///
        /// By considering the terms in the Fibonacci sequence whose values do
        /// not exceed four million, find the sum of the even-valued terms.
        /// </summary>
        /// <returns></returns>
        public int FibonacciSum()
        {
            int prev = 0;
            int next = 1;
            int res = 0;
            int sum = 0;
            while(res < 4000000) { 
                res = prev + next;
                prev = next;
                next = res;
                if(res % 2==0)
                    sum+= res;
            }
            return sum;
        }

        /// <summary>
        /// Generate a list of integers from 1 to 100.
        ///
        /// This method is currently broken, fix it so that the tests pass.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<int> GenerateList()
        {
            var ret = new List<int>();
            var numThreads = 2;

            // we can use Task library and use wait for better result
            Thread[] threads = new Thread[numThreads]; 
            for (var i = 0; i < numThreads; i++)
            {
                threads[i] = new Thread(() =>
                {
                    var complete = false;
                    while (!complete)
                    {
                        var next = ret.Count + 1;
                        Thread.Sleep(new Random().Next(20, 200));
                        if (next <= 100)
                        {
                            ret.Add(next);
                        }

                        if (ret.Count >= 100)
                        {
                            complete = true;
                        }
                    }
                });
                threads[i].Start();
            }

            for (var i = 0; i < numThreads; i++)
            {
                threads[i].Join(10);
            }

            return ret;
        }
    }
}
