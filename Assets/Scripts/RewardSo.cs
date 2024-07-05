using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public enum RewardType
{
    Coin
}

[CreateAssetMenu(fileName = "Reward", menuName = "Rewards/Reward")]
public class RewardSo : ScriptableObject
{
    public RewardType RewardType;
    public int CurrentRewardCount;
    public static event Action<int> CollectReward;

    public void AddReward(int count)
    {
        CurrentRewardCount += count;
        CollectReward?.Invoke(CurrentRewardCount);
    }
}
