using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEditor;

public class ColliderScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        ColliderAssign();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ColliderAssign()
    {
        foreach (Transform childTransform in this.gameObject.transform)
        {
            foreach (Transform grandChildTransform in childTransform)
            {
                grandChildTransform.gameObject.AddComponent<MeshCollider>();
            }
        }
    }

    void ColliderAssignTest()
    {
        Object[] selectedAsset = Selection.GetFiltered(typeof(GameObject), SelectionMode.Assets);
        foreach (var sel in selectedAsset)
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
}
