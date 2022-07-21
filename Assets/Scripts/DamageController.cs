using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DamageController : MonoBehaviour
{
    [SerializeField] private int Damage;
    [SerializeField] private HPController hpManager;
    [SerializeField] ParticleSystem bugExplosion;
    [SerializeField] float levelLoadDelay = 1.5f;
    [SerializeField] float deathDelay = 1f;

    bool isTransitioning = false;
    bool collisionDisabled = false;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            bugExplosion.Play();
            DamageDealer();
        }
    }

    void DamageDealer()
    {
        
        hpManager.playerHP = hpManager.playerHP - Damage;
        hpManager.UpdateHP();
        Invoke("EnemyEraser", deathDelay);

        //Esto es provisorio. La idea es que los bichos vivan mas


    }

    void EnemyEraser()
    {
        
        Destroy(gameObject);
    }

    void OnCollisionEnter(Collision other) 
    {
        if (isTransitioning || collisionDisabled) { return; }
        
        switch(other.gameObject.tag)
        {
            case "Friendly":
                Debug.Log("This thing is friendly");
                break;
            case "Finish":
                StartSuccessSequence();
                break;
            default:
                StartCrashSequence();
                break;
        }
    }

    void StartSuccessSequence()
    {
        isTransitioning = true;
        //audioSource.Stop();
        //audioSource.PlayOneShot(sucess);
        //sucessParticles.Play();
        GetComponent<IsoCharacterController>().enabled = false;
        Invoke("LoadNextLevel", levelLoadDelay);
    }

    void StartCrashSequence()
{
    isTransitioning = true;
    //audioSource.Stop();
    //audioSource.PlayOneShot(crash);
    //crashParticles.Play();
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
