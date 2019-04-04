using System;
using System.Collections.Generic;
using System.Linq;

namespace dgCompiler
{
	public class CodeLine
	{
		public string Line;
		public List<CodeLine> ChildLines = new List<CodeLine>();
		public int fileLineNumber;

		public CodeLine(string line, int lineNumber)
		{
			Line = line;
			fileLineNumber = lineNumber;
		}

		public override string ToString()
		{
			return $"{fileLineNumber}:{Line}";
		}
	}
}
