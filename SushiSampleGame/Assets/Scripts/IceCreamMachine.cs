using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceCreamMachine : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Collected"))
        {
            
            other.transform.GetChild(0).gameObject.SetActive(true);
            other.tag = "Chiyelek";
            return;

        }
        if (other.CompareTag("Chiyelek"))
        {

            other.transform.GetChild(1).gameObject.SetActive(true);
            other.tag = "White";
            return;
        }
        if (other.CompareTag("White"))
        {

            other.transform.GetChild(2).gameObject.SetActive(true);
            other.tag = "Chocolate";
            return;
        }
        if (other.CompareTag("Chocolate"))
        {

            other.transform.GetChild(3).gameObject.SetActive(true);
            other.tag = "Cherry";
            return;
        }
    }
}
