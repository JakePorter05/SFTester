using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using SFTester.Models;

namespace SFTester.Services
{
    public class MockDataStore : IDataStore<Item>
    {
        readonly List<Item> items;

        public MockDataStore()
        {
            items = new List<Item>()
            {
                new Item 
                { 
                    Pk = Guid.NewGuid(), 
                    Name = "R1",
                    Type = TemplateType.Radio,
                    Items = new ObservableCollection<string>
                    {
                        "Yes",
                        "No",
                    }
                },
                new Item 
                { 
                    Pk = Guid.NewGuid(), 
                    Name = "R2",
                    Type = TemplateType.Radio,
                    Items = new ObservableCollection<string>
                    {
                        "Yes",
                        "No",
                    }
                },
                new Item 
                { 
                    Pk = Guid.NewGuid(), 
                    Name = "C1",
                    Type = TemplateType.CheckBox,
                    Items = new ObservableCollection<string>
                    {
                        "P1",
                        "P2",
                        "P3",
                        "P4",
                    }
                },
                new Item 
                { 
                    Pk = Guid.NewGuid(), 
                    Name = "C2",
                    Type = TemplateType.CheckBox,
                    Items = new ObservableCollection<string>
                    {
                        "M1",
                        "M2",
                        "M3",
                        "M4",
                    }
                },
                new Item 
                { 
                    Pk = Guid.NewGuid(), 
                    Name = "R3",
                    Type = TemplateType.Radio,
                    Items = new ObservableCollection<string>
                    {
                        "Yes",
                        "No",
                    }
                },
                new Item 
                { 
                    Pk = Guid.NewGuid(), 
                    Name = "R4",
                    Type = TemplateType.Radio,
                    Items = new ObservableCollection<string>
                    {
                        "Yes",
                        "No",
                    }
                }
            };
        }

        public async Task<bool> AddItemAsync(Item item)
        {
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Item item)
        {
            var oldItem = items.Where((Item arg) => arg.Pk == item.Pk).FirstOrDefault();
            items.Remove(oldItem);
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(Guid id)
        {
            var oldItem = items.Where((Item arg) => arg.Pk == id).FirstOrDefault();
            items.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<Item> GetItemAsync(Guid id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Pk == id));
        }

        public async Task<IEnumerable<Item>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }
    }
}