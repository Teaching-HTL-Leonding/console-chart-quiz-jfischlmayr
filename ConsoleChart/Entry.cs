internal class Entry
{
    public Entry(string entryTitle, int limit)
    {
        EntryTitle = entryTitle;
        Limit = limit;
    }

    public string EntryTitle { get; }

    public int Limit { get; }
}