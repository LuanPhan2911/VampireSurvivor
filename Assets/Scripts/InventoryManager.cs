using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{


    [Header("Weapon")]
    public List<BaseWeaponController> weaponSlotList = new List<BaseWeaponController>(6);
    public int[] weaponLevelList = new int[6];
    public List<Image> weaponSlotUIList = new List<Image>(6);
    [Header("Passive Item")]
    public List<BasePassiveItem> passiveItemSlotList = new List<BasePassiveItem>(6);
    public int[] passiveItemLevelList = new int[6];
    public List<Image> passiveItemSlotUIList = new List<Image>(6);

    public void AddWeapon(int slotIndex, BaseWeaponController weaponController)
    {
        weaponSlotList[slotIndex] = weaponController;
        weaponLevelList[slotIndex] = weaponController.weaponSO.level;
        weaponSlotUIList[slotIndex].enabled = true;
        weaponSlotUIList[slotIndex].sprite = weaponController.weaponSO.icon;
    }
    public void AddPassiveItem(int slotIndex, BasePassiveItem passiveItem)
    {
        passiveItemSlotList[slotIndex] = passiveItem;
        passiveItemLevelList[slotIndex] = passiveItem.passiveItemSO.level;
        passiveItemSlotUIList[slotIndex].enabled = true;
        passiveItemSlotUIList[slotIndex].sprite = passiveItem.passiveItemSO.icon;
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
            weaponSlotUIList[slotIndex].sprite = weaponController.weaponSO.icon;
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
            passiveItemSlotUIList[slotIndex].sprite = passiveItem.passiveItemSO.icon;
        }

    }
}
