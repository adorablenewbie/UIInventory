using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIInventory : MonoBehaviour
{
    [Header("Inventory Info")]
    public TextMeshProUGUI slotInfoText;
    public Transform slotParent;   // ������ �� �θ� ������Ʈ
    public GameObject slotPrefab;  // ���� ������

    private int maxSlotCount;
    private int usedSlotCount;
    private Button[] slots;

    public void InitInventory()
    {
        maxSlotCount = GameManager.Instance.character.playerInfo.slots;
        usedSlotCount = 0;

        slots = new Button[maxSlotCount];

        for (int i = 0; i < maxSlotCount; i++)
        {
            GameObject slotObj = Instantiate(slotPrefab, slotParent);
            slots[i] = slotObj.GetComponent<Button>();
        }

        UpdateSlotInfo();
    }

    public void AddItem(Sprite icon)
    {
        if (usedSlotCount >= maxSlotCount) return;

        Image slotImage = slots[usedSlotCount].GetComponent<Image>();
        slotImage.sprite = icon;
        slotImage.color = Color.white; // ���� Ȱ��ȭ

        usedSlotCount++;
        UpdateSlotInfo();
    }

    public void UpdateSlotInfo()
    {
        slotInfoText.text = $"{usedSlotCount} / {maxSlotCount}";
    }
}
