using System;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace EntranceExamination
{
	public class Data
	{
		[JsonProperty]
		private Dictionary<string, Group> Groups = new Dictionary<string, Group>();
		[JsonProperty]
		private Dictionary<string, Statistic> Statistics = new Dictionary<string, Statistic>();

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
				Console.WriteLine("\r\nGroup with current key does not exist. Exception: " + e);
				App.Exit();
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

				Console.WriteLine("\r\nGroup with current key does not exist. Exception: " + e);
				App.Exit();
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
				for (int i = 0; i < item.GetStudentsCount; i++)
				{
					mData.Add(item.GetStudent(i).Math);
					pData.Add(item.GetStudent(i).Physics);
					eData.Add(item.GetStudent(i).English);
				}
			}


			Statistics.Add("Math", new Statistic(StatisticHelper.Mode(mData), StatisticHelper.Median(mData), StatisticHelper.SimpleAverage(mData)));
			Statistics.Add("Physics", new Statistic(StatisticHelper.Mode(pData), StatisticHelper.Median(pData), StatisticHelper.SimpleAverage(pData)));
			Statistics.Add("English", new Statistic(StatisticHelper.Mode(eData), StatisticHelper.Median(eData), StatisticHelper.SimpleAverage(eData)));

		}
	}
}
