using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Player : MonoBehaviour
{
    public List<int> PrimeNos;
    public List<int> CompositeNos;
    
    public List<Quest> activeQuests;

    public List<Quest> activePrimeNoQuests;
    public List<Quest> activeCompositeNoQuests;
    
}
