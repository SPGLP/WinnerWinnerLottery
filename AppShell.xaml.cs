using AMClassLibrary;

namespace AVENTURINECOIN_MAUIEDITION;

public partial class AppShell : Shell
{
    private string nameListPath = FileSystem.Current.AppDataDirectory + "/NameList.txt";

    public AppShell()
	{
		InitializeComponent();

        if (File.Exists(nameListPath))
        {
            InitNameList();
        }
        else
        {
            using (var sw = new StreamWriter(nameListPath))
            {
                sw.WriteLine("Roseliger Luo, Mofeng Huang, chaoix Huang, TangXiao Tang");
            }
        }
        
        
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
        StaticOtherLogic.nameList = nl;
    }
}