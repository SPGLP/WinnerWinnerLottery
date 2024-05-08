using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using System.Collections;
using System.Collections.ObjectModel;

namespace AVENTURINECOIN_MAUIEDITION;

public partial class Model_3_Page : ContentPage
{
    private ObservableCollection<Item> Items { get; set; }
    private ArrayList nameListEditArrayList = new ArrayList(StaticOtherLogic.nameList);
    private Item editFocusItem;

    public Model_3_Page()
    {
        InitializeComponent();
        // 初始化 ObservableCollection
        Items = new ObservableCollection<Item>();
        foreach (string name in nameListEditArrayList)
        {
            Item item = new Item() { Name = name };
            Items.Add(item);
        }
        // 创建一个 ListView 并绑定到 ObservableCollection
        LV_NameList.ItemsSource = Items;
    }

    private void LV_NameList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        if (LV_NameList.SelectedItem != null)
        {
            editFocusItem = Items.ElementAt(e.SelectedItemIndex);
            ET_Name.Text = editFocusItem.Name;
        }
    }

    private void BUT_New_Clicked(object sender, EventArgs e)
    {
        bool canAdd = true;
        if (ET_Name.Text.Length > 0 && !ET_Name.Text.Contains(','))
        {
            foreach (Item item in Items)
            {
                if (ET_Name.Text == item.Name)
                {
                    canAdd = false;
                    break;
                }
            }
            if (canAdd)
            {
                Items.Add(new Item() { Name = ET_Name.Text });
            }
            else
            {
                DisplayAlert("添加失败", "已经存在与此名称相同的项目", "好的");
            }
        }
        else
        {
            DisplayAlert("添加失败", "格式错误\n请确保名称不为空且不包含逗号(,)", "好的");
        }
    }

    private void BUT_Edit_Clicked(object sender, EventArgs e)
    {
        if (editFocusItem == null)
        {
            DisplayAlert("编辑失败", "未选定编辑对象", "好的");
            return;
        }
        if (ET_Name.Text.Length > 0 && !ET_Name.Text.Contains(','))
        {
            Items.Remove(editFocusItem);
            Items.Add(new Item() { Name = ET_Name.Text });
            editFocusItem = null;
        }
        else
        {
            DisplayAlert("修改失败", "格式错误\n请确保名称不为空且不包含逗号(,)", "好的");
        }

    }

    private void BUT_Remove_Clicked(object sender, EventArgs e)
    {
        if (editFocusItem == null)
        {
            DisplayAlert("移除失败", "未选定移除对象", "好的");
            return;
        }
        if (Items.Count > 2)
        {
            Items.Remove(editFocusItem);
            editFocusItem = null;
        }
        else
        {
            DisplayAlert("移除失败", "名单中最小不能少于 2 个项目", "好的");
        }
    }

    private void BUT_Save_Clicked(object sender, EventArgs e)
    {
        string nameListString = "";
        StaticOtherLogic.nameList.Clear();
        foreach (var item in Items) 
        {
            nameListString += item.Name + ",";
            StaticOtherLogic.nameList.AddLast(item.Name);
        }
        nameListString = nameListString.Remove(nameListString.Length - 1, 1);
        using (var sw = new StreamWriter(FileSystem.Current.AppDataDirectory + "/NameList.txt", false))
        {
            sw.WriteLine(nameListString);
            sw.Close();
        }
        var toast = Toast.Make("名单设置完毕，现在开始的抽签将使用新名单。但为了防止意想不到的错误，建议先重启程序",ToastDuration.Short);
        toast.Show();
    }

    // 自定义 Item 类，用于填充要绑定的数据
    public class Item
    {
        public string Name { get; set; }
    }

}