using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldCellLonpos : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;
    private bool _isBusy = false;

    public void ChangeBusyCell(bool isBusy)
    {
        _isBusy = isBusy;
    }

    public bool IsBusy()
    {
        return _isBusy;
    }

    public void Color(Color color)
    {
        spriteRenderer.color = color;
    }
}
