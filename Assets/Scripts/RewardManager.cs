using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RewardManager : MonoBehaviour
{
    public static RewardManager Instance;

    public TMP_Text RewardText;
    public bool RefreshRewardForEachMatch;

    public int CurrentReward;
    public static event Action<int> CollectReward;

    [HideInInspector]
    public int PresentRewardAmount = 0;


    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    private void Start()
    {
        if (RefreshRewardForEachMatch)
        {
            CurrentReward = 0;
        }
    }

    public void AddReward()
    {
        PresentRewardAmount += CurrentReward;
        Debug.Log("Current Reward In AddReward" + CurrentReward + " PresentReward" + PresentRewardAmount);
        CollectReward?.Invoke(PresentRewardAmount);
        AddRewardToUI();
    }

    public void AddRewardToUI()
    {
        Debug.Log("Reward To Be Added" + PresentRewardAmount);
        RewardText.text = PresentRewardAmount.ToString();
    }

    public void SetCurrentRewardAmount(int amount)
    {
        CurrentReward = amount;
        Debug.Log("Current Reward" + CurrentReward);
    }

    public void ReducePresentRewardAmount(int amtToReduce)
    {
        PresentRewardAmount -= amtToReduce;
        AddRewardToUI();
    }
}
