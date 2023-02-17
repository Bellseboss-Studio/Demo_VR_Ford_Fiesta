using System;
using System.Collections.Generic;
using UnityEngine;

public class CustomElement : MonoBehaviour
{
    [SerializeField] private GameObject[] listOfParts;
    [SerializeField] private Transform[] pointToChangeElement;
    private List<GameObject> elementConcurrent;
    private int internalIndex;

    private void Start()
    {
        elementConcurrent = new List<GameObject>();
        ChangeElement();
    }

    public void Next()
    {
        internalIndex++;
        if (internalIndex > listOfParts.Length -1)
        {
            internalIndex = 0;
        }
        ChangeElement();
    }

    public void Previous()
    {
        internalIndex--;
        if (internalIndex < 0)
        {
            internalIndex = listOfParts.Length - 1;
        }
        ChangeElement();
    }

    private void ChangeElement()
    {
        foreach (var o in elementConcurrent)
        {
            Destroy(o);   
        }

        elementConcurrent = new List<GameObject>();
        
        foreach (var point in pointToChangeElement)
        {
            var elementConcurrentNew = Instantiate(listOfParts[internalIndex], point);
            elementConcurrentNew.transform.position = point.position;
            elementConcurrent.Add(elementConcurrentNew);
        }
        
    }
}