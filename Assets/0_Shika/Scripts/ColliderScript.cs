using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        ColliderChecker();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ColliderChecker()
    {
        foreach (Transform childTransform in this.gameObject.transform)
        {
            foreach (Transform grandChildTransform in childTransform)
            {
                grandChildTransform.gameObject.AddComponent<BoxCollider>();
            }
        }
    }
}
