using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UIInventory : MonoBehaviour
{
    [Header("Inventory Info")]
    public TextMeshProUGUI maxSlotsText;
    public TextMeshProUGUI usedSlotsText;
    public Transform slotParent;   // 슬롯이 들어갈 부모 오브젝트
    public GameObject slotPrefab;  // 슬롯 프리팹

    private int maxSlotCount;
    private int usedSlotCount;
    private Button[] slotsBtn;
    public UISlot[] slots;

    [Header("Selected Item")]
    public UISlot selectedItem;
    private int selectedItemIndex;
    public GameObject itemDataPanel;
    public TextMeshProUGUI selectedItemName;
    public TextMeshProUGUI selectedItemDescription;
    public TextMeshProUGUI selectedItemStatName;
    public TextMeshProUGUI selectedItemStatValue;
    public GameObject equipButton;
    public GameObject unEquipButton;

    private int curEquipIndex;

    private Character character;


    void Start()
    {
        character = GameManager.Instance.character;
    }

    public void InitInventory()
    {
        maxSlotCount = GameManager.Instance.character.playerInfo.slots;
        usedSlotCount = 0;

        slotsBtn = new Button[maxSlotCount];
        slots = new UISlot[maxSlotCount];

        for (int i = 0; i < maxSlotCount; i++)
        {
            GameObject slotObj = Instantiate(slotPrefab, slotParent);
            slotsBtn[i] = slotObj.GetComponent<Button>();
            slots[i] = slotObj.GetComponent<UISlot>();
            slots[i].index = i;
            slots[i].inventory = this;
            slots[i].Clear();
        }

        UpdateUI();
        ClearSelectedItemWindow();
    }

    public void UpdateUI()
    {
        usedSlotsText.text = $"{usedSlotCount}";
        maxSlotsText.text = $"/ {maxSlotCount}";
        if(((float)usedSlotCount / (float)maxSlotCount ) >= 0.8)
        {
            usedSlotsText.color = Color.red;
        }
        else
        {
            usedSlotsText.color = Color.black;
        }

            for (int i = 0; i < slots.Length; i++)
            {
                if (slots[i].item != null)
                {
                    slots[i].Set();
                }
                else
                {
                    slots[i].Clear();
                }
            }
    }

    void ClearSelectedItemWindow()
    {
        selectedItem = null;

        selectedItemName.text = string.Empty;
        selectedItemDescription.text = string.Empty;
        selectedItemStatName.text = string.Empty;
        selectedItemStatValue.text = string.Empty;

        equipButton.SetActive(false);
        unEquipButton.SetActive(false);
    }
    

    public void AddItem(ItemData data)
    {
        UISlot emptySlot = GetEmptySlot();

        if (emptySlot != null)
        {
            emptySlot.item = data;
            usedSlotCount++;
            UpdateUI();
            return;
        }
    }


    UISlot GetEmptySlot()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i].item == null)
            {
                return slots[i];
            }
        }
        return null;
    }

    public void SelectItem(int index)
    {
        if (slots[index].item == null) return;

        itemDataPanel.SetActive(true);

        selectedItem = slots[index];
        selectedItemIndex = index;

        selectedItemName.text = selectedItem.item.itemName;
        selectedItemDescription.text = selectedItem.item.itemDescription;

        selectedItemStatName.text = string.Empty;
        selectedItemStatValue.text = string.Empty;

        for (int i = 0; i < selectedItem.item.itemStats.Length; i++)
        {
            selectedItemStatName.text += selectedItem.item.itemStats[i].status.ToString() + "\n";
            selectedItemStatValue.text += selectedItem.item.itemStats[i].value.ToString() + "\n";
        }

        equipButton.SetActive(!slots[index].equipped);
        unEquipButton.SetActive(slots[index].equipped);
    }


    public void OnEquipButton()
    {
        if (slots[curEquipIndex].equipped)
        {
            UnEquip(curEquipIndex);
        }

        slots[selectedItemIndex].equipped = true;
        curEquipIndex = selectedItemIndex;
        character.equip.EquipNew(selectedItem.item);
        UpdateUI();

        SelectItem(selectedItemIndex);
    }

    void UnEquip(int index)
    {
        slots[index].equipped = false;
        character.equip.UnEquip();
        UpdateUI();

        if (selectedItemIndex == index)
        {
            SelectItem(selectedItemIndex);
        }
    }

    public void OnUnEquipButton()
    {
        UnEquip(selectedItemIndex);
    }

}