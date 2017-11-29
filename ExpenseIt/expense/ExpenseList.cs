using System;

namespace expense
{
	public class ExpenseList
	{
		public int day { get; set; }
		public int month { get; set; }
		public int year { get; set; }
		public String expenseDesc { get; set; }
		public double amount { get; set; }
		public long ymd { get; set; }

		public ExpenseList()
		{
		}
	}
}
