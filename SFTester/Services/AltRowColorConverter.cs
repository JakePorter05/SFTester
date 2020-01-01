using Syncfusion.ListView.XForms;
using System;
using System.Globalization;
using System.Linq;
using Xamarin.Forms;

namespace SFTester.Services
{
    public class AltRowColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Color rowcolor = Color.Transparent;
            if (value == null || parameter == null)
            {
                return Color.White;
            }

            int index = -1;
            if (parameter is ListView list)
            {
                if (list.ItemsSource != null)
                {
                    var objList = list.ItemsSource?.Cast<object>().ToList();
                    index = objList.IndexOf(value);
                }
            }
            else if (parameter is SfListView sfList)
            {
                if (sfList.ItemsSource != null)
                {
                    index = sfList.DataSource.DisplayItems.IndexOf(value);
                }
            }

            if (index % 2 == 0)
            {
                rowcolor = Color.LightGray;
            }
            return rowcolor;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
