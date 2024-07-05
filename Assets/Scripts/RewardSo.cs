using System;
using UnityEngine;

public enum RewardType
{
    Coin
}

[CreateAssetMenu(fileName = "Reward", menuName = "Rewards/Reward")]
public class RewardSo : ScriptableObject
{
    public RewardType RewardType;

}
