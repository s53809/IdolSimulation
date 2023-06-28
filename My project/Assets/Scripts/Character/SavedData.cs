using System.Collections.Generic;

[System.Serializable]
public class SavedData
{
    public SavedData()
    {
        characterStrengths.Add(0);
        characterStrengths.Add(0);
        characterStrengths.Add(0);
        characterStrengths.Add(0);
    }

    public List<int> characterStrengths = new List<int>();
    public int level = 1;
    public int twopyoedCharacter = 0;
    public int zaehwa = 0;
}
