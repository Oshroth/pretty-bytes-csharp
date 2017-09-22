using System;

namespace Utility {
	public static class PrettyBytes {

		static readonly string[] UNITS = { "B", "kB", "MB", "GB", "TB", "PB", "EB", "ZB", "YB" };

		public static string FormatBytes(double num) {
			if (double.IsInfinity(num) || double.IsNaN(num)) {
				throw new NotFiniteNumberException(num);
			}

			var neg = num < 0;

			if (neg) {
				num = -num;
			}

			if (num < 1) {
				return (neg ? "-" : "") + num + " B";
			}

			var exponent = Math.Min((int)Math.Floor(Math.Log10(num) / 3), UNITS.Length - 1);
			var numStr = Math.Round(num / Math.Pow(1000, exponent), 3);
			var unit = UNITS[exponent];

			return (neg ? "-" : "") + numStr + " " + unit;
		}
	}
}
