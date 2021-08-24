using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NextSceneLoader : MonoBehaviour
{
    [SerializeField] private Button loadButton;

    private void Awake()
    {
        loadButton.onClick.AddListener(LoadArkanoidLevel);
    }

    private void OnDestroy()
    {
        loadButton.onClick.RemoveListener(LoadArkanoidLevel);
    }

    private void LoadArkanoidLevel()
    {
        SceneManager.LoadScene("Arkanoid");
    }
}
