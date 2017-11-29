﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using Xamarin.Forms;

namespace expense
{
	public class ExpenseItemUtil
	{

		/*public static List<ExpenseList> getExpenseDetail2()
		{

			List<ExpenseList> eList = new List<ExpenseList>();
			ExpenseList elist1 = new ExpenseList();

			elist1.day = 12;
			elist1.month = 2;
			elist1.year = 2017;
			elist1.expenseDesc = "Target";
			elist1.amount = 100.99;
			addExpenseItem(eList, elist1);

			ExpenseList elist2 = new ExpenseList();
			elist2.day = 24;
			elist2.month = 5;
			elist2.year = 2017;
			elist2.expenseDesc = "Rent";
			elist2.amount = 1200;
			addExpenseItem(eList, elist2);

			ExpenseList elist3 = new ExpenseList();
			elist3.day = 21;
			elist3.month = 4;
			elist3.year = 2016;
			elist3.expenseDesc = "OldNavy";
			elist3.amount = 120;
			addExpenseItem(eList, elist3);

			ExpenseList elist4 = new ExpenseList();
			elist4.day = 21;
			elist4.month = 1;
			elist4.year = 2017;
			elist4.expenseDesc = "OldNavy";
			elist4.amount = 100;
			addExpenseItem(eList, elist4);

			return eList;
		}*/

		public static List<ExpenseList> getExpenseDetail()
		{
			List<ExpenseList> eList = new List<ExpenseList>();

			var assembly = typeof(ExpenseList).GetTypeInfo().Assembly;
			Stream stream = assembly.GetManifestResourceStream("expense.expenseFile.csv");
			using (var reader = new System.IO.StreamReader(stream))
			{
				while (!reader.EndOfStream)
				{
					var line = reader.ReadLine();
					var values = line.Split(',');

					ExpenseList el = new ExpenseList();
					el.month = Int32.Parse(values[0]);
					el.day = Int32.Parse(values[1]);
					el.year = Int32.Parse(values[2]);
					el.expenseDesc = values[3];
					el.amount = Double.Parse(values[4]);

					addExpenseItem(eList, el);
				}
			}
			return eList;

		}

		public static bool addExpenseItem(List<ExpenseList> eList, ExpenseList el)
		{
			bool added = false;
			long ymd = 10000;

			ymd = ymd * el.year;
			ymd = ymd + (el.month * 100);
			ymd = ymd + el.day;
			el.ymd = ymd;

			if (eList != null)
			{
				for (int i = 0; i < eList.Count; i++)
				{
					if (ymd >= eList[i].ymd)
					{
						eList.Insert(i, el);
						added = true;
						break;
					}

				}
				if (!added)
				{
					eList.Insert(eList.Count, el);
				}

			}
			return true;
		}

		public static string convertEListToString(List<ExpenseList> eList)
		{
			StringBuilder builder = new StringBuilder();

			if (eList != null)
			{
				for (int i = 0; i < eList.Count; i++)
				{

					builder.Append(Convert.ToString(eList[i].month));
					builder.Append(",");
					builder.Append(Convert.ToString(eList[i].day));
					builder.Append(",");
					builder.Append(Convert.ToString(eList[i].year));
					builder.Append(",");
					builder.Append(Convert.ToString(eList[i].expenseDesc));
					builder.Append(",");
					builder.Append(Convert.ToString(eList[i].amount));
					builder.Append(",");
					builder.Append(Convert.ToString(eList[i].ymd));
					builder.Append("\n");
				}
				builder.Remove(builder.Length - 1, 1);
			}
			return builder.ToString();
		}

		public static List<ExpenseList> convertStringToEList(String s)
		{
			List < ExpenseList > eList = new List<ExpenseList>();
			string[] words = s.Split('\n');
			foreach (string s1 in words)
			{
				var values = s1.Split(',');
				ExpenseList el = new ExpenseList();
				el.month = Int32.Parse(values[0]);
				el.day = Int32.Parse(values[1]);
				el.year = Int32.Parse(values[2]);
				el.expenseDesc = values[3];
				el.amount = Double.Parse(values[4]);
				addExpenseItem(eList, el);
			}
			return eList;
		}
	}
}