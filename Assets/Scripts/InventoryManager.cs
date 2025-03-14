using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    [Header("Weapon")]
    public List<BaseWeaponController> weaponSlotList = new List<BaseWeaponController>(6);
    public int[] weaponLevelList = new int[6];

    [Header("Passive Item")]
    public List<BasePassiveItem> passiveItemSlotList = new List<BasePassiveItem>(6);
    public int[] passiveItemLevelList = new int[6];

    [Header("Inventory UI")]
    [SerializeField] private InventoryUI inventoryUI;


    public void AddWeapon(int slotIndex, BaseWeaponController weaponController)
    {
        weaponSlotList[slotIndex] = weaponController;
        weaponLevelList[slotIndex] = weaponController.weaponSO.level;
        inventoryUI.SetWeaponSlotUI(slotIndex, weaponController.weaponSO.icon);
    }
    public void AddPassiveItem(int slotIndex, BasePassiveItem passiveItem)
    {
        passiveItemSlotList[slotIndex] = passiveItem;
        passiveItemLevelList[slotIndex] = passiveItem.passiveItemSO.level;
        inventoryUI.SetPassiveItemSlotUI(slotIndex, passiveItem.passiveItemSO.icon);
    }
    public void LevelUpWeapon(int slotIndex)
    {
        if (weaponSlotList.Count > slotIndex)
        {

            BaseWeaponController weaponController = weaponSlotList[slotIndex];
            if (!weaponController.weaponSO.nextLevelWeaponSO)
            {
                Debug.LogError("No next level for" + weaponController.weaponSO);
                return;
            }
            weaponController.weaponSO = weaponController.weaponSO.nextLevelWeaponSO;
            weaponLevelList[slotIndex] = weaponController.weaponSO.level;
            inventoryUI.SetWeaponSlotUI(slotIndex, weaponController.weaponSO.icon);

        }

    }
    public void LevelUpPassiveItem(int slotIndex)
    {
        if (passiveItemSlotList.Count > slotIndex)
        {
            BasePassiveItem passiveItem = passiveItemSlotList[slotIndex];
            if (!passiveItem.passiveItemSO.nextLevelPassiveItemSO)
            {
                Debug.LogError("No next level for" + passiveItem.passiveItemSO);
                return;
            }
            passiveItem.passiveItemSO = passiveItem.passiveItemSO.nextLevelPassiveItemSO;
            passiveItemLevelList[slotIndex] = passiveItem.passiveItemSO.level;
            inventoryUI.SetPassiveItemSlotUI(slotIndex, passiveItem.passiveItemSO.icon);
        }

    }
}
