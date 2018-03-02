using System;

namespace HackerRank {
    class Program {
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
                        Console.Out.WriteLine(ValueOf(sum, bitToCheck));
                        break;
                }

                input = Console.ReadLine();
            }
        }

        static int ValueOf(int value, int bitIndex) {
            return (value & (1 << bitIndex)) >> bitIndex;
        }

        static int SetOrClear(int value, int bitIndex, int bitValue) {
            return bitValue == 0 ? value & ~(1 << bitIndex) : value | 1 << bitIndex;
        }

    }
}
