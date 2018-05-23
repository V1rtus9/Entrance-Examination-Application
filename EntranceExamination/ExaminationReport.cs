using System;
using System.IO;
using Newtonsoft.Json;
using System.Text.RegularExpressions;

namespace EntranceExamination
{
	public class ExaminationReport
	{

		private Data ExaminationData = new Data();
		private JsonSerializerSettings SerializationSettings = new JsonSerializerSettings
		{
			TypeNameHandling = TypeNameHandling.Auto,
			TypeNameAssemblyFormatHandling = TypeNameAssemblyFormatHandling.Full,
			Error = delegate (object sender, Newtonsoft.Json.Serialization.ErrorEventArgs errorArgs)
			{
				Console.WriteLine("\r\nJson Serialization error happened: " + errorArgs.ErrorContext.Error.Message);
			}

		};
		private string GroupPrefix = "Group ";

		/// <summary>
		/// Method that gets data from file and process it
		/// </summary>
		/// <param name="filePath"></param>
		/// <returns></returns>
		public bool ProcessExaminationData(string filePath)
		{
			if (string.IsNullOrEmpty(filePath)){
				Console.WriteLine("\r\nThere is no path");
				return false;
			}

			if (!File.Exists(filePath))
			{
				Console.WriteLine("\r\nFile with data does not exist, please put 'examination.txt' into the Desktop folder");
				return false;
			}

			string[] lines = File.ReadAllLines(filePath);

			if (lines.Length == 0)
				return false;

			int GroupCount = 0;

			foreach (string item in lines)
			{
				string[] line = item.Split(';');

				if(line.Length == 1)
				{
					if (line[0].ToLower().Contains("group"))
					{

						GroupCount++;
						ExaminationData.InsertGroup(GroupPrefix + GroupCount, new Group());
					}

					continue;
				}

				int math    = Int16.Parse(Regex.Match(line[1], @"\d+").Value);
				int physics = Int16.Parse(Regex.Match(line[2], @"\d+").Value);
				int english = Int16.Parse(Regex.Match(line[3], @"\d+").Value);

				ExaminationData.InserStudentToGroup(GroupPrefix + GroupCount, new Student(line[0], math, physics, english, StatisticHelper.CalculateWeightedAverage(math,physics,english)));
			}

			CalculateGroupSubjectsStatistics();
			CalculateWholeDataStatistics();

			return true;
		}
		/// <summary>
		/// Count simple average, median and modus separetely for each group
		/// </summary>
		private void CalculateGroupSubjectsStatistics()
		{
			ExaminationData.CalculateGroupStatistics();
		}
		/// <summary>
		/// Counts simple average, median and modus for all data records
		/// </summary>
		private void CalculateWholeDataStatistics()
		{
			ExaminationData.CalculateDataStatistics();
		}
		/// <summary>
		/// Saves data to file in json format || https://www.newtonsoft.com/json
		/// </summary>
		/// <param name="path"></param>
		public void SaveReportToFileFormatJson (string path)
		{
			try
			{
				File.WriteAllText(path, 
					JsonConvert.SerializeObject(ExaminationData, Formatting.Indented, SerializationSettings));
			}
			catch (IOException e)
			{
				Console.WriteLine("\r\nSomething gone wrong, try again! Exception: " + e);
				Console.ReadLine();
				Environment.Exit(0);
			}

		}
	}
}
