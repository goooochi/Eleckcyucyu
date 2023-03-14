using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstructionPopUp : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void InstructionsOpen()
    {
        this.gameObject.SetActive(true);
    }

    public void InstructionsClose()
    {
        this.gameObject.SetActive(false);
    }
}
