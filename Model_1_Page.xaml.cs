using AMClassLibrary;
using System.Threading;

namespace AVENTURINECOIN_MAUIEDITION;

public partial class Model_1_Page : ContentPage
{
    NameList nameListClass = new NameList(StaticOtherLogic.nameList);
    LotteryTimer lotteryTimer = null;
    Timer timer;

    public Model_1_Page()
    {
        InitializeComponent();
        lotteryTimer = new LotteryTimer(nameListClass);
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
}