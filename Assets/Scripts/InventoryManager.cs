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
    public List<BaseWeaponController> weaponControllerList;
    public int maxWaponControllerLenght = 6;


    [Header("Passive Item")]
    public List<BasePassiveItem> passiveItemList;
    public int maxPassiveItemLenght = 6;


    [Header("Inventory UI")]
    [SerializeField] private InventoryUI inventoryUI;


    private int weaponIndex;
    private int passiveItemIndex;

    public List<WeaponSO> GetWeaponSOList()
    {
        List<WeaponSO> weaponSOList = new List<WeaponSO>();
        foreach (var weaponSlot in weaponControllerList)
        {
            weaponSOList.Add(weaponSlot.weaponSO);
        }
        return weaponSOList;
    }
    public List<PassiveItemSO> GetPassiveItemSOList()
    {
        List<PassiveItemSO> passiveItemSOList = new List<PassiveItemSO>();
        foreach (var passiveItemSlot in passiveItemList)
        {
            passiveItemSOList.Add(passiveItemSlot.passiveItemSO);
        }
        return passiveItemSOList;
    }


    public void AddWeapon(int slotIndex, BaseWeaponController weaponController)
    {
        weaponControllerList.Add(weaponController);
        weaponController.slotIndex = slotIndex;

        inventoryUI.SetWeaponSlotUI(slotIndex, weaponController.weaponSO.icon);
    }
    public void AddPassiveItem(int slotIndex, BasePassiveItem passiveItem)
    {
        passiveItemList.Add(passiveItem);
        passiveItem.slotIndex = slotIndex;

        inventoryUI.SetPassiveItemSlotUI(slotIndex, passiveItem.passiveItemSO.icon);
    }
    public void LevelUpWeapon(BaseWeaponController weaponController)
    {

        weaponController.LevelUp();
        inventoryUI.SetWeaponSlotUI(weaponController.slotIndex, weaponController.weaponSO.icon);
    }


    public void LevelUpPassiveItem(BasePassiveItem passiveItem)
    {
        passiveItem.LevelUp();
        inventoryUI.SetPassiveItemSlotUI(passiveItem.slotIndex, passiveItem.passiveItemSO.icon);
    }


    public void SpawnWeapon(GameObject weaponControllerPrefab)
    {
        if (weaponIndex >= maxWaponControllerLenght)
        {
            return;
        }

        GameObject weaponController = Instantiate(weaponControllerPrefab,
            PlayerManager.Instance.transform);
        AddWeapon(weaponIndex, weaponController.GetComponent<BaseWeaponController>());
        weaponIndex++;
    }
    public void SpawnPassiveItem(GameObject passiveItemPrefab)
    {
        if (passiveItemIndex >= maxPassiveItemLenght)
        {
            return;
        }

        GameObject passiveItem = Instantiate(passiveItemPrefab, PlayerManager.Instance.transform);

        AddPassiveItem(passiveItemIndex, passiveItem.GetComponent<BasePassiveItem>());
        passiveItemIndex++;
    }


}
