using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    [Header("버튼 친구들")]
    public Button inventoryCloseButton;
    public Button statusCloseButton;
    public Button equipButton;
    public Button unEquiButton;

    [Header("UI 객체 친구들")]
    public GameObject inventoryPanel;
    public GameObject statusPanel;
    public GameObject inventoryButton;
    public GameObject statusButton;

    [Header("UI스크립트 친구들")]
    public UIMainMenu uiMainMenu;
    public  UIInventory uiInventory;
    public UIStatus uiStatus;

    [Header("테스트용 아이템 친구")]
    [SerializeField] private ItemData testItemData;

    private void Awake()
    {
        if (Instance == null) Instance = this;
    }

    private void Start()
    {
        Button inventoryBtn = inventoryButton.GetComponent<Button>();
        Button statusBtn = statusButton.GetComponent<Button>();

        inventoryBtn.onClick.AddListener(OpenInventory);
        statusBtn.onClick.AddListener(OpenStatus);
        inventoryCloseButton.onClick.AddListener(CloseInventory);
        statusCloseButton.onClick.AddListener(CloseStatus);

        equipButton.onClick.AddListener(uiInventory.OnEquipButton);
        unEquiButton.onClick.AddListener(uiInventory.OnUnEquipButton);

        uiMainMenu.UpdateMainUI();
        uiInventory.InitInventory();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            uiInventory.AddItem(testItemData);
        }
    }

    // 인벤토리 열기/닫기
    public void OpenInventory()
    {
        inventoryPanel.SetActive(true);
        inventoryButton.SetActive(false);
        statusButton.SetActive(false);
        uiInventory.UpdateUI();
    }

    public void OpenStatus()
    {
        statusPanel.SetActive(true);
        inventoryButton.SetActive(false);
        statusButton.SetActive(false);
        uiStatus.UpdateStatus();
    }

    public void CloseInventory()
    {
        inventoryPanel.SetActive(false);
        uiInventory.itemDataPanel.SetActive(false);
        inventoryButton.SetActive(true);
        statusButton.SetActive(true);
    }

    public void CloseStatus()
    {
        statusPanel.SetActive(false);
        inventoryButton.SetActive(true);
        statusButton.SetActive(true);
    }
}
