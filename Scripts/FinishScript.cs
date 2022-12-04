using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishScript : MonoBehaviour
{
    [SerializeField] private ParticleSystem particleSystem1;
    [SerializeField] private ParticleSystem particleSystem2;
    [SerializeField] private ParticleSystem particleSystem3;
    [SerializeField] private ParticleSystem particleSystem4;

    private void OnCollisionEnter(Collision collision)
    {
        particleSystem1.Play();
        particleSystem2.Play();
        particleSystem3.Play();
        particleSystem4.Play();
    }
}
