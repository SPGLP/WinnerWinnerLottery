using AMClassLibrary;
using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using System.Collections;

namespace AVENTURINECOIN_MAUIEDITION;

public partial class Model_2_Page : ContentPage
{
    private ArrayList lableNameArrayList;
    private ArrayList lableNameInitArrayList;
    private LinkedList<MultiLotteryTimer> lotteryTimers;
    private LinkedListNode<MultiLotteryTimer> node;

    public Model_2_Page()
    {
        InitializeComponent();
        lableNameArrayList = new ArrayList(new Label[] { L_Name1, L_Name2, L_Name3, L_Name4, L_Name5, L_Name6, L_Name7, L_Name8 });
    }

    private void BUT_Start_Clicked(object sender, EventArgs e)
    {
        int lotteryCount;
        int nlCount = StaticOtherLogic.nameList.Count;
        if (int.TryParse(ET_Count.Text, out lotteryCount))
        {
            if (lotteryCount > 1 && lotteryCount < nlCount)
            {
                // 开始抽取
                InitLabels();
                OtherLogic.StartMultiLottery(StaticOtherLogic.nameList, lotteryCount, SetLabelsBinding, LotteryFinishToast);
                SetLabelsBinding();
                BUT_Start.SetBinding(Button.IsEnabledProperty, new Binding("MButtonAgain")
                {
                    Source = OtherLogic.Model2ButtonAgain
                });
            }
            else
            {
                DisplayAlert("数据错误", "请确保您输入的数字大于 1 且小于名单中的总人数", "好的");
            }
        }
        else
        {
            DisplayAlert("数据错误", "请确保您输入的是 Integer 型数据", "好的");
        }
    }

    private void InitLabels()
    {
        lableNameInitArrayList = OtherLogic.Model2TextBoxBingoNamePreset;
        int i = 0;
        foreach (Label label in lableNameArrayList)
        {
            label.Text = lableNameInitArrayList[i].ToString();
            i += 1;
        }
    }

    private void SetLabelsBinding()
    {
        lotteryTimers = OtherLogic.MultiLotteryTimerList;
        node = lotteryTimers.First;
        foreach (Label label in lableNameArrayList)
        {
            label.SetBinding(Label.TextProperty, new Binding("BingoNameReturnTextBlock")
            {
                Source = node.Value
            });
            if (node.Next != null)
            {
                node = node.Next;
            }
            else
            {
                break;
            }
        }
    }

    private void LotteryFinishToast()
    {
        string bingoNameString = "";
        foreach (String bingoName in OtherLogic.Model2BingoNameStack)
        {
            bingoNameString += bingoName + ", ";
        }
        MainThread.BeginInvokeOnMainThread(() =>
        {
            var toast = Toast.Make($"抽签完成，恭喜 {bingoNameString} 成为本次幸运儿", ToastDuration.Short);
            toast.Show();
        });
    }

}