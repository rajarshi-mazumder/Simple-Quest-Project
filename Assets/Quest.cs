using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[System.Serializable]
public class Quest
{
    public string descritpion;
    public int successTarget;
    Action successAction;
    Player player;

    public enum QuestType { PrimeNo, CompositeNo};
    public QuestType questType;

    public Quest()
    {
        descritpion = "";
    }
    public Quest(QuestType q, string desc, int successCondition, Action onSuccess)
    {
        questType = q;
        descritpion = desc;
        successTarget = successCondition;
        successAction = onSuccess;

        if (questType == QuestType.PrimeNo)
        {
            GameManager.OnPrimeNoAdd += CheckIfSolved;
            
        }

        else if (questType == QuestType.CompositeNo)
        {
            GameManager.OnCompositeAdd += CheckIfSolved;
            
        }
        player = GameObject.FindObjectOfType<Player>();
    }

    public void CheckIfSolved()
    {
        if (questType == QuestType.PrimeNo)
        {
            if (player.PrimeNos.Count >= successTarget)
                FinishQuest();
        }
        if (questType == QuestType.CompositeNo)
        {
            if (player.CompositeNos.Count >= successTarget)
                FinishQuest();
        }
    }
    public void FinishQuest()
    {   
        player.activeQuests.Remove(this);

        if (questType == QuestType.CompositeNo)
            player.activeCompositeNoQuests.Remove(this);
        if (questType == QuestType.PrimeNo)
            player.activePrimeNoQuests.Remove(this);
        GameManager.OnPrimeNoAdd -= CheckIfSolved;
        successAction();
    }
}
