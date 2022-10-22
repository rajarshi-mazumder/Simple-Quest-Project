using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    #region Actions to handle and manage quests 

    public Action OnQuestFinish;
    public Action OnQuestFail;
    

    public static Action<int> OnNumberEnter;
    public static Action<int, Quest> CheckForPrime;
    public static Action<int, Quest> CheckForComposite;

    public int questIdToEnterTo=0;

    #endregion
    public float timeToCompleteQuest = 1000f;
    public Text questTdField;

    public Player player;

    void Start()
    {
        OnQuestFinish += QuestComplete;
        OnQuestFail += QuestFail;
        player = FindObjectOfType<Player>();
        
        
    }
    public void Update()
    {
        if (player.activeQuests.Count > 0)
            ManageActiveQuestsTimer();
    }

    public void CreatePrimeNoQuest(int i) // Creates Prime Number quest to enter "i" prime numbers
    {
        
         InitialiseQuest( "Input " + i + " prime numbers", 
                 (i, CheckForPrime), OnQuestFinish, timeToCompleteQuest, OnQuestFail);
        
    }
    public void CreateCompositeNoQuest(int i)// Creates Composite Number quest to enter "i" composite numbers
    {
        InitialiseQuest("Input " + i + " composite numbers",
                 (i, CheckForComposite), OnQuestFinish, timeToCompleteQuest, OnQuestFail);
    }

    // The InitialiseQuest Method contains parameters for quest description and success and failure conditions and actions
    public void InitialiseQuest( string desc, (int target, Action<int, Quest> testCondition) successCondition,
        Action onSuccess,float failureCondition, Action onFailure )
    {
        Quest questObj = new Quest( desc, (successCondition.target, successCondition.testCondition), 
            onSuccess, failureCondition, onFailure);           
        player.activeQuests.Add(questObj);

           
            player.activePrimeNoQuests.Add( questObj);
        
            player.activeCompositeNoQuests.Add( questObj);
    }
    
    // Updates timer for active quests and prompts to check if quest has been solved
    void ManageActiveQuestsTimer()
    {
        try
        {
            foreach (Quest q in player.activeQuests)
            {
                q.timer += Time.deltaTime;
                q.CheckIfSolved();

            }
        }catch(System.Exception)
        {

        }
    }
    public void QuestToEnterTo(int n) // Take user the quest to which you wish to enter to
    {   
        
        Debug.Log("Quest ID set to "+n);
        if (n < Player.acceptedQuestsCount)
        {
            foreach(Quest q in player.activeQuests)
            {
                if (q.questId == n)
                    questIdToEnterTo = n;
            }
        }
    }
    public void EnterNoToQuest(int n) // Enter the number to be added to the quest
    {   
        try
        {
            foreach (Quest q in player.activeQuests)
            {
                if (q.questId == questIdToEnterTo)
                {
                    q.EnterNumber(n);
                }
            }
        }catch(System.Exception)
        { }

    }
    

    public void QuestComplete()
    {
        player.playerLevel++;
        Debug.Log("Player Level Increased to " + player.playerLevel);
    }

    public void QuestFail()
    {
        if (player.playerLevel > 0)
        {
            player.playerLevel--;
            Debug.Log("Player Level Decreased to " + player.playerLevel);
        }
    }
}
