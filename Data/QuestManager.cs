using System;
using System.Collections;
using System.Collections.Generic;
using IngameDebugConsole;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    [SerializeField] private QuestDatabase QuestDB;
    [SerializeField] private GameObject _questView;

    public static QuestManager instance;

    public QuestManager()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        DetailQuestActive();
    }

    private void Cheats()
    {
        
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            DetailQuestActive();
        }
    }

    public void DetailQuestActive()
    {
        var currentQuest = QuestDB.GetQuests().Find(t => t.GetQuestModel().CompletedQuest == false);
        if (currentQuest != null)
        {
            var model = currentQuest.GetQuestModel();
            QuestView.instance.SetPopup(model);

            _questView.SetActive(!_questView.activeSelf);

            string titleQuest = model.TitleQuest;
            int iDQuest = model.IDQuest;
            string descriptionQuest = model.DescriptionQuest;
            bool completedQuest = model.CompletedQuest;
            int xpReward = model.xpReward;
            List<ItemSO> rewards = model.Rewards;

            Debug.Log(
                $"Quest details" +
                $"\ntitle quest: {titleQuest} " +
                $"\nid : {iDQuest} " +
                $"\ndescription: {descriptionQuest} " +
                $"\ncompleted: {completedQuest} " +
                $"\nxp: {xpReward} " +
                $"\nrewards: {rewards} "
                );
        }
    }

    public void CompleteCurrentQuest()
    {
        var currentQuest = QuestDB.GetQuests().Find(t => t.GetQuestModel().CompletedQuest == false);
        currentQuest.GetQuestModel().CompletedQuest = true;
        DetailQuestActive();
    }

}
