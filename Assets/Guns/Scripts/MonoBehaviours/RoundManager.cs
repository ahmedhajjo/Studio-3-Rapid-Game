using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundManager : MonoBehaviour
{
    [SerializeField] PlayActions[] allActionSet;
    int lastActionID = -1;
    int currentActionID;
    void Start()
    {
        
    }


    void Update()
    {
        if (currentActionID < allActionSet.Length)
        {
            if (lastActionID != currentActionID)
            {
                InitializeAction();
            }
            if (allActionSet[currentActionID].IsRunning())
            {
                GoNextRound();
            }
        }
        else Debug.Log("Game Rounds Over.....");
    }

    void InitializeAction()
    {
        lastActionID = currentActionID;
        allActionSet[currentActionID].Begin();
    }

    void GoNextRound()
    {
        allActionSet[currentActionID].Done();
        currentActionID++;
    }

}
