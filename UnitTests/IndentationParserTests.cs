using System;
using System.Collections.Generic;
using dgCompiler;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
	[TestClass]
	public class IndentationParserTests
	{
		[TestMethod]
		public void GetIndentationLevelTest()
		{
			foreach (var testCase in m_testCases)
			{
				Assert.AreEqual(IndentationParser.GetIndentationLevel(testCase.Item1),testCase.Item2);
			}
		}


		readonly List<Tuple<string, int>> m_testCases = new List<Tuple<string, int>>
		{
			new Tuple<string, int>("", 0),
			new Tuple<string, int>("test", 0),
			new Tuple<string, int>("	test", 1),
			new Tuple<string, int>("		test", 2),
		};


	}
}
