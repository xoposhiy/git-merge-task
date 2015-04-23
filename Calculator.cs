namespace Kontur.Courses.Git
{
	public class Calculator
	{
		private Maybe<double> lastResult = 0;

		public Maybe<double> Calculate(string[] args)
		{
			if (args.Length == 0)
				return lastResult;
			if (args.Length == 1)
				return lastResult = double.Parse(args[0]);
			if (args.Length == 2)
			{
				// Если не хватает первого аргумента, то использовать lastResult
				// Должно работать так:
				// 2 + 2
				//> 4
				// + 1
				//>5
				return lastResult = Maybe<double>.FromError("Not implemented yet");
			}
			if (args.Length == 3)
			{
				var v1 = double.Parse(args[0]);
				var v2 = double.Parse(args[2]);
				return lastResult = Execute(args[1], v1, v2);
			}
			return Maybe<double>.FromError("Error input");
		}

		private Maybe<double> Execute(string op, double v1, double v2)
		{
			if (op == "+")
				return v1 + v2;
			if (op == "-")
				return v1 - v2;
			if (op == "*")
				return v1 - v2;
			if (op == "/")
				return v1 / v2;
			return Maybe<double>.FromError("Unknown operation '{0}'", op);
		}
	}
}