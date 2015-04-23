using System;
using System.Collections.Generic;
using System.Linq;

namespace Kontur.Courses.Git
{
	class Program
	{
		private static void Main()
		{
			Calculator calculator = new Calculator();
			RunLoop(calculator);
		}

		private static void RunLoop(Calculator calculator)
		{
			while (true)
			{
				Console.ForegroundColor = ConsoleColor.Gray;
				var line = Console.ReadLine();
				if (line == null) break;
				var args = SplitInput(line);
				var result = calculator.Calculate(args);
				Console.ForegroundColor = result.HasValue ? ConsoleColor.Green : ConsoleColor.Red;
				Console.WriteLine("> " + result);
			}
		}

		private static string[] SplitInput(string line)
		{
			if (line.Length == 0) return new string[0];
			List<string> res = new List<string> {""};
			int charClass = GetCharClass(line[0]);
			foreach (var ch in line)
			{
				if (GetCharClass(ch) != charClass)
				{
					if (res.Last() != "") res.Add("");
					charClass = GetCharClass(ch);
				}
				if (!char.IsWhiteSpace(ch))
					res[res.Count - 1] += ch;
			}
			return res.Select(item => item.Trim()).ToArray();
		}

		private static int GetCharClass(char c)
		{
			return char.IsDigit(c) ? 0 : char.IsLetter(c) ? 1 : 2;
		}
	}
}
