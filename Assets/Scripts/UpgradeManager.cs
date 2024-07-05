using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UpgradeManager : MonoBehaviour
{
    [SerializeField]
    private RewardSo _reward;

    //[SerializeField]
    //private int _nextUpgradeCost;
    //[SerializeField]
    //private int _nextRewardAmount;

    [Header("Text Fields")]
    [SerializeField]
    private TMP_Text _upgradeText; 
    [SerializeField]
    private TMP_Text _rewardAmountText;    
    [SerializeField]
    private TMP_Text _currentLevelText;
    [SerializeField]
    private GameObject _upgradeWarningPanel;    
    [SerializeField]
    private GameObject _upgradePanel; 

    private int _currentLevel = 1;
    private int _currentReward = 3;
    private int _currentUpgradeCost = 5;

    [Header("Upgrade Properties")]
    private int _thresholdLevel = 5;
    private int _maxNormalUpgradeCost = 4;
    private int _probabilityVal = 6; 

    [Header("Reward Properties")]
    private int _baseReward = 10;
    private int _maxRewardThreshold = 5;
    private int _rewardMultiplier = 3;

    private RewardManager _rewardManager;

    public LayerMask _upgradeUILayer;


    private void Start()
    {
        _rewardManager = RewardManager.Instance;
        _rewardManager.SetCurrentRewardAmount(_baseReward);
    }

    private void Update()
    {
        ClickChecker.CheckClick(OnClickOutsideUI);
    }
    private void OnClickOutsideUI()
    {
        _upgradePanel.SetActive(false);
        CheckForUpgrade(_rewardManager.PresentRewardAmount);

    }
    private void OnEnable()
    {
        RewardManager.CollectReward += CheckForUpgrade;
    }

    private void CheckForUpgrade(int currentRewardTotal)
    {
        if (currentRewardTotal > _currentUpgradeCost)
        {
            Debug.Log("Can Upgrade Now");
            if (!_upgradePanel.activeSelf)
            {
                _upgradeWarningPanel.SetActive(true);
                UpdateTextFields();
            }
        }
    }

    public void OnRewardButtonClick()
    {
        if(_rewardManager.PresentRewardAmount > _currentUpgradeCost)
        {
            _currentLevel++;
            _rewardManager.ReducePresentRewardAmount(_currentUpgradeCost);

            _currentUpgradeCost = CalculateNextUpgradeCost();
            _currentReward = CalculateNextRewardAmountCost();
            _rewardManager.SetCurrentRewardAmount(_currentReward);
            UpdateTextFields();
        }
    }

    private void UpdateTextFields()
    {
        _upgradeText.text = _currentUpgradeCost.ToString();
        _rewardAmountText.text = _currentReward.ToString();
        _currentLevelText.text = _currentLevel.ToString();
    }

    private int CalculateNextUpgradeCost()
    {
        int upgradeCost;
        if(_currentLevel % _thresholdLevel == 0)
        {
            upgradeCost = _currentUpgradeCost + (_currentLevel + _thresholdLevel / 3);
            IncreaseThesholdsBasedOnLevel();
            return upgradeCost;
        }
        else
        {
            if (CheckProbability(_currentUpgradeCost))
            {
                upgradeCost = _currentUpgradeCost + UnityEngine.Random.Range(2, _maxNormalUpgradeCost) + _probabilityVal;

            }
            else
            {
                upgradeCost = _currentUpgradeCost + UnityEngine.Random.Range(2, _maxNormalUpgradeCost);
            }
            IncreaseThesholdsBasedOnLevel();
            return upgradeCost;
        }
    }

    private void IncreaseThesholdsBasedOnLevel()
    {
        if(_currentLevel > _currentLevel % 10)
        {
            if(_thresholdLevel > 2)
            {
                _thresholdLevel--;
                _maxNormalUpgradeCost += _thresholdLevel;
            }
            else if(_thresholdLevel == 2)
            {
                _maxNormalUpgradeCost = _maxNormalUpgradeCost / _thresholdLevel;
            }
        }
    }

    private int CalculateNextRewardAmountCost()
    {
        int rewardCost;
        if(_currentLevel % 10 == 0)
        {
            rewardCost = _currentReward + UnityEngine.Random.Range(2, _maxRewardThreshold);
            _maxRewardThreshold += _rewardMultiplier;
            return rewardCost;
        }
        else
        {
            rewardCost = _currentReward + _rewardMultiplier;
            return rewardCost;
        }
    }

    public bool CheckProbability(float probability)
    {
        float randomValue = UnityEngine.Random.value;

        return randomValue < probability;
    }

    private void OnDisable()
    {
        RewardManager.CollectReward -= CheckForUpgrade;
    }
}
