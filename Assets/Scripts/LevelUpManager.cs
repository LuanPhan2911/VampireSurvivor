using System.Collections.Generic;
using UnityEngine;

public class LevelUpManager : MonoBehaviour
{

    public static LevelUpManager Instance;
    [SerializeField] private WeaponControllerSO weaponListSO;
    [SerializeField] private PassiveItemListSO passiveItemListSO;
    [SerializeField] private LevelUpUI levelUpUI;

    public List<WeaponSO> usedWeaponList = new List<WeaponSO>();
    public List<PassiveItemSO> usedPassiveItemList = new List<PassiveItemSO>();

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(Instance);
        }
    }
    private void Start()
    {
        levelUpUI.OnEndPlayerLevelUp += LevelUpUI_OnEndPlayerLevelUp;
    }

    private void LevelUpUI_OnEndPlayerLevelUp(object sender, System.EventArgs e)
    {

        levelUpUI.RemoveCardListener();
        GameManager.Instance.EndPlayerLevelUp();

        levelUpUI.Hide();
    }

    public BaseWeaponController GetNewWeaponController()
    {
        List<BaseWeaponController> weaponControllerList = new List<BaseWeaponController>();

        foreach (var weaponController in weaponListSO.weaponControllerList)
        {
            if (!InventoryManager.Instance.GetWeaponSOList().Contains(weaponController.weaponSO)
                && !usedWeaponList.Contains(weaponController.weaponSO))
            {
                weaponControllerList.Add(weaponController);
            }
        }
        if (weaponControllerList.Count == 0)
        {
            return null;
        }
        else
        {
            BaseWeaponController weaponController = weaponControllerList[Random.Range(0, weaponControllerList.Count)];

            return weaponController;
        }
    }
    public BasePassiveItem GetNewPassiveItem()
    {
        List<BasePassiveItem> passiveItemList = new List<BasePassiveItem>();

        foreach (var passiveItem in passiveItemListSO.passiveItemList)
        {
            if (!InventoryManager.Instance.GetPassiveItemSOList().Contains(passiveItem.passiveItemSO)
                && !usedPassiveItemList.Contains(passiveItem.passiveItemSO))
            {
                passiveItemList.Add(passiveItem);
            }
        }
        if (passiveItemList.Count == 0)
        {
            return null;
        }
        else
        {
            BasePassiveItem passiveItem = passiveItemList[Random.Range(0, passiveItemList.Count)];

            return passiveItemList[Random.Range(0, passiveItemList.Count)];
        }
    }
    public BaseWeaponController GetUpgradeableWeaponController()
    {
        List<BaseWeaponController> weaponControllerList = new List<BaseWeaponController>();
        foreach (var weaponController in InventoryManager.Instance.weaponControllerList)
        {
            if (weaponController.weaponSO.nextLevelWeaponSO)
            {
                weaponControllerList.Add(weaponController);
            }
        }
        if (weaponControllerList.Count == 0)
        {
            return null;
        }
        return weaponControllerList[Random.Range(0, weaponControllerList.Count)];
    }
    public BasePassiveItem GetUpgradeablePassiveItem()
    {
        List<BasePassiveItem> passiveItemList = new List<BasePassiveItem>();
        foreach (var passiveItem in InventoryManager.Instance.passiveItemList)
        {
            if (passiveItem.passiveItemSO.nextLevelPassiveItemSO)
            {
                passiveItemList.Add(passiveItem);
            }
        }
        if (passiveItemList.Count == 0)
        {
            return null;
        }
        return passiveItemList[Random.Range(0, passiveItemList.Count)];
    }


}
