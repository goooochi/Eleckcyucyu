using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class url_coffee : MonoBehaviour
{
    public string url = "https://www.ejcra.org/column/fdvulm0000001htj-img/gazou1.jpg";

    [System.Obsolete]
    IEnumerator Start()
    {
        using (WWW www = new WWW(url))
        {
            yield return www;
            Renderer renderer = GetComponent<Renderer>();
            renderer.material.mainTexture = www.texture;
        }
    }

    //// Use this for initialization
    //void Start()
    //{
    
    //}

    //// Update is called once per frame
    //void Update()
    //{

    //}

}
