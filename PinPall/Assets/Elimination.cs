using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Elimination : MonoBehaviour
{
    [SerializeField] int vite = 3;
    [SerializeField] TextMeshProUGUI TestoVite;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Eliminator"))
        {
            vite -= 1;
        }
    }

    private void Update()
    {
        TestoVite.text = "Vite: " + vite;
        if (vite <= 0)
        {
            gameObject.SetActive(false);
        }
    }
}