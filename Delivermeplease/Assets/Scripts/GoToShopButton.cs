using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToShopButton : MonoBehaviour
{
    public void GoToShop()
    {
        SceneManager.LoadScene(2);
    }
}
