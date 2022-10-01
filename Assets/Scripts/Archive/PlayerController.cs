using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Camera cam;
    [SerializeField] Field field;
    [SerializeField] HashSet<Tile> selected = new HashSet<Tile>();
    enum State { Ready, Unite, Release }
    State state;
    Tile.Value value;
    void Start()
    {
        value = Tile.Value.Rhino;
    }
    void DrawSelectedLines()
    {
        Tile[] tiles = new Tile[selected.Count];
        selected.CopyTo(tiles);
        for (int i = 0; i < tiles.Length; i++)
        {
            if (i == selected.Count - 1)
            {
                Debug.DrawLine(tiles[i].transform.position, Utils.MousePos(cam));
            }
            else
            {
                Debug.DrawLine(tiles[i].transform.position, tiles[i + 1].transform.position);
            }
        }
    }

    bool SimmilarInSelected()
    {
        Tile[] tiles = new Tile[selected.Count];
        selected.CopyTo(tiles);
        Tile.Value value = tiles[0].GetValue();
        for (int i = 1; i < tiles.Length; i++)
        {
            if (tiles[i].GetValue() != value)
            {
                return false;
            }
        }
        return true;
    }

    bool SelectTile(bool first = false)
    {
        GameObject buffer = Utils.ClickSelect(cam);
        if (buffer != null)
        {
            if (buffer.CompareTag("Tile"))
            {
                Tile tile = buffer.GetComponent<Tile>();
                if (first)
                {
                    value = tile.GetValue();
                    selected.Add(tile);
                    return true;
                }
                else if (tile.GetValue() == value)
                {
                    selected.Add(tile);
                    return true;
                }
            }
        }
        return false;
    }

    void OnRelease()
    {
        if (selected.Count > 2)
        {
            foreach (var item in selected)
            {
                field.DeleteTile(item);
                field.RespawnTile();
            }
        }
        selected.Clear();
    }

    void Update()
    {
        switch (state)
        {
            case State.Ready:
                if (Input.GetMouseButtonDown(0))
                {
                    if (SelectTile(true))
                    {
                        state = State.Unite;
                    }
                }
                break;
            case State.Unite:
                DrawSelectedLines();
                SelectTile();
                if (Input.GetMouseButtonUp(0))
                {
                    state = State.Release;
                }
                break;
            case State.Release:
                OnRelease();
                state = State.Ready;
                break;
        }
    }
}
