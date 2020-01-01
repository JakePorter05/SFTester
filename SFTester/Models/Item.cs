using SFTester.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace SFTester.Models
{
    public class Item : NotificationBase
    {
        public Guid Pk { get; set; }
        public string Name { get; set; }
        public TemplateType Type { get; set; }

        private IList<string> items;
        public IList<string> Items
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

        private IList<string> replys;
        public IList<string> Replys
        {
            get { return replys; }
            set
            {
                if (value != replys)
                {
                    SetProperty(ref replys, value);
                }
            }
        }

        private string reply;
        public string Reply
        {
            get { return reply; }
            set
            {
                if (value != reply)
                {
                    SetProperty(ref reply, value);
                }
            }
        }

        public Item()
        {
            Replys = new ObservableCollection<string>();
        }
    }
}
