using UnityEngine;
using UnityEngine.UI;

public class DifficultyButton : MonoBehaviour
{
    [SerializeField] private int difficulty;
    
    private Button _button;
    private GameManager _gm;

    private void Awake()
    {
        _button = GetComponent<Button>();
    }

    private void Start()
    {
        _button.onClick.AddListener(SetDifficulty);
        _gm = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    private void SetDifficulty()
    {
        Debug.Log($"{gameObject.name} was clicked");
        _gm.StartGame(difficulty);
    }
}