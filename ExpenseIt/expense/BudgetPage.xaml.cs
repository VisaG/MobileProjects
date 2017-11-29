using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace expense
{

	public partial class BudgetPage : ContentPage
	{
		App app = Application.Current as App;
		List<ExpenseList> xlist = ExpenseItemUtil.getExpenseDetail();

		int day, month, year;
		String expTitle = null;


		public BudgetPage()
		{
			InitializeComponent();

			date.MaximumDate = DateTime.Now;

			string s = ExpenseItemUtil.convertEListToString(xlist);
			app.StreList = s;
			displayExpenseList(xlist);

		}

		void OnDateSelected(object sender, DateChangedEventArgs args)
		{
			day = date.Date.Day;
			month = date.Date.Month;
			year = date.Date.Year;



		}

		void OnStoreSelected(object sender, EventArgs e)
		{
			expTitle = store.Items[store.SelectedIndex];


		}

		void displayExpenseList(List<ExpenseList> eList)
		{
			displayStack.Children.Clear();

			for (int i = 0; i < 10; i++)
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

			}
		}

		void OnAddAmtClicked(object sender, EventArgs e)
		{

			double temp = Convert.ToDouble(amount.Text);

			if(temp > 0){
				if (day != 0 && month != 0 && year != 0 && expTitle != null)
				{
					ExpenseList addNewExp = new ExpenseList();

					addNewExp.day = day;
					addNewExp.month = month;
					addNewExp.year = year;
					addNewExp.expenseDesc = expTitle;
					addNewExp.amount = Convert.ToDouble(amount.Text);

					ExpenseItemUtil.addExpenseItem(xlist, addNewExp);
					displayExpenseList(xlist);

					string s = ExpenseItemUtil.convertEListToString(xlist);
					app.StreList = s;

				}
			}

			amount.Text = "0";

		}

		void OnAddClicked(object sender, EventArgs e)
		{
			String addNewItem = desc.Text;
			bool match = false;
			if (addNewItem != null)
			{
				for (int i = 0; i < store.Items.Count; i++)
				{
					if (addNewItem.Equals(store.Items[i], StringComparison.OrdinalIgnoreCase))
					{
						match = true;
					}
				}
				if (!match)
				{
					store.Items.Add(addNewItem);
					desc.Text = "";
				}
				else
				{
					DisplayAlert("", "Item already exists...", "OK");
					desc.Text = "";
				}
			}
			else
			{
				DisplayAlert("Invalid", "Please enter valid description", "OK");
				desc.Text = "";
			}
		}

	}
}
