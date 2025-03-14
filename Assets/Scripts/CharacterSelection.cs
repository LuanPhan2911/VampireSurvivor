using UnityEngine;

public class CharacterSelection : MonoBehaviour
{
    public static CharacterSelection Instance { get; private set; }

    private CharacterSO characterSO;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void SetCharacterSO(CharacterSO characterSO)
    {
        this.characterSO = characterSO;
    }
    public CharacterSO GetSelectionCharacterSO()
    {
        return characterSO;
    }
    public void Destroy()
    {
        Instance = null;
        Destroy(gameObject);
    }
}
