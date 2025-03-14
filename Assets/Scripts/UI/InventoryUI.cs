using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    [SerializeField] private List<Image> weaponSlotUIList = new List<Image>(6);
    [SerializeField] private List<Image> passiveItemSlotUIList = new List<Image>(6);


    public void SetWeaponSlotUI(int slotIndex, Sprite sprite)
    {
        weaponSlotUIList[slotIndex].enabled = true;
        weaponSlotUIList[slotIndex].sprite = sprite;
    }
    public void SetPassiveItemSlotUI(int slotIndex, Sprite sprite)
    {
        passiveItemSlotUIList[slotIndex].enabled = true;
        passiveItemSlotUIList[slotIndex].sprite = sprite;
    }
}
