using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HPController : MonoBehaviour
{
    public int playerHP;

    [SerializeField] Image[] hearts;

    private void Start()
    {
        UpdateHP();
        
    }

    public void UpdateHP()
    {

        if (playerHP <= 0)
        {
            ReloadLevel();
        }
            

        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < playerHP)
                {
                    hearts[i].color = Color.red;
                }
            else
            {
                hearts[i].color = Color.black;
            }
        }
    }

    public void ReloadLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
}
