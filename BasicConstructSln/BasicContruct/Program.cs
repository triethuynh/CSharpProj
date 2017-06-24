using System;
using BasicContructClassLibrary;

/// <summary>
/// Tests for the Basic Construct
/// Triet Huynh @2017
/// </summary>
namespace BasicConstruct {
	class Program {
		const string PASS = "PASS";
		const string FAIL = "FAIL";
		const string YES = "Yes";
		const string NO = "No";

		static void Main(string[] args) {
			Number dividend = new Number();
			int count = 0;

			Program P = new Program();
			Console.WriteLine("** Is number a divisible by number b? **");
			P.IsDivisibleOutput(number: null, divisor: 12, expected: false, testNumber: ++count);
			P.IsDivisibleOutput(dividend, divisor: 0, expected: false, testNumber: ++count);
			P.IsDivisibleOutput(dividend, divisor: 15, expected: true, testNumber: ++count);
			
			dividend.Dividend = 50;
			P.IsDivisibleOutput(dividend, divisor: 1, expected: true, testNumber: ++count);
			P.IsDivisibleOutput(dividend, divisor: 50, expected: true, testNumber: ++count);
			P.IsDivisibleOutput(dividend, divisor: 5, expected: true, testNumber: ++count);
			P.IsDivisibleOutput(dividend, divisor: 45, expected: false, testNumber: ++count);		
			P.IsDivisibleOutput(dividend, divisor: 49, expected: false, testNumber: ++count);
			P.IsDivisibleOutput(dividend, divisor: 51, expected: false, testNumber: ++count);
			P.IsDivisibleOutput(dividend, divisor: 20, expected: false, testNumber: ++count);
			P.IsDivisibleOutput(dividend, divisor: -1, expected: true, testNumber: ++count);
			P.IsDivisibleOutput(dividend, divisor: -25, expected: true, testNumber: ++count);
			P.IsDivisibleOutput(dividend, divisor: -30, expected: false, testNumber: ++count);
			Console.WriteLine();

			Console.WriteLine("** Is number a divisible by 2? **");
			int[] numbers = { -100, 101, 102, -103, 104, 105, 106, 107, -108, 109, 110 };
			for (int i = 0; i < numbers.Length; i++) {
				dividend.Dividend = numbers[i];
				P.IsDivisibleOutput(dividend, divisor: 2, expected: (numbers[i] % 2 == 0 ? true : false), testNumber: ++count);
			}
			Console.WriteLine();

			Console.WriteLine("** Is number a divisible by 3? **");
			int[] numbersDivisibleByThree = { -4011, -3, 0, 3, 9, 12, 99, 111, 10914};
			for (int i = 0; i < numbersDivisibleByThree.Length; i++) {
				dividend.Dividend = numbersDivisibleByThree[i];
				P.IsDivisibleOutput(dividend, divisor: 3, expected: true, testNumber: ++count);
			}
			int[] numbersNotDivisibleByThree = { -4012, -7, -1, 8, 10, 11, 100, 10913 };
			for (int i = 0; i < numbersNotDivisibleByThree.Length; i++) {
				dividend.Dividend = numbersNotDivisibleByThree[i];
				P.IsDivisibleOutput(dividend, divisor: 3, expected: false, testNumber: ++count);
			}
			Console.WriteLine();

			Console.WriteLine("** Is number a divisible by 4? **");
			int[] numbersDivisibleByFour = { -500, -496, -96, -12, -8, -4, 0, 4, 8, 12, 16, 20, 88, 100, 104, 144, 100064 };
			for (int i = 0; i < numbersDivisibleByFour.Length; i++) {
				dividend.Dividend = numbersDivisibleByFour[i];
				P.IsDivisibleOutput(dividend, divisor: 4, expected: true, testNumber: ++count);
			}
			int[] numbersNotDivisibleByFour = { -590, -414, -87, -10, -7, 6, 11, 21, 99, 101, 510, 100094 };
			for (int i = 0; i < numbersNotDivisibleByFour.Length; i++) {
				dividend.Dividend = numbersNotDivisibleByFour[i];
				P.IsDivisibleOutput(dividend, divisor: 4, expected: false, testNumber: ++count);
			}
			Console.WriteLine();

			Console.WriteLine("** Is number a divisible by 5? **");
			int[] numbersDivisibleByFive = { -500, -105, -100, -95, -15, -10, -5, 0, 5, 10, 15, 20, 25, 95, 100, 105, (Int32.MaxValue / 10) * 10 };
			for (int i = 0; i < numbersDivisibleByFive.Length; i++) {
				dividend.Dividend = numbersDivisibleByFive[i];
				P.IsDivisibleOutput(dividend, divisor: 5, expected: true, testNumber: ++count);
			}
			int[] numberNotDivisibleByFive = { -599, -101, -6, 1, 9, 99, 101, 100051, (Int32.MaxValue / 10) * 10 - 1};
			for (int i = 0; i < numberNotDivisibleByFive.Length; i++) {
				dividend.Dividend = numberNotDivisibleByFive[i];
				P.IsDivisibleOutput(dividend, divisor: 5, expected: false, testNumber: ++count);
			}
			Console.WriteLine();

			Console.WriteLine("** Is number a divisible by 6? **");
			int[] numbersDivisibleBySix = { -750, -120, -90, -30, -18, -12, -6, 0, 6, 12, 18, 24, 48, 120, 1038 };
			int divisor = 6;
			for (int i = 0; i < numbersDivisibleBySix.Length; i++) {
				dividend.Dividend = numbersDivisibleBySix[i];
				P.IsDivisibleOutput(dividend, divisor, expected: true, testNumber: ++count);
			}
			int[] numberNotDivisibleBySix = { -500, -303, -104, -20, -16, -15, -9, -2, 3, 8, 99, 100, 111 };
			for (int i = 0; i < numberNotDivisibleBySix.Length; i++) {
				dividend.Dividend = numberNotDivisibleBySix[i];
				P.IsDivisibleOutput(dividend, divisor, expected: false, testNumber: ++count);
			}
			Console.WriteLine();

			Console.WriteLine("** Is number a divisible by 7? **");
			divisor = 7;
			int[] numbersDivisibleBySeven = { -770, -133, -49, -28, -14, -7, 0, 7, 21, 35, 56, 70, 1024 * 7 };
			for (int i = 0; i < numbersDivisibleBySeven.Length; i++) {
				dividend.Dividend = numbersDivisibleBySeven[i];
				P.IsDivisibleOutput(dividend, divisor, expected: true, testNumber: ++count);
			}
			int[] numberNotDivisibleBySeven = { -776, -132, -20, -13, -6, 3, 10, 78, 100, 1024 * 7 + 1 };
			for (int i = 0; i < numberNotDivisibleBySeven.Length; i++) {
				dividend.Dividend = numberNotDivisibleBySeven[i];
				P.IsDivisibleOutput(dividend, divisor, expected: false, testNumber: ++count);
			}
			Console.WriteLine();

			Console.WriteLine("** Is number a divisible by 8? **");
			divisor = 8;
			int[] numbersDivisibleByEight = { -880, -792, -104, -48, -16, -8, 0, 8, 24, 144, 976, 19013 * 8 };
			for (int i = 0; i < numbersDivisibleByEight.Length; i++) {
				dividend.Dividend = numbersDivisibleByEight[i];
				P.IsDivisibleOutput(dividend, divisor, expected: true, testNumber: ++count);
			}
			int[] numberNotDivisibleByEight = { -1806, -404, -10 -2, 1, 9, 11, 25, 578, 19013 * 8 + 1 };
			for (int i = 0; i < numberNotDivisibleByEight.Length; i++) {
				dividend.Dividend = numberNotDivisibleByEight[i];
				P.IsDivisibleOutput(dividend, divisor, expected: false, testNumber: ++count);
			}
			Console.WriteLine();

			Console.WriteLine("** Is number a divisible by 9? **");
			divisor = 9;
			int[] numbersDivisibleByNine = { -10341, -999, -108, -45, -9, 0, 9, 18, 90, 954, 9675, 201701 * 9 };
			for (int i = 0; i < numbersDivisibleByNine.Length; i++) {
				dividend.Dividend = numbersDivisibleByNine[i];
				P.IsDivisibleOutput(dividend, divisor, expected: true, testNumber: ++count);
			}
			int[] numberNotDivisibleByNine = { -10340, -101, -8, - 1, 19, 100, 201701 * 9 + 8 };
			for (int i = 0; i < numberNotDivisibleByNine.Length; i++) {
				dividend.Dividend = numberNotDivisibleByNine[i];
				P.IsDivisibleOutput(dividend, divisor, expected: false, testNumber: ++count);
			}
			Console.WriteLine();

			Console.WriteLine("** Is number a divisible by 11? **");
			divisor = 11;
			int[] numbersDivisibleByEleven = { -981904, -7260, -110, -44, -11, 0, 11, 66, 121, 7810, 10021, 980441};
			for (int i = 0; i < numbersDivisibleByEleven.Length; i++) {
				dividend.Dividend = numbersDivisibleByEleven[i];
				P.IsDivisibleOutput(dividend, divisor, expected: true, testNumber: ++count);
			}
			int[] numberNotDivisibleByEleven = { -981905, -8260, -120, -42, -10, 1, 12, 98, 120, 7811, 10121, 981445 };
			for (int i = 0; i < numberNotDivisibleByEleven.Length; i++) {
				dividend.Dividend = numberNotDivisibleByEleven[i];
				P.IsDivisibleOutput(dividend, divisor, expected: false, testNumber: ++count);
			}
			Console.WriteLine();

			Console.ReadLine();
		}

		/// <summary>
		/// Output onto the console if the number is divisible by the divisor
		/// </summary>
		/// <param name="number">the instance of Number</param>
		/// <param name="divisor">the divisor</param>
		/// <param name="expected">the expected test result</param>
		/// <param name="testNumber">The test case number</param>
		public void IsDivisibleOutput(Number number, int divisor, bool expected, int testNumber) {
			if (number == null) {
				Console.WriteLine(testNumber + ". Invalid input: Number can't be null.");
				return;
			}

			try {
				bool actual = number.isDivisibleBy(divisor);
				string actualResultText = (actual ? YES : NO);
				string testResult = (actual == expected? PASS : FAIL);
				Console.WriteLine(string.Format("{0}. [{1}] Is {2} divisible by {3}? {4}", testNumber, testResult, number.Dividend, divisor, actualResultText));
			} catch (DivideByZeroException ex) {
				Console.WriteLine(testNumber + ". " + ex.Message);
			} catch (Exception ex) {
				Console.WriteLine(testNumber + ". " + ex.Message);
			}
		}
	}

}
