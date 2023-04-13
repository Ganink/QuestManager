using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class QuestModel
{
    public int id;
    public string name;
    [TextArea] public string description;
    public int levelRequired;
    public int xpReward;
    public List<ItemSO> Rewards;
}