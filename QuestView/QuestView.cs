using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class QuestView : UIView
{
    public static QuestView instance;
    [SerializeField] private TextMeshProUGUI titleText;
    [SerializeField] private TextMeshProUGUI descriptionText;
    [SerializeField] private TextMeshProUGUI xpText;
    [SerializeField] private QuestDatabase QuestDB;

    private QuestController controller;

    private void Awake()
    {
        controller = new QuestController(QuestDB);
    }

    public QuestView()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    private void OnEnable()
    {
        controller.DetailQuestActive();
        InitializedPopup();
    }


    private void InitializedPopup()
    {
        var model = controller.GetModel();
        titleText.text = model.TitleQuest;
        descriptionText.text = model.DescriptionQuest;
        xpText.text = " XP: " + model.xpReward;
    }
}
