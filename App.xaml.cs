
namespace AVENTURINECOIN_MAUIEDITION;

public partial class App : Application
{
    private string nameListPath = FileSystem.Current.AppDataDirectory + "/NameList.txt";

    public App()
    {
        InitializeComponent();
        if (!File.Exists(nameListPath))
        {
            using (var sw = new StreamWriter(nameListPath))
            {
                sw.WriteLine("Roseliger Luo,Mofeng Huang,chaoix Huang,TangXiao Tang");
                sw.Close();
            }
        }
        InitNameList();
        MainPage = new AppShell();
    }

    private void InitNameList()
    {
        LinkedList<string> nl = new LinkedList<string>();
        var sr = new StreamReader(nameListPath);
        string nlPre = sr.ReadLine();
        string[] nlSplit = nlPre.Split(',');
        foreach (string items in nlSplit)
        {
            nl.AddLast(items);
        }
        StaticOtherLogic.nameList = new LinkedList<string>(nl);
        sr.Close();
    }

}