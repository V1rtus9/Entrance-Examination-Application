using System;
using System.Collections.Generic;

namespace EntranceExamination
{
	public class Data
	{
		public Dictionary<string, Group> Groups = new Dictionary<string, Group>();
		public Dictionary<string, Statistic> Statistics = new Dictionary<string, Statistic>();

		/// <summary>
		/// Insert single group object to groups dictionary
		/// </summary>
		/// <param name="key"></param>
		/// <param name="group"></param>
		public void InsertGroup(string key, Group group)
		{
			Groups.Add(key, group);
		}
		/// <summary>
		/// Insert student object to group that aready exists
		/// </summary>
		/// <param name="key"></param>
		/// <param name="student"></param>
		public void InserStudentToGroup(string key, Student student)
		{
			try
			{
				Groups[key].InsertStudent(student);
			}
			catch (KeyNotFoundException e)
			{
				Console.WriteLine("Group with current key does not exist. Exception: " + e);
			}
		}
		/// <summary>
		/// Get single group object by key from groups dictionary
		/// </summary>
		/// <param name="key"></param>
		/// <returns></returns>
		public Group GetGroup(string key)
		{
			try
			{
				return Groups[key];
			}
			catch (KeyNotFoundException e)
			{

				Console.WriteLine("Group with current key does not exist. Exception: " + e);
			}

			return null;
		}
		/// <summary>
		/// Calculate statistics for each group separately
		/// </summary>
		public void CalculateGroupStatistics()
		{
			foreach (Group item in Groups.Values)
			{
				item.CalculateGroupStatistics();
			}
		}
		/// <summary>
		///  Calculate statistics for all data, using StatisticHelper class for mode,median and average calculations
		/// </summary>
		public void CalculateDataStatistics()
		{
			List<int> mData = new List<int>();
			List<int> pData = new List<int>();
			List<int> eData = new List<int>();

			foreach (Group item in Groups.Values)
			{
				foreach (Student student in item.Students)
				{
					mData.Add(student.Math);
					pData.Add(student.Physics);
					eData.Add(student.English);
				}
			}


			Statistics.Add("Math", new Statistic(StatisticHelper.Mode(mData), StatisticHelper.Median(mData), StatisticHelper.SimpleAverage(mData)));
			Statistics.Add("Physics", new Statistic(StatisticHelper.Mode(pData), StatisticHelper.Median(pData), StatisticHelper.SimpleAverage(pData)));
			Statistics.Add("English", new Statistic(StatisticHelper.Mode(eData), StatisticHelper.Median(eData), StatisticHelper.SimpleAverage(eData)));

		}
	}
}
