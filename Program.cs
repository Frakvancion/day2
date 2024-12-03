using System;
using System.Collections.Generic;

// 65 67 69 70 67   - false
// 45 47 49 51 53
// 84 85 87

bool isLevelSafe(List<int> szamok)
{
    bool is_increasing = szamok[0] < szamok[1];
    for (int i = 0; i < szamok.Count-1; ++i)
    {
        int diff = szamok[i] - szamok[i + 1];
        if (Math.Abs(diff) > 3 || diff == 0)
        {
            return false;
        }
        if ((diff > 0 && is_increasing) || (diff < 0 && !is_increasing))
        {
            return false;
        }
    
    }
    return true;
}

const Int32 BufferSize = 128;
using (var fileStream = File.OpenRead("C:/Users/csakf/Desktop/advent of code/2024/day2/day2/input.txt"))
using (var streamReader = new StreamReader(fileStream, System.Text.Encoding.UTF8, true, BufferSize))
{
    string line;
    int solution =0;
    while ((line = streamReader.ReadLine()) != null)
    {
        // 11 10 23
        string[] stringSzamok = line.Split(' ');
        List<int> szamok = new();
        foreach (string stringSzam in stringSzamok)
        {
            szamok.Add(int.Parse(stringSzam));
        }
        
        if(isLevelSafe(szamok))
        {
            solution++;
        }
        else
        {
            for(int i =0; i< szamok.Count;i++)
            {
                int toroltszam = szamok[i];
                szamok.RemoveAt(i);

                if (isLevelSafe(szamok))
                {
                    solution++;
                    break;
                }
                szamok.Insert( i ,toroltszam);
            }
        }
    }
    Console.WriteLine(solution);
}