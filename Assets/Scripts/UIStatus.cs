using UnityEngine;
using TMPro;

public class UIStatus : MonoBehaviour
{
    [Header("Status Texts")]
    public TextMeshProUGUI hpText;
    public TextMeshProUGUI atkText;
    public TextMeshProUGUI defText;
    public TextMeshProUGUI critText;
    public TextMeshProUGUI spedText;
    public TextMeshProUGUI avdText;

    
    void OnEnable()
    {
        UpdateStatus();
    }
    public void UpdateStatus()
    {
        hpText.text = $"{GameManager.Instance.character.health}";
        atkText.text = $"{GameManager.Instance.character.attack}";
        defText.text = $"{GameManager.Instance.character.defense}";
        critText.text = $"{GameManager.Instance.character.critical}";
        spedText.text = $"{GameManager.Instance.character.speed}";
        avdText.text = $"{GameManager.Instance.character.avoid}";
    }
}
