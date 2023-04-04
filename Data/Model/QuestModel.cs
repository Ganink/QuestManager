using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class QuestModel
{
    public int id;
    public string TitleQuest;
    [TextArea] public string DescriptionQuest;
    public int levelRequired;
    public int xpReward;
    public List<ItemSO> Rewards;
}