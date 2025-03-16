using TMPro;
using UnityEngine;

public class StopwatchUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI stopwatchTimeText;


    private void Update()
    {
        UpdateStopwatchTime();
    }
    private void UpdateStopwatchTime()
    {

        stopwatchTimeText.text = GameManager.Instance.GetStopWatchTimeString();

    }
}
