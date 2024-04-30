using System.Collections.ObjectModel;

namespace AVENTURINECOIN_MAUIEDITION;

public partial class Model_3_Page : ContentPage
{
    public ObservableCollection<Item> Items { get; set; }

    public Model_3_Page()
    {
        InitializeComponent();

        // 初始化 ObservableCollection
        Items = new ObservableCollection<Item>
            {
                new Item { Name = "Item 1" },
                new Item { Name = "Item 2" },
                new Item { Name = "Item 3" },
                new Item { Name = "Item 4" },
                new Item { Name = "Item 5" }
            };

        // 创建一个 ListView 并绑定到 ObservableCollection
        LV_NameList.ItemsSource = Items;

        // 设置 ListView 的 ItemTemplate

        // 将 ListView 添加到页面中
    }
    // 自定义类
    public class Item
    {
        public string Name { get; set; }
    }
}