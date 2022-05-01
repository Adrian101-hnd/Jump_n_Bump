using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public float levelGoalPositionX;

    public static LevelManager instance;

    private void Awake()
    {
        instance = this;
    }

    public float GetGoalPositionX()
    {
        return levelGoalPositionX;
    }

    public float GetProgressPercentage()
    {
        return (PersonajeMetadata.instance.GetPositionX() / GetGoalPositionX()) * 100;
    }
}
