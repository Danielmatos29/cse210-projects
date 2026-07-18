using System;
using System.Collections.Generic;
using System.IO;

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
        string [] lines = File.ReadAllLines(file);

        foreach (string line in lines)
        {
            Console.WriteLine($"{line}\n");
        }
    }
}