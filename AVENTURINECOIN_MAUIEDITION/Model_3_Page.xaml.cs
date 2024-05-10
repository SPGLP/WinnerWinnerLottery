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
        // ��ʼ�� ObservableCollection
        Items = new ObservableCollection<Item>();
        foreach (string name in nameListEditArrayList)
        {
            Item item = new Item() { Name = name };
            Items.Add(item);
        }
        // ����һ�� ListView ���󶨵� ObservableCollection
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
                DisplayAlert("���ʧ��", "�Ѿ��������������ͬ����Ŀ", "�õ�");
            }
        }
        else
        {
            DisplayAlert("���ʧ��", "��ʽ����\n��ȷ�����Ʋ�Ϊ���Ҳ���������(,)", "�õ�");
        }
    }

    private void BUT_Edit_Clicked(object sender, EventArgs e)
    {
        if (editFocusItem == null)
        {
            DisplayAlert("�༭ʧ��", "δѡ���༭����", "�õ�");
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
            DisplayAlert("�޸�ʧ��", "��ʽ����\n��ȷ�����Ʋ�Ϊ���Ҳ���������(,)", "�õ�");
        }

    }

    private void BUT_Remove_Clicked(object sender, EventArgs e)
    {
        if (editFocusItem == null)
        {
            DisplayAlert("�Ƴ�ʧ��", "δѡ���Ƴ�����", "�õ�");
            return;
        }
        if (Items.Count > 2)
        {
            Items.Remove(editFocusItem);
            editFocusItem = null;
        }
        else
        {
            DisplayAlert("�Ƴ�ʧ��", "��������С�������� 2 ����Ŀ", "�õ�");
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
        var toast = Toast.Make("����������ϣ����ڿ�ʼ�ĳ�ǩ��ʹ������������Ϊ�˷�ֹ���벻���Ĵ��󣬽�������������",ToastDuration.Short);
        toast.Show();
    }

    // �Զ��� Item �࣬�������Ҫ�󶨵�����
    public class Item
    {
        public string Name { get; set; }
    }

}