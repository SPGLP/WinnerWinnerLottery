using System.Collections.ObjectModel;

namespace AVENTURINECOIN_MAUIEDITION;

public partial class Model_4_Page : ContentPage
{
    public ObservableCollection<LogItem> logItems { get; set; }

    public Model_4_Page()
    {
        InitializeComponent();
        logItems = new ObservableCollection<LogItem>()
        {
            new LogItem() {LotteryDate = DateTime.Now.ToString(), BingoName="LSL", AllName="LSL, mofeng, Boy" },
            new LogItem() {LotteryDate = DateTime.Now.ToString(), BingoName="mofeng", AllName="LSL, mofeng, Boy" }
        };
        
        LV_LogList.ItemsSource = logItems;
    }

    public class LogItem
    {
        public string LotteryDate { get; set; }
        public string BingoName { get; set; }
        public string AllName { get; set; }
    }
}