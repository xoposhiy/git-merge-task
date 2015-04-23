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
				return lastResult = TryParseDouble(args[0]);
			if (args.Length == 2)
			{
				// Если не хватает первого аргумента, то использовать lastResult
				// Должно работать так:
				// 2 + 2
				//> 4
				// + 1
				//>5
				var v1 = lastResult;
				var v2 = TryParseDouble(args[1]);
				if (!v1.HasValue || !v2.HasValue) return v1;
				return lastResult = Execute(args[0], v1.Value, v2.Value);
			}
			if (args.Length == 3)
			{
				var v1 = TryParseDouble(args[0]);
				var v2 = TryParseDouble(args[2]);
				if (!v1.HasValue || !v2.HasValue) return v1;
				return lastResult = Execute(args[1], v1.Value, v2.Value);
			}
			return Maybe<double>.FromError("Error input");
		}

		private Maybe<double> TryParseDouble(string s)
		{
			double v;
			if (double.TryParse(s, out v))
				return v;
			return Maybe<double>.FromError("Not a number '{0}'", s);
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