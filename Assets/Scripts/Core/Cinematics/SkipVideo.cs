using UnityEngine;
using UnityEngine.SceneManagement;

public class SkipVideo : MonoBehaviour
{
    // Name of the next scene (Level 1)
    [SerializeField] private string nextSceneName = "_Menu";

    // Called when the skip button is clicked
    public void SkipToLevel()
    {
        // Load the next scene directly
        SceneManager.LoadScene(nextSceneName);
    }
}
