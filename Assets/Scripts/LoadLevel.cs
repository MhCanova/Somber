using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class LoadLevel : MonoBehaviour
{
    
    [SerializeField] ParticleSystem sucessParticles;
    [SerializeField] ParticleSystem crashParticles;
    [SerializeField] private HPController hpManager;
    [SerializeField] private int DamageReceived;
    [SerializeField] AudioClip success;
    [SerializeField] AudioClip crash;

    public int playerHP;
    float levelLoadDelay = 1.5f;
    AudioSource audioSource;

    void Start() 
    {
       audioSource = GetComponent<AudioSource>();
    }
    
    void OnCollisionEnter(Collision other) 
    {   
        switch(other.gameObject.tag)
        {
            case "Obstacles":
                StartCrashSequence();
                break;
            case "Finish":
                StartSuccessSequence();
                break;
            default:
                break;
        }
    }

    void StartSuccessSequence()
    {

        //audioSource.Stop();
        audioSource.PlayOneShot(success);
        sucessParticles.Play();
        GetComponent<IsoCharacterController>().enabled = false;
        Invoke("LoadNextLevel", levelLoadDelay);
    }

    void StartCrashSequence()
{

    //audioSource.Stop();
    audioSource.PlayOneShot(crash);
    crashParticles.Play();
    DamageDealer();
}

void LoadNextLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;
        if (nextSceneIndex == SceneManager.sceneCountInBuildSettings)
        {
            nextSceneIndex = 0;
        }
        SceneManager.LoadScene(nextSceneIndex);
    }

    void DamageDealer()
    {
        hpManager.playerHP = hpManager.playerHP - DamageReceived;
        hpManager.UpdateHP();
    }

        public void ReloadLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        GetComponent<IsoCharacterController>().enabled = false;
        SceneManager.LoadScene(currentSceneIndex);
    }
}
