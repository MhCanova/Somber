using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevel : MonoBehaviour
{
    [SerializeField] float levelLoadDelay = 1.5f;
    [SerializeField] ParticleSystem sucessParticles;
    [SerializeField] ParticleSystem crashParticles;

    bool isTransitioning = false;
    bool collisionDisabled = false;

    void OnCollisionEnter(Collision other) 
    {
        if (isTransitioning || collisionDisabled) { return; }
        
        switch(other.gameObject.tag)
        {
            case "Enemy":
                StartCrashSequence();
                break;
            case "Finish":
                StartSuccessSequence();
                break;
            default:
                Debug.Log("This thing is friendly");
                break;
        }
    }

    void StartSuccessSequence()
    {
        isTransitioning = true;
        //audioSource.Stop();
        //audioSource.PlayOneShot(sucess);
        sucessParticles.Play();
        GetComponent<IsoCharacterController>().enabled = false;
        Invoke("LoadNextLevel", levelLoadDelay);
    }

    void StartCrashSequence()
{
    isTransitioning = true;
    //audioSource.Stop();
    //audioSource.PlayOneShot(crash);
    crashParticles.Play();
    GetComponent<IsoCharacterController>().enabled = false;
    Invoke("ReloadLevel", levelLoadDelay);
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

    void ReloadLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
}
