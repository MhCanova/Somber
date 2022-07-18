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
            //Esto hay que cambiarlo a algo real cuando salga de test
            SceneManager.LoadScene("TestPabli");
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
}
