using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIMainMenu : MonoBehaviour
{
    
    [Header("�ؽ�Ʈ ģ����")]
    public TextMeshProUGUI playerNameText;
    public TextMeshProUGUI expText;
    public TextMeshProUGUI levelText;
    public TextMeshProUGUI jobText;
    public TextMeshProUGUI jobDescText;
    public TextMeshProUGUI goldText;

    [Header("������ ģ��")]
    public Image expGauge;
    

    // ���� ���� ������Ʈ
    public void UpdateMainUI()
    {
        playerNameText.text = $"{GameManager.Instance.character.playerName}";
        expText.text = $"{GameManager.Instance.character.exp} / {GameManager.Instance.character.CalculateGoalExp()}";
        levelText.text = $"{GameManager.Instance.character.level}";
        jobText.text = $"{GameManager.Instance.character.job}";
        goldText.text = $"{GameManager.Instance.character.gold}";

        switch (GameManager.Instance.character.job)
        {
            case EJob.�ڸ���:
                jobDescText.text = "���� �ڸ��̴� ���õ� ���� ���� �ڵ带 ¥�� �ֽ��ϴ�.";
                break;
            default:
                jobDescText.text = "???";
                break;
        }

        expGauge.fillAmount = GameManager.Instance.character.exp / GameManager.Instance.character.CalculateGoalExp();
    }



}
