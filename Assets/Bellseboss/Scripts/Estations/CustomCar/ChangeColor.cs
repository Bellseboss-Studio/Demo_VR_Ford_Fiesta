using System;
using UnityEngine;

public class ChangeColor : CustomElement
{
    [SerializeField] private Color[] colorsForCar;
    [SerializeField] private MeshRenderer[] renderOfCar;
    protected override void ChangeElement()
    {
        foreach (var meshRenderer in renderOfCar)
        {
            foreach (var material in meshRenderer.materials)
            {
                try
                {
                    if (material.name.Contains("Color_"))
                    {
                        material.color = colorsForCar[internalIndex];
                    }
                }
                catch (Exception e)
                {
                    Debug.LogWarning(e.Message);
                }
            }   
        }
    }

    protected override int GetLengthOfList()
    {
        return colorsForCar.Length;
    }
}