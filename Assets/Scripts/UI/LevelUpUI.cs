using System;
using UnityEngine;

public class LevelUpUI : MonoBehaviour
{
    [SerializeField] private LevelUpCardSingleUI levelUpWeaponCard;
    [SerializeField] private LevelUpCardSingleUI levelUpPassiveItemCard;

    [SerializeField] private LevelUpCardSingleUI newWeaponCard;
    [SerializeField] private LevelUpCardSingleUI newPassiveItemCard;

    public event EventHandler OnEndPlayerLevelUp;


    private void Start()
    {
        GameManager.Instance.OnGameStateChanged += GameManager_OnGameStateChanged;
        Hide();
    }

    private void GameManager_OnGameStateChanged(object sender, GameManager.OnGameStateChangedEventArgs e)
    {
        if (e.gameState == GameManager.GameState.PlayerLevelUp)
        {
            UpdateLevelUpPassiveItemCard();
            UpdateLevelUpWeaponCard();

            UpdateNewPassiveItem();
            UpdateNewWeaponCard();

            Show();
        }
    }

    private void UpdateLevelUpWeaponCard()
    {
        // level up weapon
        BaseWeaponController weaponController = LevelUpManager.Instance.GetUpgradeableWeaponController();
        if (weaponController == null)
        {
            // cann't level ,
            // hide this card
            levelUpWeaponCard.Hide();
            return;
        }
        //  weapon level up
        Sprite icon = weaponController.weaponSO.nextLevelWeaponSO.icon;
        string name = weaponController.weaponSO.nextLevelWeaponSO.weaponName;
        string description = weaponController.weaponSO.nextLevelWeaponSO.description;
        levelUpWeaponCard.Show();
        levelUpWeaponCard.UpdateVisual(icon, name, description);
        levelUpWeaponCard.cardButton.onClick.AddListener(() =>
        {
            InventoryManager.Instance.LevelUpWeapon(weaponController);
            OnEndPlayerLevelUp?.Invoke(this, EventArgs.Empty);
        });
    }
    private void UpdateNewWeaponCard()
    {
        // level up weapon
        BaseWeaponController weaonController = LevelUpManager.Instance.GetNewWeaponController();
        if (weaonController == null)
        {
            // cann't level ,
            // hide this card
            newWeaponCard.Hide();
            return;
        }
        //  weapon level up

        Sprite icon = weaonController.weaponSO.icon;
        string name = weaonController.weaponSO.weaponName;
        string description = weaonController.weaponSO.description;
        newWeaponCard.Show();
        newWeaponCard.UpdateVisual(icon, name, description);
        newWeaponCard.cardButton.onClick.AddListener(() =>
        {
            InventoryManager.Instance.SpawnWeapon(weaonController.gameObject);
            LevelUpManager.Instance.usedWeaponList.Add(weaonController.weaponSO);
            OnEndPlayerLevelUp?.Invoke(this, EventArgs.Empty);
        });
    }
    private void UpdateLevelUpPassiveItemCard()
    {
        // level up passive item
        BasePassiveItem passiveItem = LevelUpManager.Instance.GetUpgradeablePassiveItem();
        if (passiveItem == null)
        {
            // cann't level up,
            // hide this card
            levelUpPassiveItemCard.Hide();
            return;
        }
        //   level up
        Sprite icon = passiveItem.passiveItemSO.nextLevelPassiveItemSO.icon;
        string name = passiveItem.passiveItemSO.nextLevelPassiveItemSO.passiveItemName;
        string description = passiveItem.passiveItemSO.nextLevelPassiveItemSO.description;
        levelUpPassiveItemCard.Show();
        levelUpPassiveItemCard.UpdateVisual(icon, name, description);
        levelUpPassiveItemCard.cardButton.onClick.AddListener(() =>
        {
            InventoryManager.Instance.LevelUpPassiveItem(passiveItem);
            OnEndPlayerLevelUp?.Invoke(this, EventArgs.Empty);
        });
    }
    private void UpdateNewPassiveItem()
    {
        // new passive item 
        BasePassiveItem passiveItem = LevelUpManager.Instance.GetNewPassiveItem();
        if (passiveItem == null)
        {
            // cann't level up,
            // hide this card
            newPassiveItemCard.Hide();
            return;
        }
        //  new passive item
        Sprite icon = passiveItem.passiveItemSO.icon;
        string name = passiveItem.passiveItemSO.passiveItemName;
        string description = passiveItem.passiveItemSO.description;
        newPassiveItemCard.Show();
        newPassiveItemCard.UpdateVisual(icon, name, description);
        newPassiveItemCard.cardButton.onClick.AddListener(() =>
        {
            InventoryManager.Instance.SpawnPassiveItem(passiveItem.gameObject);
            LevelUpManager.Instance.usedPassiveItemList.Add(passiveItem.passiveItemSO);
            OnEndPlayerLevelUp?.Invoke(this, EventArgs.Empty);
        });
    }
    public void RemoveCardListener()
    {
        levelUpWeaponCard.RemoveListener();
        levelUpPassiveItemCard.RemoveListener();

        newPassiveItemCard.RemoveListener();
        newWeaponCard.RemoveListener();

    }

    private void Show()
    {
        gameObject.SetActive(true);
    }
    public void Hide()
    {
        gameObject.SetActive(false);
    }
}
