using SFTester.Models;
using SFTester.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace SFTester.ViewModels
{
    public class ListViewModel : BaseViewModel
    {

		private string navbar;
		public string Navbar	
		{
			get { return navbar; }
			set
			{
				if (value != navbar)
				{
					SetProperty(ref navbar, value);
				}
			}
		}

		private IList<Item> items;
		public IList<Item> Items
		{
			get { return items; }
			set
			{
				if (value != items)
				{
					SetProperty(ref items, value);
				}
			}
		}

		private Item selectedItem;
		public Item SelectedItem
		{
			get { return selectedItem; }
			set
			{
				if (value != selectedItem)
				{
					SetProperty(ref selectedItem, value);
				}
			}
		}

		private IList<string> pages;
		public IList<string> Pages
		{
			get { return pages; }
			set
			{
				if (value != pages)
				{
					SetProperty(ref pages, value);
				}
			}
		}

		private string selectedPage;
		public string SelectedPage	
		{
			get { return selectedPage; }
			set
			{
				if (value != selectedPage)
				{
					SetProperty(ref selectedPage, value);
					if(SelectedPage != null)
					{
						OnLoad(SelectedPage);
					}
				}
			}
		}

		public ListViewModel()
		{
			Title = "List Page";
			Pages = new ObservableCollection<string>
			{
				"Page 1",
				"Page 2",
			};
			SelectedPage = Pages.FirstOrDefault();
		}

		internal async void OnLoad(string page)
		{
			if (page == "Page 1")
			{
				var list = await DataStore.GetItemsAsync();
				Items = new ObservableCollection<Item>(list.Take(3));
				SelectedItem = Items.FirstOrDefault();
			}
			else
			{
				var list = await DataStore.GetItemsAsync();
				Items = new ObservableCollection<Item>(list.Skip(3).Take(3));
				SelectedItem = Items.FirstOrDefault();
			}
		}
	}
}
