using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Munição dropada de enemies. Quando entra em contato com player recarrega sua munição no ArrowLauncher
/// </summary>
public class DropAmmo : MonoBehaviour
{
    [SerializeField] private int reloadAmount = 3;

    private Pooler pool;

    void Start()
    {
        pool = GameObject.Find("AmmoPool").GetComponent<Pooler>();
    }
        
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {            
            ArrowLauncher al = other.GetComponent<ArrowLauncher>();
            al.Reload(reloadAmount);

            FindObjectOfType<AudioManager>().Play("PickUp");

            pool.FreeObject(gameObject);
        }
    }
}
