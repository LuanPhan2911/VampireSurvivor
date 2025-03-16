using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelUpCardSingleUI : MonoBehaviour
{
    public Button cardButton;

    [SerializeField] private Image iconImage;
    [SerializeField] private TextMeshProUGUI itemNameText;
    [SerializeField] private TextMeshProUGUI descriptionText;


    public void RemoveListener()
    {
        cardButton.onClick.RemoveAllListeners();
    }

    public void UpdateVisual(Sprite icon, string name, string description)
    {
        iconImage.sprite = icon;
        itemNameText.text = name;
        descriptionText.text = description;
    }
    public void Show()
    {
        gameObject.SetActive(true);
    }
    public void Hide()
    {
        gameObject.SetActive(false);
    }
}
