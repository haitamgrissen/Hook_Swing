using UnityEngine;

public class LevelGenerator : MonoBehaviour {
    [SerializeField]
    Texture2D[] maps;
    [SerializeField]
    ColorToPrefab[] colormappings;
    
    int lvlnum;
    Texture2D currentmap;
    

    private void Start()
    {  
        lvlnum = PlayerPrefs.GetInt("level");
        if (lvlnum < maps.Length )
        {
            currentmap = maps[lvlnum];
            GenerateLevel();
        }
        else if (lvlnum >= maps.Length)
        {
            currentmap = maps[Random.Range(1,maps.Length-1)];
            GenerateLevel();
        }
    }

    public void GenerateLevel()
    { 
        for (int x = 0; x < currentmap.width; x++)
        {
            for (int y = 0; y < currentmap.height; y++)
            {
                GenerateTile(x,y);
            }
        }
    }

    void GenerateTile(int x, int y)
    {
        Color pixelcolor = currentmap.GetPixel(x,y);
        if (pixelcolor.a == 0)
        {
            return;
        }
        foreach (ColorToPrefab colormapping in colormappings)
        {
            if (colormapping.color.Equals(pixelcolor))
            {
                Vector3 position = new Vector3(x,y,0.2f);
                Instantiate(colormapping.prefab, position, Quaternion.identity, transform);
            }
        }
    }
}
