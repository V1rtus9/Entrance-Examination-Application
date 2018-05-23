
namespace EntranceExamination
{
	/// <summary>
	/// Holds every student data
	/// </summary>
	public struct Student
	{
		public string Name;
		public int Math;
		public int Physics;
		public int English;
		public float Average;

		/// <summary>
		/// Student struct constructor
		/// </summary>
		/// <param name="name"></param>
		/// <param name="math"></param>
		/// <param name="physics"></param>
		/// <param name="english"></param>
		/// <param name="avg"></param>
		public Student(string name, int math, int physics, int english, float avg)
		{
			this.Name  = name;
			this.Math  = math;
			this.Physics = physics;
			this.English = english;
			this.Average = avg;
		}
	}
}
