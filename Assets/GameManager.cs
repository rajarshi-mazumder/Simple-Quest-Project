using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{
    public Action OnQuestFinish;
    public static Action OnPrimeNoAdd;
    public static Action OnCompositeAdd;


    public Player player;

    void Start()
    {
        OnQuestFinish += DisplayQuestComplete;
        player = FindObjectOfType<Player>();

    }
  
    public void CreatePrimeNoQuest(int i)
    {
        if (player.activePrimeNoQuests.Count==0)
            InitialiseQuest(Quest.QuestType.PrimeNo, "Input " + i + "prime numbers", player.PrimeNos.Count + i, OnQuestFinish);
        else Debug.Log("Prime number quest already active!");
    }
    public void CreateCompositeNoQuest(int i)
    {
        if (player.activeCompositeNoQuests.Count==0)
            InitialiseQuest(Quest.QuestType.CompositeNo, "Input " + i + "composite numbers", player.CompositeNos.Count + i, OnQuestFinish);
        else Debug.Log("Composite number quest already active!");
    }
    public void InitialiseQuest(Quest.QuestType q, string desc, int successCondition, Action onSuccess )
    {
        Quest questObj = new Quest(q, desc, successCondition, onSuccess);
        player.activeQuests.Add(questObj);

        if (questObj.questType == Quest.QuestType.PrimeNo)
            player.activePrimeNoQuests.Add( questObj);
        else if (questObj.questType == Quest.QuestType.CompositeNo)
            player.activeCompositeNoQuests.Add( questObj);
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
    public void DisplayQuestComplete()
    {
        Debug.Log("Quest completed");
    }
}
