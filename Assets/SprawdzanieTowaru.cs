using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SprawdzanieTowaru : MonoBehaviour
{

    public GameObject Paleciak;
    public GameObject[] Wszystkie;
    private GameObject[] Cele;
    public string Tag;
    public Material Standard;
    public Material Complete;
    public Material Fail;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        Paleciak.GetComponent<MeshRenderer>().material = Standard;
        if (Cele == null)
            Cele = GameObject.FindGameObjectsWithTag(Tag);
    }

    // Update is called once per frame
    void Update()
    {
        SprawdzZawartosc();
    }

    private void SprawdzZawartosc()
    {
        int licznik = 0;
        int licznik_zlych = 0;
        for(int i=0; i<Wszystkie.Length; i++)
        {
            Vector3 Podloze = Paleciak.GetComponent<Renderer>().bounds.size;
            Vector3 Towar = Wszystkie[i].GetComponent<Renderer>().bounds.size;
            if ((Math.Abs(Wszystkie[i].transform.position.x + Towar.x / 2) <= Math.Abs(Paleciak.transform.position.x + Podloze.x / 2)) && (Math.Abs(Wszystkie[i].transform.position.z + Towar.z / 2) <= Math.Abs(Paleciak.transform.position.z + Podloze.z / 2)))
            {
                rb = Wszystkie[i].GetComponent<Rigidbody>();
                if(rb.velocity.y == 0)
                {
                if (Wszystkie[i].tag == Tag)
                    licznik++;
                else
                    licznik_zlych++;
                }
            }
        }
        if (licznik == Cele.Length && licznik_zlych == 0)
        {
            Paleciak.GetComponent<MeshRenderer>().material = Complete;
        }
        else if (licznik_zlych == 0 && licznik == 0)
        {
            Paleciak.GetComponent<MeshRenderer>().material = Standard;
        }
        else
        {
            Paleciak.GetComponent<MeshRenderer>().material = Fail;
        }

    }

}
