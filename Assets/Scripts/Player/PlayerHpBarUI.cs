using UnityEngine;
using UnityEngine.UI;

public class PlayerHpBarUI : MonoBehaviour
{
    [SerializeField] private Image barImage;

    private void Update()
    {
        UpdateVisual();
    }
    private void UpdateVisual()
    {
        barImage.fillAmount = PlayerManager.Instance.playerStat.currentHp / PlayerManager.Instance.playerStat.characterSO.maxHp;
    }

}
