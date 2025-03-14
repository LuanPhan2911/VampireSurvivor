using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameOverUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI levelReachedValueText;
    [SerializeField] private TextMeshProUGUI timeSurvivalValueText;

    [SerializeField] private Image characterIcon;
    [SerializeField] private TextMeshProUGUI characterNameText;
    [SerializeField] private InventoryUI inventoryUI;
    [SerializeField] private Button doneButton;

    private void Start()
    {
        GameManager.Instance.OnGameStateChanged += GameManager_OnGameStateChanged;
        doneButton.onClick.AddListener(() =>
        {
            SceneController.Instance.LoadScene(SceneController.MENU_SCENE);
        });
        Hide();

    }
    private void OnDestroy()
    {

        GameManager.Instance.OnGameStateChanged -= GameManager_OnGameStateChanged;
    }

    private void GameManager_OnGameStateChanged(object sender, GameManager.OnGameStateChangedEventArgs e)
    {
        if (e.gameState == GameManager.GameState.GameOver)
        {
            Show();
            UpdateText();
            UpdateCharacter();
            UpdateInventory();
        }
    }

    private void UpdateText()
    {
        levelReachedValueText.text = PlayerManager.Instance.playerStat.level.ToString();
        timeSurvivalValueText.text = "No set value";
    }
    private void UpdateCharacter()
    {
        characterIcon.sprite = PlayerManager.Instance.playerStat.characterSO.icon;
        characterNameText.text = PlayerManager.Instance.playerStat.characterSO.characterName;
    }
    private void UpdateInventory()
    {
        for (int i = 0; i < InventoryManager.Instance.weaponSlotList.Count; i++)
        {
            if (InventoryManager.Instance.weaponSlotList[i] != null)
            {
                inventoryUI.SetWeaponSlotUI(i, InventoryManager.Instance.weaponSlotList[i].weaponSO.icon);
            }
        }
        for (int i = 0; i < InventoryManager.Instance.passiveItemSlotList.Count; i++)
        {
            if (InventoryManager.Instance.passiveItemSlotList[i] != null)
            {
                inventoryUI.SetPassiveItemSlotUI(i, InventoryManager.Instance.passiveItemSlotList[i].passiveItemSO.icon);
            }
        }
    }

    private void Show()
    {
        gameObject.SetActive(true);
    }
    private void Hide()
    {
        gameObject.SetActive(false);
    }
}
