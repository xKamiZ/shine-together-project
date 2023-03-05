/*!
 * 
 * \brief Custom Player Input Manager Implementation
 * \author Vicente Brisa Saez
 * \version 0.1
 * \date 2023
 * \copyright GPL v3 License
 * 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Crossfade : MonoBehaviour
{
    /// <summary>
    /// Black Image
    /// </summary>
    public GameObject image;

    /// <summary>
    /// The transition(animator) we want to reproduce 
    /// </summary>
    public Animator transition;

    /// <summary>
    /// The parameter we have to active to start the trigger
    /// </summary>
    public string trigger = "Active";

    /// <summary>
    /// Timeout before animation playback
    /// </summary>
    public float transitionTime = 1;

    private void Start()
    {
        image.SetActive(true);
    }

    /// <summary>
    /// Load the next level
    /// </summary>
    /// <param name="sceneName"></param>
    public void LoadLevel(string sceneName)
    {
        StartCoroutine(LoadScene(sceneName, transitionTime));
    }

    /// <summary>
    /// Active the transition, wait a few seconds and load the scene
    /// </summary>
    /// <param name="sceneName">Next scene name</param>
    /// <param name="seconds">1 by default</param>
    /// <returns></returns>
    public IEnumerator LoadScene(string sceneName, float seconds = 1)
    {
        transition.SetTrigger(trigger);
        yield return new WaitForSeconds(seconds);
        SceneManager.LoadScene(sceneName);
    }
}
