using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitionDoor : MonoBehaviour
{
    [SerializeField] private string nextSceneName; // Name of the next scene to load

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) // If the player enters the door
        {
            LoadNextScene();
        }
    }

    private void LoadNextScene()
    {
        // Save progress if needed
        PlayerPrefs.SetInt("currentLevel", SceneManager.GetActiveScene().buildIndex + 1);
        PlayerPrefs.Save();

        // Load the next scene
        SceneManager.LoadScene(nextSceneName);
    }
}
