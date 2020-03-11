using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScenesManager : MonoBehaviour
{

    public void Playable()
    {
       SceneManager.LoadSceneAsync(1);
    }
}
