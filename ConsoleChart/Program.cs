using System;
using System.Collections.Generic;
using System.Linq;

List<Entry> entries = new List<Entry>();

var categories = Console.ReadLine().Split('\t');

var column1 = Array.IndexOf(categories, args[0]);
var column2 = Array.IndexOf(categories, args[1]);
var limit = Convert.ToInt32(args[2]);


while (true)
{
    var currentLine = Console.ReadLine();
    if (string.IsNullOrEmpty(currentLine))
    {
        break;
    }

    var lineSplitted = currentLine.Split('\t');

    entries.Add(new Entry(lineSplitted[column1], Convert.ToInt32(lineSplitted[column2])));
}


var groupedEntries = entries.GroupBy(entry => entry.EntryTitle).Select(entry => new Entry(entry.Key, entry.Sum(e => e.Limit)))
                     .OrderByDescending(entry => entry.Limit).ToList();

int highestAmount = groupedEntries.Max(entry => entry.Limit);
var count = 0;
foreach (var entry in groupedEntries)
{

    var percentage = (int)((double)entry.Limit / highestAmount * 100);

    Console.Write($"{entry.EntryTitle, 35} |");

    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine($"{ GetBarForPercentage(percentage)}");
    Console.ForegroundColor = ConsoleColor.Gray;

    if (count == limit)
    {
        break;
    }
    count++;
}

static String GetBarForPercentage(int percentage)
{
    return new string('█', percentage) + new string(' ', (100 - percentage));
}