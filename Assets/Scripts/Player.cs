using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Player : MonoBehaviour
{
    public int playerLevel = 0;

    public List<Quest> activeQuests;
    public static int acceptedQuestsCount=0;

    public List<Quest> activePrimeNoQuests;
    public List<Quest> activeCompositeNoQuests;


    
}
