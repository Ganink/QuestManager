using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class QuestModel
{
    public string TitleQuest;
    public int IDQuest;
    [TextArea]
    public string DescriptionQuest;
    public bool CompletedQuest;
    public int xpReward;
    public List<ItemSO> Rewards;
}