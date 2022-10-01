using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinChanger : MonoBehaviour
{
    [SerializeField] List<Sprite> sprites;
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        ChangeSkin(PlayerPrefs.GetInt("skin", 0));
    }

    public void ChangeSkin(int number)
    {
        if (number >= sprites.Count)
        {
            Debug.Log("Нет такого скина с номером" + number);
            return;
        }
        spriteRenderer.sprite = sprites[number];
    }
}
