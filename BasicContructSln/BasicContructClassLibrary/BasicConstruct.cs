using System;

/// <summary>
/// Problem statement: SDE Skill - qotd 06/23/2017
/// Triet Huynh @2017
/// Ref.: Divisible rules
///		1. Problem statement in "06.Programming Excercises - Page 3 - June 19 2017.pdf" from "qotd" of "SDE Skills" slack channel
///		2. http://123doc.org/document/557091-dau-hieu-chia-het-cho-2-3-4-5-6-7-8-9.htm (Vietnamese)
/// </summary>
namespace BasicContructClassLibrary {
	/// <summary>
	/// Class DivisibilityRules
	/// </summary>
	public class Number {
		private int number;

		/// <summary>
		/// Default contructor
		/// </summary>
		public Number() {
			this.number = 0;
		}

		/// <summary>
		/// One argument constructor, the dividend
		/// </summary>
		/// <param name="number">the dividend</param>
		public Number(int number) {
			this.number = number;
		}

		/// <summary>
		/// Accessor for the number
		/// </summary>
		public int Dividend {
			get { return this.number; }
			set { this.number = value; }
		}

		/// <summary>
		/// Determine if the dividend (number) is divisible by the given divisor
		/// </summary>
		/// <param name="divisor"></param>
		/// <returns>true if the dividend (number) is divisible by the given divisor</returns>
		public bool isDivisibleBy(int divisor) {
			try {
				return this.isDivisible(this.number, divisor);
			} catch (Exception ex) {
				throw ex;
			}
		}

		/// <summary>
		/// Determine if the given dividend is divisible by the given divisor
		/// </summary>
		/// <param name="dividend">the given dividend</param>
		/// <param name="divisor">the given divisor</param>
		/// <returns>true if the given dividend is divisible by the given divisor; false, otherwise</returns>
		public bool isDivisible(int dividend, int divisor) {
			if (divisor == 0) {
				throw new DivideByZeroException();
			}

			int quotient = dividend / divisor;
			int remainder = dividend - quotient * divisor;

			return (remainder == 0 ? true : false);
		}

		/// <summary>
		/// Accessor to determine if the number is divisible by two (2).
		/// A number is divisible by 2 if the last digit is divisible by 2
		/// </summary>
		public bool IsDivisibleByTwo {
			get {
				int lastDigit = this.LastDigit;

				return (lastDigit == 0 || lastDigit == 2 || lastDigit == 4 || lastDigit == 6 || lastDigit == 8);
			}
		}

		/// <summary>
		/// Accessor to determine if the number is divisible by three (3).
		/// A number is divisible by 3 if the sum of all digits is divisible by 3
		/// </summary>
		public bool IsDivisibleByThree {
			get {
				if (this.number == 0 || this.number == 3) {
					return true;
				}

				int sum = this.LastDigit;

				int quotient = this.number / 10;
				while (quotient > 9) {
					sum += this.GetLastDigit(quotient);
					quotient /= 10;
				}

				if (this.number > 9) {
					sum += quotient;
				}

				return this.isDivisible(dividend: sum, divisor: 3);
			}
		}

		/// <summary>
		/// Accessor to determine if the number is divisible by four (4).
		/// A number is divisible by 4 if the last two digits formed a number which is divisible by 4
		/// </summary>
		public bool IsDivisibleByFour {
			get {
				// One digit numbers
				int absOfNumber = Math.Abs(number);
				const int four = 4;
				if (absOfNumber < 10) {
					return (absOfNumber == 0 || absOfNumber == 4 || absOfNumber == 8);
				}

				// Two-digit numbers
				if (absOfNumber < 100) {
					return this.isDivisibleBy(divisor: four);
				}

				// Numbers with more than two-digits
				int rightMostDigit = this.GetLastDigit(number: absOfNumber);
				int tenthDigit = this.GetLastDigit(absOfNumber / 10);

				return this.isDivisible(dividend: (tenthDigit * 10 + rightMostDigit), divisor: four);
			}
		}

		/// <summary>
		/// Accessor to determine if the number is divisible by five (5).
		/// A number is divisible by 5 if the last digit is divisible by 5
		/// </summary>
		public bool IsDivisibleByFive {
			get {
				int rightMostDigit = this.GetLastDigit(this.number);

				return this.isDivisible(dividend: rightMostDigit, divisor: 5);
			}
		}

		/// <summary>
		/// Accessor to determine if the number is divisible by six (6).
		/// A number is divisible by 6 if it is divisible by 2 and by 3
		/// </summary>
		public bool IsDivisibleBySix {
			get {
				return this.isDivisible(dividend: this.number, divisor: 2) && 
						this.isDivisible(dividend: this.number, divisor: 3);
			}
		}

