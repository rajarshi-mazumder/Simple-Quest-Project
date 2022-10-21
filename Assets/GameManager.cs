using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{
    #region Actions to handle and manage quests 

    public Action OnQuestFinish;
    public Action OnQuestFail;
    public static Action OnPrimeNoAdd;
    public static Action OnCompositeAdd;

    #endregion
    public float timeToCompleteQuest = 10f;

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
        if (player.activePrimeNoQuests.Count==0)
            InitialiseQuest(Quest.QuestType.PrimeNo, "Input " + i + "prime numbers", 
                player.PrimeNos.Count + i, OnQuestFinish, timeToCompleteQuest, OnQuestFail);
        else Debug.Log("Prime number quest already active!");
    }
    public void CreateCompositeNoQuest(int i)// Creates Composite Number quest to enter "i" composite numbers
    {
        if (player.activeCompositeNoQuests.Count==0)
            InitialiseQuest(Quest.QuestType.CompositeNo, "Input " + i + "composite numbers", 
                player.CompositeNos.Count + i, OnQuestFinish, timeToCompleteQuest, OnQuestFail);
        else Debug.Log("Composite number quest already active!");
    }

    // The InitialiseQuest Method contains parameters for quest description and success and failure conditions and actions
    public void InitialiseQuest(Quest.QuestType q, string desc, int successCondition, Action onSuccess,float failureCondition, Action onFailure )
    {
        Quest questObj = new Quest(q, desc, successCondition, onSuccess, failureCondition, onFailure);           
        player.activeQuests.Add(questObj);

        if (questObj.questType == Quest.QuestType.PrimeNo)
            player.activePrimeNoQuests.Add( questObj);
        else if (questObj.questType == Quest.QuestType.CompositeNo)
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

    public void AddPrimeNoToList(int n)
    {   
        if(n==0 || MathCalculations.isPrimeNumber(n))
        { 
            player.PrimeNos.Add(n);
            if(OnPrimeNoAdd!=null)
                OnPrimeNoAdd();            
        }    

    }
   public void AddCompositeNoToList(int n)
    {
        if (!MathCalculations.isPrimeNumber(n))
        {
            player.CompositeNos.Add(n);
            if (OnCompositeAdd != null)
                OnCompositeAdd();

        }
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
