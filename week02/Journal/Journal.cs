// Improve the process of saving and loading to save as a .csv file that could be opened in Excel (make sure to account for quotation marks and commas correctly in your content.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq.Expressions;

public class Journal
{
    public List<Entry> _entries = new List<Entry>();

    public void AddEntry(Entry newEntry)
    {
        _entries.Add(newEntry);
    }

    public void DisplayAll()
    {
        foreach (Entry entry in _entries)
        {
            entry.Display();
        }
    }

    public void SaveToFile(string file)
    {
        using (StreamWriter outputFile = new StreamWriter(file))
        {
            foreach (Entry entry in _entries)
            {
                outputFile.Write($"{entry._date},\"{entry._promptText}\",\"{entry._entryText}\"\n");
            }
        }
    }

    public void LoadFromFile(string file)
    {
        _entries.Clear();
        string [] lines = File.ReadAllLines(file);

        foreach (string line in lines)
        {
            string[] parts = line.Split(",");

            Entry loadedEntry = new Entry();

            loadedEntry._date = parts[0].Trim('"');
            loadedEntry._promptText = parts[1].Trim('"');
            loadedEntry._entryText = parts[2].Trim('"');

            _entries.Add(loadedEntry);
        }
    }
}