using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class load : MonoBehaviour
{
    public Button s1;
    public Button s2;
    // Start is called before the first frame update
    void Start()
    {
        s1.onClick.AddListener(ss1);
        s2.onClick.AddListener(ss2);
    }
    public void ss1() { SceneManager.LoadScene(sceneName: "scene1"); }
    public  void ss2() { SceneManager.LoadScene(sceneName: "scene2"); }
    // Update is called once per frame
    void Update()
    {
        
    }
}
