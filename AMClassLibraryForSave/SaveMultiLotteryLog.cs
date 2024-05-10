namespace AMClassLibraryForSave
{
    public class SaveMultiLotteryLog : SaveLotteryLog
    {
        private Stack<string> saveBingoNameStack;

        public SaveMultiLotteryLog(string saveBingoName, LinkedList<string> nameList, Stack<string> saveBingoNameStack) : base(saveBingoName, nameList)
        {
            this.saveBingoNameStack = saveBingoNameStack;
        }

        public new void SaveLogLogic()
        {
            string contect = DateTime.Now + ",";
            foreach (string bingoName in this.saveBingoNameStack)
            {
                contect += bingoName + " ";
            }
            contect += "," + ForEachNameList();
            using (var sw = new StreamWriter(appPath + "/LotteryLog.txt", true))
            {
                sw.WriteLine(contect);
                sw.Close();
            }
        }
    }
}
