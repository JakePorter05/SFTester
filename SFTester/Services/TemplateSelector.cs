using SFTester.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace SFTester.Services
{
    class TemplateSelector : DataTemplateSelector
    {
        public DataTemplate Radio { get; set; }
        public DataTemplate CheckBox { get; set; }

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            var att = (item as Item);
            switch (att.Type)
            {
                case TemplateType.Radio:
                    {
                        return Radio;
                    }
                case TemplateType.CheckBox:
                    {
                        return CheckBox;
                    }
                default:
                    return null;
            }
        }
    }
}
