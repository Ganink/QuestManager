using System.Collections.Generic;
using UnityEngine;

public class QuestController 
{
    private QuestDatabase questDB;
    private QuestModel model;

    public QuestController(QuestDatabase questDB)
    {
        this.questDB = questDB;
    }

    public void DetailQuestActive()
    {
        var currentQuest = UtilsManager.GetRemoteQuest(); //questDB.GetQuests().Find(t => t.GetQuestModel().CompletedQuest == false);
        if (currentQuest != null)
        {
            var modelCopy = currentQuest;
            SetModel(modelCopy);
        }
    }

    private static void PrivateLog(QuestModel model)
    {
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

    public void CompleteCurrentQuest()
    {
        var currentQuest = questDB.GetQuests().Find(t => t.GetQuestModel().CompletedQuest == false);
        currentQuest.GetQuestModel().CompletedQuest = true;
        DetailQuestActive();
    }

    public void SetModel(QuestModel model)
    {
        this.model = model;
        PrivateLog(this.model);
    }

    public QuestModel GetModel()
    {
        return model;
    }
}
