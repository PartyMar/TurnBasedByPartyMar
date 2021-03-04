using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLVL : MonoBehaviour
{
    public void LVLn1()
    {
        SceneManager.LoadScene("LVL1");
    }
    public void LVLn2()
    {
        SceneManager.LoadScene("LVL2");
    }

    public void LVLn3()
    {
        SceneManager.LoadScene("LVL3");
    }
}
