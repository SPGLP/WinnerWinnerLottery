using AMClassLibrary;
using CommunityToolkit.Maui.Alerts;
using System.Collections.ObjectModel;

namespace AVENTURINECOIN_MAUIEDITION;

public partial class Model_4_Page : ContentPage
{
    public ObservableCollection<LogItem> LogItems { get; set; }

    public Model_4_Page()
    {
        InitializeComponent();
        LogItems = new ObservableCollection<LogItem>();
        ReadLogLogic();
        LV_LogList.ItemsSource = LogItems;

    }

    private void ReadLogLogic()
    {
        StreamReader sr = null;
        try
        {
            sr = new StreamReader(FileSystem.Current.AppDataDirectory + "/LotteryLog.txt"); 
            while (!sr.EndOfStream)
            {
                string temp = sr.ReadLine();
                string[] tempSplit = temp.Split(',');
                LogItems.Add(new LogItem() { LotteryDate = tempSplit[0], BingoName = tempSplit[1], AllName = tempSplit[2] });
            }
            // sr.Close();
        }
        catch (Exception)
        {
            Toast.Make("读取失败，可能是由于记录为空", CommunityToolkit.Maui.Core.ToastDuration.Short).Show();
        }
        finally
        {
                sr?.Close();
        }
    }

    //private void BUT_Reflush_Clicked(object sender, EventArgs e)
    //{
    //    LogItems.Clear();
    //    ReadLogLogic();
    //}

    private void LV_LogList_Refreshing(object sender, EventArgs e)
    {
        LogItems.Clear();
        ReadLogLogic();
        LV_LogList.IsRefreshing = false;
    }

    private async void BUT_Clear_Clicked(object sender, EventArgs e)
    {
        bool acceptToDel = await DisplayAlert("删除所有记录？", "您确定要删除所有抽取记录吗？", "确定", "取消");
        if (acceptToDel)
        {
            File.Delete(FileSystem.Current.AppDataDirectory + "/LotteryLog.txt");
            //using(var sw = new StreamWriter(FileSystem.Current.AppDataDirectory + "/LotteryLog.txt", false))
            //{
            //    sw.Write("");
            //    sw.Close();
            //}
            LogItems.Clear();
            await Toast.Make("已删除所有记录", CommunityToolkit.Maui.Core.ToastDuration.Short).Show();
        }
    } 

    public class LogItem
    {
        public string LotteryDate { get; set; }
        public string BingoName { get; set; }
        public string AllName { get; set; }
    }

}