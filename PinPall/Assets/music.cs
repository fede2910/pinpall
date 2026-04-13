using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class music : MonoBehaviour
{
    [SerializeField] AudioClip[] musics;
    int m;

    // Start is called before the first frame update
    void Start()
    {
        m = Random.Range(0, musics.Length);
        GetComponent<AudioSource>().clip = musics[m];
        GetComponent<AudioSource>().Play();
    }
}
