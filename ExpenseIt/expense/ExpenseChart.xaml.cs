using System;
using System.Collections.Generic;
using Xamarin.Forms;
using OxyPlot;
using OxyPlot.Series;
using OxyPlot.Axes;

namespace expense
{
	public partial class ExpenseChart : ContentPage
	{
		int yearSelected;
		int monthSelected;
		App app = Application.Current as App;
		List<ExpenseList> xlist;




		public ExpenseChart()
		{
			InitializeComponent();
			month.IsVisible = false;
		}

		void OnYearSelected(object sender, EventArgs e)
		{

			int t = Int32.Parse(year.Items[year.SelectedIndex]);

			if (t < 2015)
			{
				DisplayAlert("", "No data found...", "OK");
			}
			else
			{
				yearSelected = Int32.Parse(year.Items[year.SelectedIndex]);
				month.IsVisible = true;
			}

		}
		void OnMonthSelected(object sender, EventArgs e)
		{
			monthSelected = month.SelectedIndex + 1;
			displayStack.Children.Clear();
			if (app.StreList == null)
			{
				xlist = ExpenseItemUtil.getExpenseDetail();
				app.StreList = ExpenseItemUtil.convertEListToString(xlist);
			}
			else
			{
				xlist = ExpenseItemUtil.convertStringToEList(app.StreList);
			}
			displayExpenseList(xlist, monthSelected, yearSelected);

		}

		void displayExpenseList(List<ExpenseList> eList, int monthSelected, int yearSelected)
		{

			double totalAmt = 0;

			l.Text = "Transaction Detail for " + monthSelected + "/" + yearSelected;

			for (int i = 0; i < eList.Count; i++)
			{
				if (eList[i].year < yearSelected)
				{
					break;
				}
				else
				{
					if (eList[i].year == yearSelected && eList[i].month == monthSelected)
					{
						Label d = new Label
						{
							Text = eList[i].month + "/" + eList[i].day + "/" + eList[i].year,
							VerticalOptions = LayoutOptions.CenterAndExpand,
							FontSize = Device.GetNamedSize(NamedSize.Micro, typeof(Label)),
						};

						Label description = new Label
						{
							Text = eList[i].expenseDesc,
							VerticalOptions = LayoutOptions.CenterAndExpand,
							FontSize = Device.GetNamedSize(NamedSize.Micro, typeof(Label)),
						};

						Label amount = new Label
						{
							Text = "$ " + eList[i].amount.ToString(),
							VerticalOptions = LayoutOptions.CenterAndExpand,
							FontSize = Device.GetNamedSize(NamedSize.Micro, typeof(Label)),


						};



						StackLayout stack = new StackLayout
						{
							Children = {
						d,
					}
						};

						StackLayout stack1 = new StackLayout
						{
							Orientation = StackOrientation.Horizontal,
							Children = {
						description,
							amount
					}
						};

						stack.Children.Add(stack1);

						displayStack.Children.Add(stack);
						totalAmt = totalAmt + eList[i].amount;

					}


					total.Text = "Total amount spent for " + monthSelected + "/" + yearSelected + " : $" + totalAmt;
				}

			}
		}

	}
}
