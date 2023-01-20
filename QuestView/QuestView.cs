using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

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
        InitializedButtons();
    }


    private void InitializedPopup()
    {
        var model = controller.GetModel();
        titleText.text = model.TitleQuest;
        descriptionText.text = model.DescriptionQuest;
        xpText.text = " XP: " + model.xpReward;
    }

    private void InitializedButtons()
    {
        var buttons = gameObject.GetComponentsInChildren<Button>();
        foreach (var item in buttons)
        {
            if (item.GetComponent<UIButton>())
            {
                Common.ButtonType currentBtnType;
                Enum.TryParse(item.GetComponent<UIButton>().GetButtonType().ToString(), out currentBtnType);
                SetButtons(item, currentBtnType);
            }
        }
    }

    public override void SetButtons(Button item, Common.ButtonType buttonType)
    {
        base.SetButtons(item, buttonType);
        switch (buttonType)
        {
            case Common.ButtonType.Accept:
                item.onClick.AddListener(OnAcceptQuest);
                break;
            default:
                break;
        }
    }

    private void OnAcceptQuest()
    {
        Debug.Log($"[QuestView]: Need logic to acept quest");
        OnClosePopup();
    }
}
