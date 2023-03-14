using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEditor;

public class ColliderScript : MonoBehaviour
{
    //public Object[] bldgs;
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
        foreach (Transform childTransform in gameObject.transform)
        {
            foreach (Transform grandChildTransform in childTransform)
            {
                grandChildTransform.gameObject.AddComponent<MeshCollider>();
            }
        }
    }

    //void ColliderAssignTest()
    //{
    //    bldgs = Selection.GetFiltered(typeof(GameObject), SelectionMode.Assets);
    //    foreach (var sel in bldgs)
    //    {
    //        foreach (Transform childTransform in this.gameObject.transform)
    //        {
    //            foreach (Transform grandChildTransform in childTransform)
    //            {
    //                grandChildTransform.gameObject.AddComponent<BoxCollider>();
    //            }
    //        }
    //    }
    //}
}
