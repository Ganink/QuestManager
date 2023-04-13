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

    public async void DetailQuestActive()
    {
        var currentQuest = await RemoteConstants.QUESTS_GREENVILLEX;
        if (currentQuest != null)
        {
            var modelCopy = currentQuest.Find(t => t.id == 1);
            SetModel(modelCopy);
        }
    }

    private static void PrivateLog(QuestModel model)
    {
        string titleQuest = model.name;
        int id = model.id;
        string descriptionQuest = model.description;
        int levelRequired = model.levelRequired;
        int xpReward = model.xpReward;
        List<ItemSO> rewards = model.Rewards;

        Debug.Log(
            $"Quest details" +
            $"\ntitle quest: {titleQuest} " +
            $"\nid : {id} " +
            $"\ndescription: {descriptionQuest} " +
            $"\nlevel required: {levelRequired} " +
            $"\nxp: {xpReward} " +
            $"\nrewards: {rewards} "
            );
    }

    public void CompleteCurrentQuest()
    {
        var currentQuest = questDB.GetQuests().Find(t => t.GetQuestModel().levelRequired > 0);
        currentQuest.GetQuestModel();
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
