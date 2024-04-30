using System.Collections.ObjectModel;

namespace AVENTURINECOIN_MAUIEDITION;

public partial class Model_3_Page : ContentPage
{
    public ObservableCollection<Item> Items { get; set; }

    public Model_3_Page()
    {
        InitializeComponent();

        // ��ʼ�� ObservableCollection
        Items = new ObservableCollection<Item>
            {
                new Item { Name = "Item 1" },
                new Item { Name = "Item 2" },
                new Item { Name = "Item 3" },
                new Item { Name = "Item 4" },
                new Item { Name = "Item 5" }
            };

        // ����һ�� ListView ���󶨵� ObservableCollection
        LV_NameList.ItemsSource = Items;

        // ���� ListView �� ItemTemplate

        // �� ListView ��ӵ�ҳ����
    }
    // �Զ�����
    public class Item
    {
        public string Name { get; set; }
    }
}