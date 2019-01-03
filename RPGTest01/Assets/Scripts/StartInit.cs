using Assets.Scripts.atlas;
using Assets.Scripts.Global;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.U2D;

public class StartInit : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        
    }
    
    // Update is called once per frame
    void Update()
    {

    }
    /// <summary>
    /// 载入图集
    /// </summary>
    public void loadAtlas()
    {
        GameObject playUnit = (GameObject)Resources.Load("Prefabs/PlayUnit");
        GameObject canvas = GameObject.Find("PlayerParty");
        SpriteAtlas[] spriteAtlasArray = Resources.LoadAll<SpriteAtlas>("Atlas");
        AtlasDic atlasDic = new AtlasDic();
        atlasDic.Add(spriteAtlasArray);
        foreach (Atlas atlas in atlasDic.Values)
        {
            if (atlas == null)
            {
                continue;
            }
            GameObject unit = Instantiate(playUnit, canvas.transform);
            SpriteRenderer spriteRenderer = unit.GetComponent<SpriteRenderer>();
            spriteRenderer.sprite = atlas[0];
        }
    }
}
