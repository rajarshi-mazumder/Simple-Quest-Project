using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[System.Serializable]
public class Quest
{
    public int questId;
    public string descritpion;
    public int successTarget;
    
    public float timeLimit;
    public float timer = 0f;

    Action successAction;
    Action failureAction;
    Action<int, Quest> testConditionAction;
    Player player;

    public List<int> enteredNumberSequence;
    
    public Quest(string desc, object p)
    {
        descritpion = "";
    }
    public Quest( string desc, (int  target, Action<int, Quest> testCondition) successCondition, Action onSuccess, float failureCondition=0, Action onFailure=null)
    {
        descritpion = desc;
        successTarget = successCondition.target;
        testConditionAction = successCondition.testCondition;
        timeLimit = failureCondition;
        successAction = onSuccess;
        failureAction = onFailure;

        enteredNumberSequence = new List<int>();
        Player.acceptedQuestsCount++;
        questId = Player.acceptedQuestsCount-1;

        player = GameObject.FindObjectOfType<Player>();
    }

    
    public void EnterNumber(int n)
    {
        Debug.Log("Entering "+n+" in questID: " + questId);
        testConditionAction(n, this);
        
        CheckIfSolved();

    }
    public void CheckIfSolved()
    {
       

            if (failureAction != null)
            {
                if (timer < timeLimit && enteredNumberSequence.Count >= successTarget)
                    FinishQuest();
                else if (timer >= timeLimit)
                    FailQuest();
            }
            else if (enteredNumberSequence.Count >= successTarget)
                    FinishQuest();
            

       
    }

    public void EndQuest()
    {
        player.activeQuests.Remove(this);

       
        {
            player.activeCompositeNoQuests.Remove(this);
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

