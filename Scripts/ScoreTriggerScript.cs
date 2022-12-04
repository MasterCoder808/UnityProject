using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreTriggerScript : MonoBehaviour
{
    private bool counted;
    private void OnCollisionEnter(Collision collision)
    {
        if (!counted)
        {
            GameManager.score++;
            counted = true;
        }
    }
}
