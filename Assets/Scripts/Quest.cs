using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[System.Serializable]
public class Quest
{
    public string descritpion;
    public int successTarget;
    
    public float timeLimit;
    public float timer = 0f;

    Action successAction;
    Action failureAction;
    Player player;

    public enum QuestType { PrimeNo, CompositeNo};
    public QuestType questType;

    public Quest()
    {
        descritpion = "";
    }
    public Quest(QuestType q, string desc, int  successCondition, Action onSuccess, float failureCondition=0, Action onFailure=null)
    {
        questType = q;
        descritpion = desc;
        successTarget = successCondition;
        timeLimit = failureCondition;
        successAction = onSuccess;
        failureAction = onFailure;

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
            if (failureAction != null)
            {
                if (timer < timeLimit && player.PrimeNos.Count >= successTarget)
                    FinishQuest();
                else if (timer >= timeLimit)
                    FailQuest();
            }
            else if (player.PrimeNos.Count >= successTarget)
                    FinishQuest();
            
        }
        if (questType == QuestType.CompositeNo)
        {
            if (failureAction != null)
            {
                if (timer < timeLimit && player.CompositeNos.Count >= successTarget)
                    FinishQuest();
                else if (timer >= timeLimit)
                    FailQuest();
            }
            else if (player.CompositeNos.Count >= successTarget)
                FinishQuest();
        }
    }

    public void EndQuest()
    {
        player.activeQuests.Remove(this);

        if (questType == QuestType.CompositeNo)
        {
            player.activeCompositeNoQuests.Remove(this);
            GameManager.OnCompositeAdd -= CheckIfSolved;
        }
        if (questType == QuestType.PrimeNo)
        {
            player.activePrimeNoQuests.Remove(this);
            GameManager.OnPrimeNoAdd -= CheckIfSolved;
        }
        
    }
    public void FinishQuest()
    {
        EndQuest();
        successAction();
        Debug.Log(descritpion + " quest completed");
    }

    public void FailQuest()
    {
        EndQuest();
        failureAction();
        Debug.Log(descritpion + " quest failed");
    }
}

