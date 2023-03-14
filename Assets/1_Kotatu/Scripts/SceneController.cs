using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
    public void MoveToMain()
    {
        // メインシーンへ
        SceneManager.LoadScene("Shika_LOD2");
        Debug.Log("MoveToMain");
    }

    public void MoveToResult()
    {
        // リザルトシーンへ

        SceneManager.LoadScene("Result");
        Debug.Log("MoveToResult");
    }

    public void MoveToTitle()
    {
        // タイトルシーンへ
        SceneManager.LoadScene("title");
        Debug.Log("MoveToTitle");
    }
}