		/// <summary>
		/// Accessor to determine if the number is divisible by seven (7).
		/// A number is divisible by 7 if it is divisible by 7 if the following condition is true:
		/// Represent the number as 10A + B.
		/// If (A - 2B) is divisible by 7, then 10A + B is also divisible by 7
		/// </summary>
		public bool IsDivisibleBySeven {
			get {
				int absOfNumber = Math.Abs(number);
				// One-digit dividend
				if (absOfNumber < 10) {
					return (absOfNumber == 0 || absOfNumber == 7);
				}

				// Two-or-more digit dividend
				// B: Right most digit
				int rightMostDigit = this.GetLastDigit(this.number);

				// A: Remainder
				int remainder = this.number / 10;

				// dividend: A - 2B
				return this.isDivisible(dividend: remainder - (rightMostDigit >> 1), divisor: 7);
			}
		}

		/// <summary>
		/// Accessor to determine if the number is divisible by eight (8).
		/// A number is divisible by 8 if the last three digits formed a number which is divisible by 8
		/// </summary>
		public bool IsDivisibleByEight {
			get {
				// One digit dividends
				int absOfNumber = Math.Abs(number);
				const int eight = 8;
				if (absOfNumber < 10) {
					return (absOfNumber == 0 || absOfNumber == 8);
				}

				// Two-digit numbers divisible by 8:
				// 0, 8, 16, 24, 32, 40, 48, 56, 64, 72, 80, 88, 96
				if (absOfNumber < 100) {
					// Use the general rule
					return this.isDivisible(dividend: this.number, divisor: eight);
				}

				// Numbers with more than two-digits
				int rightMostDigit = this.GetLastDigit(number: absOfNumber);
				int tenthDigit = this.GetLastDigit(absOfNumber / 10);
				int hundredthDigit = this.GetLastDigit(absOfNumber / 100);

				return this.isDivisible(dividend: (hundredthDigit * 100 + tenthDigit * 10 + rightMostDigit), divisor: eight);
			}
		}

		/// <summary>
		/// Accessor to determine if the number is divisible by nine (9).
		/// A number is divisible by 9 if the sum of all digits is divisible by 9
		/// </summary>
		public bool IsDivisibleByNine {
			get {
				int absOfNumber = Math.Abs(number);
				const int divisor = 9;

				int sum = this.GetLastDigit(number: absOfNumber);
				int quotient = this.number / divisor;
				while (quotient > 9) {
					sum += this.GetLastDigit(number: quotient);
					quotient /= divisor;
				}
				
				if (this.number > 10) {
					sum += quotient;
				}

				return this.isDivisible(dividend: sum, divisor: divisor);
			}
		}

		/// <summary>
		/// Accessor to determine if the number is divisible by eleven (11).
		/// A number is divisible by 11 if the difference between the sum of all even-position digits and all the odd-position digits is divisible by 11
		/// </summary>
		public bool IsDivisibleByEleven {
			get {
				int absOfNumber = Math.Abs(number);
				const int divisor = 11;

				int sumOfEvenPositionDigits = this.GetLastDigit(number: absOfNumber);
				int sumOfOddPositionDigits = 0;
				int quotient = this.number / 10;
				bool isEvenPosition = true;
				while (quotient > 9) {
					if (isEvenPosition) { // even positions
						sumOfEvenPositionDigits += this.GetLastDigit(number: quotient);
						isEvenPosition = false;
					} else {
						sumOfOddPositionDigits += this.GetLastDigit(number: quotient);
						isEvenPosition = true;
					}
					quotient /= 10;
				}

				if (this.number > 10) {
					if (isEvenPosition) { // even positions
						sumOfEvenPositionDigits += quotient;
					} else {
						sumOfOddPositionDigits += quotient;
					}
				}

				return this.isDivisible(dividend: sumOfEvenPositionDigits - sumOfOddPositionDigits, divisor: divisor);
			}
		}

		#region private accessors, helper methods
		/// <summary>
		/// Accessor to obtain the last digit of the number (this.number)
		/// </summary>
		/// <returns>The last digit</returns>
		private int LastDigit {
			get {
				return this.GetLastDigit(this.number);
			}
		}

		/// <summary>
		/// Obtain the last digit of the given number
		/// <<param name="number">the given number</param>
		private int GetLastDigit(int number) {
				const int divisor = 10;
				return this.number - (this.number / divisor) * divisor;
		}
		#endregion private helper methods
	}
}
