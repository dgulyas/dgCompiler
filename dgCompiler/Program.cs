using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace dgCompiler
{
	class Program
	{
		static void Main(string[] args)
		{
			var fileLines = File.ReadAllLines(".\\testPrograms\\first.dg").ToList();

			var flatCodeLines = ConvertStringsToCodeLines(fileLines);
			foreach (var flatCodeLine in flatCodeLines)
			{
				flatCodeLine.Line = " " + flatCodeLine.Line;
			}

			var topCodeLine = new CodeLine("", -1);
			var stack = new Stack<CodeLine>();
			stack.Push(topCodeLine);

			CreateCodeLinesR(flatCodeLines, stack);
		}

		//the stack has all the previous parent codeLines in it, plus the last line read.
		static void CreateCodeLinesR(List<CodeLine> codeLines, Stack<CodeLine> parents)
		{
			if (codeLines.Count == 0) return;

			var nextLine = codeLines[0];
			codeLines.RemoveAt(0);

			var prevLine = parents.Pop();
			var prevLineIndentLevel = GetIndentationLevel(prevLine);

			var nextLineIndentLevel = GetIndentationLevel(nextLine);

			if (nextLineIndentLevel == prevLineIndentLevel)
			{ //this line is on the same level as the previous line
				var parent = parents.Peek();
				parent.ChildLines.Add(nextLine);
				parents.Push(nextLine);
			}
			else if (nextLineIndentLevel == prevLineIndentLevel + 1)
			{ //this line is a child of the previous line
				prevLine.ChildLines.Add(nextLine);
				parents.Push(prevLine);
				parents.Push(nextLine);
			}
			else if (nextLineIndentLevel == prevLineIndentLevel - 1)
			{ //this line is on the same level as the parent lines parent
				parents.Pop();
				var parent = parents.Peek();
				parent.ChildLines.Add(nextLine);
				parents.Push(nextLine);
			}
			else
			{
				throw new Exception($"Indentation level is wrong. {Environment.NewLine}{nextLine}");
			}
			CreateCodeLinesR(codeLines, parents);
		}

		static int GetIndentationLevel(CodeLine line)
		{
			return line.Line.TakeWhile(Char.IsWhiteSpace).Count();
		}

		static List<CodeLine> ConvertStringsToCodeLines(List<string> strings)
		{
			var codelines = new List<CodeLine>();

			for (int i = 0; i < strings.Count; i++)
			{
				codelines.Add(new CodeLine(strings[i], i+1));
			}

			//remove all blank lines
			codelines.RemoveAll(l => string.IsNullOrWhiteSpace(l.Line));

			return codelines;
		}


	}
}
