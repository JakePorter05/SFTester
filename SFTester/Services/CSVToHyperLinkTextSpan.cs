using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace SFTester.Services
{
    public class CSVToHyperLinkTextSpan : IValueConverter
    {
        public int type = 0;
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
            {
                return null;
            }

            if (parameter != null)
            {
                type = int.Parse(parameter.ToString());
            }

            var formatted = new FormattedString();
            foreach (var item in value.ToString().Split(','))
            {
                formatted.Spans.Add(CreateSpan(item));

                //Add the bar to separate the items
                formatted.Spans.Add(new Span
                {
                    Text = " | ",
                });
            }
            return formatted;
        }

        private Span CreateSpan(string section)
        {
            var pair = section.Split('~');
            var span = new Span()
            {
                Text = pair[0],
            };

            if (!string.IsNullOrEmpty(section))
            {
                var gesture = new TapGestureRecognizer()
                {
                    CommandParameter = section,
                };
                if (type == 1)
                {
                    gesture.Command = new Command<string>((url) =>
                    {
                        MessagingCenter.Send(url, "LinkNavFolderEvent");
                    });
                }
                else if (type == 2)
                {
                    gesture.Command = new Command<string>((url) =>
                    {
                        MessagingCenter.Send(url, "LinkNavDownloadEvent");
                    });
                }
                else if (type == 3)
                {
                    gesture.Command = new Command<string>((url) =>
                    {
                        MessagingCenter.Send(url, "LinkNavSurveyPreviewerEvent");
                    });
                }
                else if (type == 4)
                {
                    gesture.Command = new Command<string>((url) =>
                    {
                        MessagingCenter.Send(url, "LinkNavSurveyDisplayEvent");
                    });
                }
                span.GestureRecognizers.Add(gesture);
                span.TextColor = Color.Blue;
                span.TextDecorations = TextDecorations.Underline;
            }

            return span;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }
}
