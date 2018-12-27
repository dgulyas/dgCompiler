using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dgCompiler
{
	public static class IndentationParser
	{
		public static List<CodeLine> Parse(List<string> fileLines)
		{
			var topLines = new List<CodeLine>();


			return topLines;
		}

		public static int GetIndentationLevel(string fileLine)
		{
			//if there's nothing on the line return -1 to skip it.
			if (string.IsNullOrWhiteSpace(fileLine)) return -1;

			var indentationLevel = 0;
			while (fileLine[indentationLevel] == '\t')
			{
				indentationLevel++;
			}

			return indentationLevel;
		}

	}
}
