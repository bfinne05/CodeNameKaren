using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public MoveBase Base { get; set; }
    public int PP { get; set; }


    public Move(MoveBase pBase)
    {
        Base = pBase;
        PP = pBase.PP;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
