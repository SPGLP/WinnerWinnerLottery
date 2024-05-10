namespace AMClassLibraryForSave
{
    // All the code in this file is included in all platforms.
    public class SaveLotteryLog
    {
        protected string appPath = FileSystem.Current.AppDataDirectory;
        private string saveBingoName;
        private LinkedList<string> nameList;

        public SaveLotteryLog(string saveBingoName, LinkedList<string> nameList)
        {
            this.saveBingoName = saveBingoName;
            this.nameList = nameList;
        }

        public void SaveLogLogic()
        {
            // saveLogLogic
            string contect = DateTime.Now + "," + saveBingoName + "," + ForEachNameList();
            using (var sw = new StreamWriter(appPath + "/LotteryLog.txt", true))
            {
                sw.WriteLine(contect);
                sw.Close();
            }
        }
        public string ForEachNameList()
        {
            string outputList = "";
            foreach (var name in nameList)
            {
                outputList += name + " ";
            }
            return outputList;
        }
    }
}