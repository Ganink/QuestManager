using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class QuestView : MonoBehaviour
{
    public static QuestView instance;
    [SerializeField] private QuestModel Model;
    [SerializeField] private TextMeshProUGUI titleText;
    [SerializeField] private TextMeshProUGUI descriptionText;
    [SerializeField] private TextMeshProUGUI xpText;

    public QuestView()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    private void OnEnable()
    {
        InitializedPopup();
    }


    private void InitializedPopup()
    {
        titleText.text = Model.TitleQuest;
        descriptionText.text = Model.DescriptionQuest;
        xpText.text = " XP: " + Model.xpReward;
    }

    public void SetPopup(QuestModel model)
    {
        this.Model = model;
        InitializedPopup();
    }
}
