using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HackerRankUnitTests {
    [TestClass]
    public class HackerRank {
        [TestMethod]
        public void DiagonalDifference() {

        }

        static int _diagonalDifference(int[][] a) {
            var length = a.Length;

            var primaryDiagonal = 0;
            var secondaryDialognal = 0;
            var pIndex = 0;
            var sIndex = length - 1;

            for (var i = 0; i < length; i++) {
                primaryDiagonal += a[i][pIndex++];
                secondaryDialognal += a[i][sIndex--];
            }

            return Math.Abs(primaryDiagonal - secondaryDialognal);
        }

        static void plusMinus(int[] arr) {
            var positives = arr.Count(x => x > 0);
            var negatives = arr.Count(x => x < 0);
            var zeros = arr.Length - positives - negatives;

            Console.WriteLine((double)positives / arr.Length);
            Console.WriteLine((double)negatives / arr.Length);
            Console.WriteLine((double)zeros / arr.Length);
        }

        static void staircase(int n) {
            for (var i = 0; i <= n; i++) {
                Console.WriteLine(new String(' ', n - i - 1) + new String('#', i));
            }
        }

        static void miniMaxSum(int[] arr) {
            Console.WriteLine($"{arr.OrderBy(x => x).Take(3).Sum(x => Convert.ToInt64(x))} {arr.OrderByDescending(x => x).Take(3).Sum(x => Convert.ToInt64(x))}");
        }

        static int birthdayCakeCandles(int n, int[] ar) {
            var max = ar.Max();
            Console.WriteLine($"{ar.Count(x => x == ar.Max())}");
            return 0;
        }

        static int birthdayCakeCandles2(int n, int[] ar) {
            var max = 0;
            var count = 0;

            for (var i = 0; i < ar.Length; i++) {
                var value = ar[i];
                if (max < value) {
                    max = value;
                    count = 0;
                }
                else if (max == value) {
                    count++;
                }
            }

            return count;
        }

        [TestMethod]
        public void Time() {
            var military = timeConversion("01:00:00AM");
            Assert.IsTrue(military == "01:00:00");

            military = timeConversion("12:00:00AM");
            Assert.IsTrue(military == "00:00:00");

            military = timeConversion("12:00:00PM");
            Assert.IsTrue(military == "12:00:00");

            military = timeConversion("01:00:00PM");
            Assert.IsTrue(military == "13:00:00");
        }
        static string timeConversion(string s) {
            var am = s.EndsWith("am", StringComparison.InvariantCultureIgnoreCase);
            s = s.Substring(0, s.Length - 2);

            if (s.StartsWith("12"))
                s = "00" + s.Substring(2, s.Length - 2);

            if (am) return s;

            return (Convert.ToInt32(s.Substring(0, 2)) + 12).ToString("D2") + s.Substring(2, s.Length - 2);
        }

        [TestMethod]
        public void TestConver() {
            var value = Convert.ToInt32("10", 2);
            char[] s = new char[32];
            for (int i = 0; i < 32; i++) {
                s[i] = (value & (1 << i)) != 0 ? '1' : '0';
            }

            var binary = new String(s);
        }

        static string BitString(int value) {
            char[] s = new char[32];
            for (int i = 0; i < 32; i++) {
                s[i] = (value & (1 << i)) != 0 ? '1' : '0';
            }

            return new String(s);
        }

        static void Main(String[] args) {
            Console.ReadLine().Split(' ');
            // var aBitLen = Convert.ToInt32(bitSizes[0]);
            // var bBitLen = Convert.ToInt32(bitSizes[1]);

            var aValue = Convert.ToInt32(Console.ReadLine(), 2);
            var bValue = Convert.ToInt32(Console.ReadLine(), 2);

            var input = Console.ReadLine();
            while (!string.IsNullOrEmpty(input)) {
                var command = input.Split(' ');

                switch (command[0]) {
                    case "set_a": {
                            int index = Convert.ToInt32(command[1]);
                            int bitValue = Convert.ToInt32(command[2]);
                            aValue = SetOrClear(aValue, index, bitValue);
                        }
                        break;
                    case "set_b": {
                            int index = Convert.ToInt32(command[1]);
                            int bitValue = Convert.ToInt32(command[2]);
                            aValue = SetOrClear(aValue, index, bitValue);
                        }
                        break;
                    case "get_c":
                        var bitToCheck = Convert.ToInt32(command[1]);
                        var sum = aValue + bValue;
                        Console.Out.Write(ValueOf(sum, bitToCheck));
                        break;
                }
            }
        }

        static int ValueOf(int value, int bitIndex) {
            return value & (1 << bitIndex);
        }

        static int SetOrClear(int value, int bitIndex, int bitValue) {
            return bitValue == 0 ? value & ~(1 << bitIndex) : value | 1 << bitIndex;
        }

        static int lonelyinteger(int[] a) {
            return a.GroupBy(x => x).FirstOrDefault(g => g.Count() == 1)?.Key ?? 0;
        }

    }
