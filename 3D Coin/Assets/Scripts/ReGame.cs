using UnityEngine;
using UnityEngine.SceneManagement;

public class ReGame : MonoBehaviour
{
    public void RestartGame()
    {
        // Mendapatkan indeks scene saat ini
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        // Memuat kembali scene saat ini
        SceneManager.LoadScene(currentSceneIndex);
    }
}
