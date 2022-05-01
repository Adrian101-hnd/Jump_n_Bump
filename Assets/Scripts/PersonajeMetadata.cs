using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonajeMetadata : MonoBehaviour
{
    public float positionX;

    public static PersonajeMetadata instance;

    private void Awake()
    {
        instance = this;
    }

    public float GetPositionX()
    {
        return positionX;
    }

    private void Update()
    {
        positionX = gameObject.transform.position.x;
    }
}
