using System;
using Newtonsoft.Json;
using System.Collections.Generic;


namespace EntranceExamination
{
	/// <summary>
	/// Holds groups with students data and every group statistics
	/// </summary>
	public class Group
	{

		[JsonProperty]
		private List<Student> Students;
		[JsonProperty]
		private Dictionary<string, Statistic> Statistics;

		/// <summary>
		/// Group constructor
		/// </summary>
		public Group()
		{
			this.Students  = new List<Student>();
			this.Statistics = new Dictionary<string, Statistic>();
		}
		/// <summary>
		/// Insert new student data to the students list
		/// </summary>
		/// <param name="student"></param>
		public void InsertStudent(Student student) => Students.Add(student);

		/// <summary>
		/// 
		/// </summary>
		/// <param name="i"></param>
		/// <returns></returns>
		public Student GetStudent(int i) => Students[i];
		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public int GetStudentsCount => Students.Count;

		/// <summary>
		/// Calculate current group statistics
		/// </summary>
		public void CalculateGroupStatistics()
		{
			List<int> mathData    = new List<int>();
			List<int> physicsData = new List<int>();
			List<int> englishData = new List<int>();

			foreach (Student item in Students)
			{
				mathData.Add(item.Math);
				physicsData.Add(item.Physics);
				englishData.Add(item.English);
			}

			Statistics.Add("Math", new Statistic(StatisticHelper.Mode(mathData), StatisticHelper.Median(mathData), StatisticHelper.SimpleAverage(mathData)));
			Statistics.Add("Physics", new Statistic(StatisticHelper.Mode(physicsData), StatisticHelper.Median(physicsData), StatisticHelper.SimpleAverage(physicsData)));
			Statistics.Add("English", new Statistic(StatisticHelper.Mode(englishData), StatisticHelper.Median(englishData), StatisticHelper.SimpleAverage(englishData)));
		}


	}
}
