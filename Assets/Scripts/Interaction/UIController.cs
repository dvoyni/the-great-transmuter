using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour {
    
    public GameObject victoryPanel;

	public void OnNextLevelClick() {
        SceneManager.LoadScene(SceneManager.GetSceneAt(0).buildIndex + 1);
    }
    
    public void OnExitClick() {
        SceneManager.LoadScene(0);
    }
    
    public void OnRestartClick() {
        SceneManager.LoadScene(SceneManager.GetSceneAt(0).buildIndex);
    }
    
    private void Update() {
        if (GameController.Instance.Won && !victoryPanel.activeSelf) {
            victoryPanel.SetActive(true);
        }
    }
}
