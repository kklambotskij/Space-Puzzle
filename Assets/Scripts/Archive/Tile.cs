using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Класс для отображения плиток - тайлов
/// инстантинировать префаб tilePrefub
/// и вызвать у него SetTile и задать значение
/// Value - возможные значения sprites - список спрайтов для значений
/// </summary>
public class Tile : MonoBehaviour
{
    [SerializeField] private List<Sprite> sprites;
    [SerializeField] private Value value;
    public int indexX;
    public int indexY;
    public enum Value { Rhino, Chicken, Croco }
    public Tile SetTile(int x, int y)
    {
        int value = Random.Range(0, sprites.Count);
        return SetTile((Value)value, x ,y);
    }
    public Tile SetTile(int value, int x, int y)
    {
        return SetTile((Value)value, x, y);
    }
    public Tile SetTile(Value value, int x, int y)
    {
        this.value = value;
        indexX = x;
        indexY = y;
        GetComponent<SpriteRenderer>().sprite = sprites[(int)value];
        return this;
    }
    public Value GetValue()
    {        
        return value;
    }
}
