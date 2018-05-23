using System;
using System.Linq;
using System.Collections.Generic;

namespace EntranceExamination
{
	public static class StatisticHelper
	{
		private const int MATH_WEIGHT = 40;
		private const int PHYSICS_WEIGHT = 35;
		private const int ENGLISH_WEIGHT = 25;

		/// <summary>
		/// Mode calculation, https://en.wikipedia.org/wiki/Mode_(statistics)
		/// </summary>
		/// <param name="items"></param>
		/// <returns></returns>
		public static int Mode(List<int> items)
		{
			int mode = items.GroupBy(i => i)  //Grouping same items
			.OrderByDescending(g => g.Count()) //now getting frequency of a value
			.Select(g => g.Key) //selecting key of the group
			.FirstOrDefault();   //Finally, taking the most frequent value

			return mode;
		}

		/// <summary>
		/// Median calculation, https://en.wikipedia.org/wiki/Median
		/// </summary>
		/// <param name="items"></param>
		/// <returns></returns>
		public static int Median(List<int> items)
		{
			items.Sort();

			return items[items.Count / 2];
		}

		/// <summary>
		/// Average calculation
		/// </summary>
		/// <param name="items"></param>
		/// <returns></returns>
		public static int SimpleAverage(List<int> items) => (int)Math.Round(items.Average(), 0);

		/// <summary>
		/// Calculates weighted average, formula - (W1*X1 + W2*X2 +....+ Wn*Xn) / (W1 + W2 + ... + Wn) || https://en.wikipedia.org/wiki/Weighted_arithmetic_mean
		/// </summary>
		/// <param name="math"></param>
		/// <param name="english"></param>
		/// <param name="physics"></param>
		/// <returns></returns>
		public static float CalculateWeightedAverage(float math, float english, float physics) => (math * MATH_WEIGHT + english * ENGLISH_WEIGHT + physics * PHYSICS_WEIGHT) / (MATH_WEIGHT + PHYSICS_WEIGHT + ENGLISH_WEIGHT);
	}
}
