using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenePersist : MonoBehaviour
{
    int initialSceneIndex;

    private void Awake()
    {
        
        int numOfScenePersists = FindObjectsOfType<ScenePersist>().Length;
        if (numOfScenePersists > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        initialSceneIndex = SceneManager.GetActiveScene().buildIndex;
    }

    //public void RemoveCoin()
    void Update()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (initialSceneIndex != currentSceneIndex)
        {
            Destroy(gameObject);
        }
        //else
        //{
        //    DontDestroyOnLoad(gameObject);
        //}
    }

}
