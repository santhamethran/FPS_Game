using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Scenemanagement : MonoBehaviour
{
    public void RetryBtnClick()
    {
        SceneManager.LoadScene(1);
    }
   
}
