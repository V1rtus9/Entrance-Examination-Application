using System;

namespace EntranceExamination
{
	class Program
	{

		//Do not forget to impoty JSON.Net package - https://www.newtonsoft.com/json

		private static string inputFile  = "examination.txt";
		private static string outputFile = "Examination Report.txt";
		private static string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\";

		static void Main(string[] args)
		{
			Console.Write("Data Processing Application \r\n \r\n" +
				"Author: Vladimir Botnar \r\n" +
				"Email: vbotnar89@gmail.com \r\n \r\n" +
				"Attention: Put " + inputFile + " here " + desktopPath + " \r\n \r\n" +  
				"Press any key to start");
			Console.ReadLine();

			ExaminationReport Report = new ExaminationReport();

			if (Report.ProcessExaminationData(desktopPath + inputFile))
			{
				Console.Write("\r\nProcess successfully completed  \r\n \r\n" +
					"Report file location will be: " + desktopPath + outputFile + " \r\n\r\n" +
					"Press any key to save the report");
				Console.ReadLine();
				Report.SaveReportToFileFormatJson(desktopPath + outputFile);
				Console.WriteLine("\r\nDone");
				Console.WriteLine("\r\nHave a nice day! I'm looking forward to your feedback.  \r\n \r\nPress any key to exit");
				Console.ReadLine();
			}
			else
			{
				Console.WriteLine("\r\nError occurred, try again or contact with developer.");
				Console.ReadLine();
			}
	
		}
	}
}
