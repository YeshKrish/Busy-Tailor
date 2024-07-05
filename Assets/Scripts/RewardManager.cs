using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RewardManager : MonoBehaviour
{
    public TMP_Text RewardText;
    public bool RefreshRewardForEachMatch;

    [SerializeField]
    private RewardSo reward;

    private void Start()
    {
        if (RefreshRewardForEachMatch)
        {
            reward.CurrentRewardCount = 0;
        }
    }

    private void OnEnable()
    {
        RewardSo.CollectReward += AddRewardToUI;
    }

    public void AddRewardToUI(int count)
    {
        RewardText.text = count.ToString();
    }

    private void OnDisable()
    {
        RewardSo.CollectReward -= AddRewardToUI;
    }
}
