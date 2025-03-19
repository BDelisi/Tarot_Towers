using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button : MonoBehaviour
{
    public string SceneToOpen;
    // Start is called before the first frame update
   
    public void OnClick()
    {
        SceneManager.LoadScene(SceneToOpen);
    }
}
