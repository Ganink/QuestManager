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
        var currentQuest = await UtilsManager.GetRemoteQuest("https://api.jsonbin.io/v3/b/642dc469ace6f33a220560c6?meta=false"); // quest
        //var currentQuest = UtilsManager.GetRemoteQuest(); //questDB.GetQuests().Find(t => t.GetQuestModel().CompletedQuest == false);
        if (currentQuest != null)
        {
            var modelCopy = currentQuest;
            SetModel(modelCopy);
        }
    }

    private static void PrivateLog(QuestModel model)
    {
        int iDQuest = model.id;
        string titleQuest = model.name;
        string descriptionQuest = model.description;
        int levelRequired = model.levelRequired;
        int xpReward = model.xpReward;
        List<ItemSO> rewards = model.Rewards;

        Debug.Log(
            $"Quest details" +
            $"\ntitle quest: {titleQuest} " +
            $"\nid : {iDQuest} " +
            $"\ndescription: {descriptionQuest} " +
            $"\ncompleted: {levelRequired} " +
            $"\nxp: {xpReward} " +
            $"\nrewards: {rewards} "
        );
    }

    public void CompleteCurrentQuest()
    {
        var currentQuest = questDB.GetQuests().Find(t => t.GetQuestModel().levelRequired >= 1); // TODO
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
        if (model == null)
        {
            DetailQuestActive();
        }

        return model;
    }
}