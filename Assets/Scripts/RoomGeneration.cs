using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomGeneration : MonoBehaviour
{
    [SerializeField] int width;
    [SerializeField] int height;
    [SerializeField] float unitSize;
    [SerializeField] int doorSize;
    [SerializeField] GameObject origin;
    [SerializeField] GameObject wall;
    [SerializeField] GameObject bossPrefab;
    public GameObject playerPrefab;

    public Room room;
    

    // Start is called before the first frame update
    void Start()
    {

        CreateWalls();

        if (room.IsStartRoom)
        {
            Instantiate(playerPrefab, origin.transform.position + new Vector3(width / 2f, height / 2f, 0f), Quaternion.identity);
        } else if(room.IsBossRoom)
        {
            Instantiate(bossPrefab, origin.transform.position + new Vector3(width / 2f, height / 2f, 0f), Quaternion.identity);
        }
    }

    private void CreateWalls()
    {
        //Horizontal walls & doors
        for (int i = 0; i <= width; i++)
        {
            float x = origin.transform.position.x + unitSize * i;
            float y1 = origin.transform.position.y;
            float y2 = origin.transform.position.y + height * unitSize;
            
            if (Mathf.Abs(width / 2 - doorSize*i) > doorSize || !room.HasDoorDown)
            {
                Instantiate(wall, new Vector3(x, y1, 0f), Quaternion.identity, transform);
            }
            if (Mathf.Abs(width / 2 - doorSize * i) > doorSize || !room.HasDoorUp)
            {
                Instantiate(wall, new Vector3(x, y2, 0f), Quaternion.identity, transform);
            }
        }

        //Vertical walls & doors
        for (int i = 0; i <= height; i++)
        {
            float y = origin.transform.position.y + unitSize * i;
            float x1 = origin.transform.position.x;
            float x2 = origin.transform.position.x + width * unitSize;
            if (Mathf.Abs(height / 2 - doorSize * i) > doorSize || !room.HasDoorLeft)
            {
                Instantiate(wall, new Vector3(x1, y, 0f), Quaternion.identity, transform);
            }
            if (Mathf.Abs(height / 2 - doorSize * i) > doorSize || !room.HasDoorRight)
            {
                Instantiate(wall, new Vector3(x2, y, 0f), Quaternion.identity, transform);
            }
        }
    }

    public Vector2 GetSize()
    {
        return new Vector2(width * unitSize, height * unitSize);
    }

}
