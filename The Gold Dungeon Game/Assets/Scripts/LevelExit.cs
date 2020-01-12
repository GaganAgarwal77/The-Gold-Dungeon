using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelExit : MonoBehaviour
{
    [SerializeField] float LevelTransitionDelay = 2f;
    //ScenePersist obj = FindObjectOfType<ScenePersist>();
    // Start is called before the first frame update
    void OnTriggerEnter2D(Collider2D other)
    {
        //Destroy(obj);
        StartCoroutine(LevelTransition());
    }

    IEnumerator LevelTransition()
    {
        yield return new WaitForSecondsRealtime(LevelTransitionDelay);

        var currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }
}
    