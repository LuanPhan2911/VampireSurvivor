using UnityEngine;
using UnityEngine.UI;

public class ExperienceBarUI : MonoBehaviour
{
    [SerializeField] private Image barImage;

    private void Start()
    {
        barImage.fillAmount = 0;
    }
    private void Update()
    {
        UpdateVisual();
    }
    private void UpdateVisual()
    {
        float fillAmount = (float)PlayerManager.Instance.playerStat.experience / PlayerManager.Instance.playerStat.experienceCap;
        barImage.fillAmount = Mathf.Lerp(barImage.fillAmount, fillAmount, 1f);


    }
}
