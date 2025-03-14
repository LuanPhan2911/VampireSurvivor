using TMPro;
using UnityEngine;

public class PlayerStatUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI healthText;
    [SerializeField] private TextMeshProUGUI moveSpeedText;
    [SerializeField] private TextMeshProUGUI mightText;
    [SerializeField] private TextMeshProUGUI projectileSpeedText;

    private void Start()
    {
        GameManager.Instance.OnGameStateChanged += GameManager_OnGameStateChanged;
        UpdateVisual(PlayerManager.Instance.playerStat);
    }

    private void GameManager_OnGameStateChanged(object sender, GameManager.OnGameStateChangedEventArgs e)
    {
        if (e.gameState == GameManager.GameState.GamePause)
        {
            UpdateVisual(PlayerManager.Instance.playerStat);
        }

    }
    private void OnDestroy()
    {
        GameManager.Instance.OnGameStateChanged -= GameManager_OnGameStateChanged;
    }
    private void UpdateVisual(PlayerStat playerStat)
    {
        healthText.text = $"Health: {playerStat.currentHp}";
        moveSpeedText.text = $"Move speed: {playerStat.currentMoveSpeed}";
        mightText.text = $"Might: {playerStat.currentMight}";
        projectileSpeedText.text = $"Projectile speed: {playerStat.currentProjectileSpeed}";
    }

}
