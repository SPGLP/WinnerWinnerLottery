using AMClassLibrary;
using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using System.Threading;

namespace AVENTURINECOIN_MAUIEDITION;

public partial class Model_1_Page : ContentPage
{
    NameList nameListClass;
    LotteryTimer lotteryTimer = null;
    Timer timer;

    public Model_1_Page()
    {
        InitializeComponent();
        LinkedList<String> nl = new LinkedList<string>(StaticOtherLogic.nameList);
        nameListClass = new NameList(nl);
        lotteryTimer = new LotteryTimer(ref nameListClass, LotteryFinishToast);
        //L_Name.BindingContext = lotteryTimer;
        //L_Time.BindingContext = lotteryTimer;
        //BUT_Start.BindingContext = lotteryTimer;
    }

    private void BUT_Start_Clicked(object sender, EventArgs e)
    {
        L_Name.SetBinding(Label.TextProperty, new Binding("BingoNameReturnTextBlock")
        {
            Source = lotteryTimer
        });
        L_Time.SetBinding(Label.TextProperty, new Binding("TimeSumReturnTextBlock")
        {
            Source = lotteryTimer
        });
        BUT_Start.SetBinding(Button.IsEnabledProperty, new Binding("ButtonAgain") 
        {
            Source = lotteryTimer
        });

        lotteryTimer.StartLottery();
    }

    private void LotteryFinishToast()
    {
        Toast.Make($"抽签完成，恭喜 {L_Name.Text} 成为本次幸运儿", ToastDuration.Short).Show();
    }
}