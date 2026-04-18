using System.Collections.Generic;

[System.Serializable]
public class GameSaveData
{
    public double SavedShells;
    public double SavedKnives;

    public List<int> UpgradeTiers;

    public GameSaveData()
    {
        UpgradeTiers = new List<int>();
    }
}
