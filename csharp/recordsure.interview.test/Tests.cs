using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace recordsure.interview.test
{
    public class Tests {
        Questions instance = new Questions();

        [Test]
        public void CanExtractNumbers() {
            Assert.AreEqual(new List<int> {
                123,
                234
            }, instance.ExtractNumbers(new List<string> {
                "123",
                "hello",
                "234"
            }));

            Assert.AreEqual(new List<int> {}, instance.ExtractNumbers(new List<string> {
                "hello",
                "there"
            }));

            Assert.AreEqual(new List<int> {
                123,
                345
            }, instance.ExtractNumbers(new List<string> {
                "hello",
                "there",
                "123",
                "234.23",
                "345"
            }));
        }

        [Test]
        public void CanGetLongestCommonWord() {
            Assert.AreEqual("wandering", instance.LongestCommonWord(
                new List<string> {
                    "love",
                    "wandering",
                    "goofy",
                    "sweet",
                    "mean",
                    "show",
                    "fade",
                    "scissors",
                    "shoes",
                    "gainful",
                    "wind",
                    "warn"
                },
                new List<string> {
                    "wacky",
                    "fabulous",
                    "arm",
                    "rabbit",
                    "force",
                    "wandering",
                    "scissors",
                    "fair",
                    "homely",
                    "wiggly",
                    "thankful",
                    "ear"
                })
            );
        }

        [Test]
        public void CanGetDistanceInMiles() {
            Assert.AreEqual(10.00, instance.DistanceInMiles(16.00));
        }

        [Test]
        public void CanGetDistanceInKilometers() {
            Assert.AreEqual(16.00, instance.DistanceInKm(10.00));
        }

        [Test]
        public void IsPalindrome() {
            var palindromes = new List<string> {
                "Wow","Balab","peep","seves","extxe"
            };
            var invalid = new List<string> {
                "Match","wowa","Happy","lala","hawi"
            };

            foreach (var word in palindromes) {
                Assert.True(instance.IsPalindrome(word));
            }

            foreach (var word in invalid) {
                Assert.False(instance.IsPalindrome(word));
            }
        }

        [Test]
        public void CanShuffle() {
            Assert.AreEqual(new List<string> { "two", "one" }, instance.Shuffle(new List<string> { "one", "two" }));
        }

        [Test]
        public void CanSort() {
            Assert.AreEqual(new int[] { 1, 2, 2, 5, 6, 6, 7, 34 }, instance.Sort(new int[] { 5, 6, 2, 1, 2, 7, 34, 6 }));
        }

        [Test]
        public void CanSumFibonacciNumbers() {
            Assert.AreEqual(4613732, instance.FibonacciSum());
        }

        [Test]
        public void CanGenerateListOfNumbers() {
            var list = instance.GenerateList();

            var current = 1;
            foreach (var num in list) {
                Assert.AreEqual(current, num);
                current++;
            }
        }
    }
}