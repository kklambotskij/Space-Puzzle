using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Field : MonoBehaviour
{
    [SerializeField] Tile[,] Tiles = new Tile[10, 6]; //0 1 2 3 ������ �� ������
    [SerializeField] Tile tilePrefab;

    float interval = -0.87f;
    float y = 1;
    float x = -2;
    float time = 0;
    List<Tile> selected = new List<Tile>();
    public GameObject SpawnTile(int row)
    {        
        return null;
    }
    public void GenerateField()
    {
        for (int i = 4; i < 10; i++)
        {            
            for (int j = 0; j < 6; j++)
            {
                PlaceTile(i, j);
                x -= interval;
            }
            x = -2;
            y += interval;
        }
        y = 1;
    }

    private void PlaceTile(int i, int j)
    {
        var clone = Instantiate(tilePrefab);
        clone.transform.SetPositionAndRotation(new Vector3(x, y), new Quaternion());
        clone.SetTile(i, j);
        //clone.gameObject.SetActive(false);
        Tiles[i, j] = clone;
    }
    public void DeleteTile(Tile tile)
    {
        //Destroy(Tiles[tile.indexX, tile.indexY].gameObject);
        Tiles[tile.indexX, tile.indexY].gameObject.SetActive(false);
    }

    private void DeleteTile()
    {
        for (int i = 4; i < 10; i++)
        {
            for (int j = 0; j < 6; j++)
            {
                if(Tiles[i,j].gameObject.activeSelf == true)
                {
                    //Destroy(Tiles[i,j].gameObject);
                    Tiles[i, j].gameObject.SetActive(false);
                }
            }
        }
    }
    void Start()
    {
        GenerateField();
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.D))
        {
            DeleteTile();
        }
        else if (Input.GetKeyUp(KeyCode.A))
        {
            GenerateField();
        }

        
        

        time += Time.deltaTime;
        if(time > 0.3)
        {
            time = 0;

           // CheckTileHorizontal();
            CheckTileVertical();
            RespawnTile();
        }
    }

    public void RespawnTile()
    {
        int countTile = 1;
        for (int i = 4; i < 10; i++)
        {
            for (int j = 0; j < 6; j++)
            {
                if (Tiles[i, j].gameObject.activeSelf == false)
                {
                    Tiles[i, j].transform.position += new Vector3(0, 5 * countTile);
                    Tiles[i, j].SetTile(i, j);
                    Tiles[i, j].gameObject.SetActive(true);
                    countTile += 1;
                }
            }
        }
    }
    public void CheckTileHorizontal()
    {
        for (int i = 4; i < 10; i++)
        {
            Tile tile = Tiles[i, 0];
            selected.Clear();
            for (int j = 0; j < 6; j++)
            {
                if (selected.Count == 0)
                    selected.Add(tile);

                RaycastHit2D hit = Physics2D.Raycast(new Vector2(tile.transform.position.x, tile.transform.position.y), new Vector2(-interval, 0));

                if(hit.collider != null && hit.collider.gameObject.CompareTag("Tile"))
                {
                    if (tile.gameObject.activeSelf != false && hit.collider.GetComponent<Tile>().gameObject.activeSelf != false
                            && tile.GetValue() == hit.collider.GetComponent<Tile>().GetValue())
                    {
                        selected.Add(hit.collider.GetComponent<Tile>());
                        
                    }
                    else
                    {
                        if (selected.Count >= 3)
                        {
                            for (int num = 0; num < selected.Count; num++)
                            {
                                selected[num].gameObject.SetActive(false);
                            }
                            selected.Clear();
                        }
                    }
                    Debug.Log(hit.collider.gameObject.transform.position + " hit   tile " + tile.transform.position);
                    tile = hit.collider.GetComponent<Tile>();
                }
                else
                {
                    if (selected.Count >= 3)
                    {
                        for (int num = 0; num < selected.Count; num++)
                        {
                            selected[num].gameObject.SetActive(false);
                        }
                        selected.Clear();
                    }
                }
            }            
        }
        selected.Clear();
    }

    public void CheckTileVertical()
    {
        for (int i = 0; i < 6; i++)
        {
            Tile tile = SearchTile(x,y);
            if (tile == null)
                return;
            selected.Clear();

            for (int j = 4; j < 10; j++)
            {
                

                RaycastHit2D hit = Physics2D.Raycast(new Vector2(tile.transform.position.x, tile.transform.position.y), new Vector2(0, interval));

                if (hit.collider != null && tile.gameObject.CompareTag("Tile") && hit.collider.gameObject.CompareTag("Tile"))
                {
                    if (tile.gameObject.activeSelf != false && hit.collider.GetComponent<Tile>().gameObject.activeSelf != false
                            && tile.GetComponent<Tile>().GetValue() == hit.collider.GetComponent<Tile>().GetValue())
                    {
                        if (selected.Count == 0)
                            selected.Add(tile);
                        selected.Add(hit.collider.GetComponent<Tile>());
                    }
                    else
                    {
                        if (selected.Count >= 3)
                        {
                            for (int num = 0; num < selected.Count; num++)
                            {
                                selected[num].gameObject.SetActive(false);
                            }
                            selected.Clear();
                        }
                    }
                    tile = hit.collider.GetComponent<Tile>();
                }
                else
                {
                    if (selected.Count >= 3)
                    {
                        for (int num = 0; num < selected.Count; num++)
                        {
                            selected[num].gameObject.SetActive(false);
                        }
                        selected.Clear();
                    }
                }                
            }
            x -= interval;
        }
        x = -2;
        selected.Clear();
    }

    public Tile SearchTile(float x, float y)
    {
        Tile tile = null;
        Vector3 minPos = new Vector3(float.MaxValue, float.MaxValue, float.MaxValue);
        Vector3 searchTile = new Vector3(x, y);

        for (int i = 4; i < 10; i++)
        {
            for (int j = 0; j < 6; j++)
            {  
                Vector3 currentTile = Tiles[i, j].transform.position;
                if (Vector3.Distance(searchTile, currentTile) < Vector3.Distance(searchTile, minPos))
                {
                    tile = Tiles[i, j];
                    minPos = currentTile;
                }
            }
        }
        return tile;
    }
}
