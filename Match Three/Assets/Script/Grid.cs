using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
    public int gridSizeX, gridSizeY;
    public Vector2 startPos, offset;
    
    public GameObject tilePrefab; 

    public GameObject[,] tiles;
    public GameObject[] candies;


    // Start is called before the first frame update
    void Start()
    {
        CreateGrid();
    }

    // Update is called once per frame
    void CreateGrid()
    {
        tiles = new GameObject[gridSizeX, gridSizeY];

        Vector2 offset = tilePrefab.GetComponent<SpriteRenderer>().bounds.size;

        Vector2 startPosition = transform.position +(Vector3.left * (offset.x * gridSizeX/2)) + (Vector3.down * (offset.y * gridSizeY/3));

        for (int x = 0; x< gridSizeX; x++){
            for (int y = 0; y<gridSizeY; y++){
                Vector2 pos = new Vector3(startPosition.x + (x*offset.x), startPosition.y+(y * offset.y));
                GameObject backgroundTile = Instantiate (tilePrefab, pos, tilePrefab.transform.rotation);
                backgroundTile.transform.parent = transform;
                backgroundTile.name = "(" + x + "," + y + ")";

                int index = Random.Range(0, candies.Length);

                GameObject candy = Instantiate(candies[index], pos, Quaternion.identity);
                candy.name = "(" + x + "," + y + ")";
                tiles[x, y] = candy;
            }
        }

//         int MAX_ITERATION = 0;
// while (MatchesAt(x, y, candies[index]) && MAX_ITERATION < 100){
//            index = Random.Range(0, candies.Length);
//            MAX_ITERATION++;
// }
// MAX_ITERATION = 0;
    }
private bool MatchesAt(int column, int row, GameObject piece){
        //Cek jika ada tile yang sama dengan dibawah dan samping nya
        if (column > 1 && row > 1){
            if (tiles[column - 1, row].tag == piece.tag && tiles[column - 2, row].tag == piece.tag){
                return true;
            }
            if (tiles[column, row - 1].tag == piece.tag && tiles[column, row - 2].tag == piece.tag){
                return true;
            }
        }
        else if (column <= 1 || row <= 1){
            //Cek jika ada tile yang sama dengan atas dan sampingnya
            if (row > 1){
                if (tiles[column, row - 1].tag == piece.tag && tiles[column, row - 2].tag == piece.tag){
                    return true;
                }
            }
            if (column > 1){
                if (tiles[column - 1, row].tag == piece.tag && tiles[column - 2, row].tag == piece.tag){
                    return true;
                }
            }
        }
        return false;
 }

}
