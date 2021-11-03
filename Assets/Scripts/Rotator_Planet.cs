using UnityEngine;
using System.Collections;

public class Rotator_Planet : MonoBehaviour
{

    void Update()
    {
        transform.Rotate(new Vector3(0, 0, -90) * Time.deltaTime);
    }
}