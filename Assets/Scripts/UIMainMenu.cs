using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIMainMenu : MonoBehaviour
{
    
    [Header("텍스트 친구들")]
    public TextMeshProUGUI playerNameText;
    public TextMeshProUGUI expText;
    public TextMeshProUGUI levelText;
    public TextMeshProUGUI jobText;
    public TextMeshProUGUI jobDescText;
    public TextMeshProUGUI goldText;

    [Header("게이지 친구")]
    public Image expGauge;
    

    // 메인 정보 업데이트
    public void UpdateMainUI()
    {
        playerNameText.text = $"{GameManager.Instance.character.playerName}";
        expText.text = $"{GameManager.Instance.character.exp} / {GameManager.Instance.character.CalculateGoalExp()}";
        levelText.text = $"{GameManager.Instance.character.level}";
        jobText.text = $"{GameManager.Instance.character.job}";
        goldText.text = $"{GameManager.Instance.character.gold}";

        switch (GameManager.Instance.character.job)
        {
            case EJob.코린이:
                jobDescText.text = "슬픈 코린이는 오늘도 눈물 젖은 코드를 짜고 있습니다.";
                break;
            default:
                jobDescText.text = "???";
                break;
        }

        expGauge.fillAmount = GameManager.Instance.character.exp / GameManager.Instance.character.CalculateGoalExp();
    }



}
