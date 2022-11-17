using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Greenvillex/Quest/QuestDB")]
public partial class QuestDatabase : ScriptableObject
{
    [SerializeField] private List<QuestSO> QuestDB;

    public QuestSO GetQuest(int index)
    {
        var selectedQuest = QuestDB[index];
        if (selectedQuest == null)
        {
            Debug.LogError("[QuestDatabase]: Quest Not Found!");
        }
        return selectedQuest;
    }

    public List<QuestSO> GetQuests()
    {
        return QuestDB;
    }
}
