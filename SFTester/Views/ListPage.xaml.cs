using SFTester.Models;
using SFTester.ViewModels;
using Syncfusion.ListView.XForms;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SFTester.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListPage : ContentPage
    {
        public ListPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
        }

        private void SfListView_SelectionChanged(object sender, Syncfusion.ListView.XForms.ItemSelectionChangedEventArgs e)
        {
            var list = sender as SfListView;
            var question = list.BindingContext as Item;
            if (question.Replys == null)
            {
                question.Replys = new ObservableCollection<string>();
            }
            foreach (var item in e.AddedItems)
            {
                if (item is string Reply)
                {
                    if (question.Replys.FirstOrDefault(x => x.Equals(item)) == null)
                    {
                        question.Replys.Add(Reply);
                    }
                }
            }
            foreach (var item in e.RemovedItems)
            {
                if (item is string Reply)
                {
                    question.Replys.Remove(Reply);
                }
            }
        }

        private void SfListView_Loaded(object sender, Syncfusion.ListView.XForms.ListViewLoadedEventArgs e)
        {
            var list = sender as SfListView;
            var context = list.BindingContext as Item;
            if (context != null)
            {
                foreach (var item in context.Replys)
                {
                    list.SelectedItems.Add(item);
                }
            }
        }
    }
}