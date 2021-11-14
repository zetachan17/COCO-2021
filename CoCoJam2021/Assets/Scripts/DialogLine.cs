
[System.Serializable]
public class DialogLine
{
    public string line = "";
    public bool isCat = true;

    public DialogLine(string line, bool isCat)
	{
        this.line = line;
        this.isCat = isCat;
	}
}
