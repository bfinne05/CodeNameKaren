using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPBar : MonoBehaviour
{

    [SerializeField] GameObject health;

    // Start is called before the first frame update

    public void setHP(float HPNormalized)
    {
        health.transform.localScale = new Vector3(HPNormalized, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
