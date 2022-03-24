using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GeneratorSwitch : MonoBehaviour
{
    [SerializeField] private UnityEvent toggle;


    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Player")
        {
            toggle?.Invoke();
        }
    }
}
