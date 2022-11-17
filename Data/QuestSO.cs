using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Greenvillex/Quest/New Quest")]
public class QuestSO : ScriptableObject
{
    [SerializeField] private QuestModel questModel;

    public QuestModel GetQuestModel()
    {
        return questModel;
    }
}
