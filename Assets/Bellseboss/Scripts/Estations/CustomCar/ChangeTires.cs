using System.Collections.Generic;
using UnityEngine;

public class ChangeTires : CustomElement
{
    [SerializeField] protected GameObject[] listOfParts;
    [SerializeField] private Transform[] pointToChangeElement;
    private List<GameObject> elementConcurrent;

    public List<GameObject> ElementCurrents => elementConcurrent;
    protected override void Start()
    {
        elementConcurrent = new List<GameObject>();
        base.Start();
    }

    protected override int GetLengthOfList()
    {
        return listOfParts.Length;
    }

    protected override void ChangeElement()
    {
        //ServiceLocator.Instance.GetService<IDebugMediator>().LogR($"before to delete");
        foreach (var o in elementConcurrent)
        {
            Destroy(o);   
        }

        elementConcurrent = new List<GameObject>();
        //ServiceLocator.Instance.GetService<IDebugMediator>().LogR(listOfParts[internalIndex].name);
        foreach (var point in pointToChangeElement)
        {
            var elementConcurrentNew = Instantiate(listOfParts[internalIndex], point);
            elementConcurrentNew.transform.position = point.position;
            //elementConcurrentNew.transform.localScale = Vector3.one;
            elementConcurrent.Add(elementConcurrentNew);
        }
    }
}