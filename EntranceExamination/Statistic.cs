
namespace EntranceExamination
{
	/// <summary>
	/// Holds statistic data 
	/// </summary>
	public class Statistic
	{
		public int Mode;
		public int Median;
		public int Average;

		/// <summary>
		/// Statistic constructor
		/// </summary>
		/// <param name="mode"></param>
		/// <param name="median"></param>
		/// <param name="average"></param>
		public Statistic(int mode, int median, int average)
		{
			this.Mode    = mode;
			this.Median  = median;
			this.Average = average;
		}

	}
}
