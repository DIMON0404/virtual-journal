using System;
using System.Collections.Generic;
using System.Linq;

[Serializable]
public class Teacher : ItemSO
{
    public string Name;
    public string SurName;
    public string Patronymic;
    private bool IsNSPInstanceInit;
    private List<string> NSPInstance;
    private List<string> NSPGetter => IsNSPInstanceInit ? NSPInstance : (NSPInstance = new List<string>{Name, SurName, Patronymic});

    public bool IsMatched(string text)
    {
        List<string> texts = text.Split(' ').ToList();
        for (int i = 0; i < texts.Count; i++)
        {
            texts[i] = texts[i].ToUpper();
        }

        List<string> NSP = NSPGetter;
        for (int i = 0; i < NSP.Count; i++)
        {
            NSP[i] = NSP[i].ToUpper();
        }
        return AllMatched(texts, NSP);
    }
    public override string ToString()
    {
        return SurName + " " + Name + " " + Patronymic;
    }

    public bool AllMatched(List<string> text, List<string> NSP)
    {
        bool matched = true;
        for (int i = 0; i < text.Count; i++)
        {
            matched = false;
            for (int j = 0; j < NSP.Count; j++)
            {
                if (NSP[j].Contains(text[i]))
                {
                    List<string> nextText = new List<string>(text.ToArray());
                    nextText.RemoveAt(i);
                    List<string> nextNSP = new List<string>(NSP.ToArray());
                    nextNSP.RemoveAt(j);
                    if (AllMatched(nextText, nextNSP))
                    {
                        return true;
                    }
                }
            }
        }

        return matched;
    }
}
