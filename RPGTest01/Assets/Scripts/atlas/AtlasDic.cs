using Assets.Scripts.Global;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.U2D;

namespace Assets.Scripts.atlas
{

    class AtlasDic : LinkedHashMap<string, Atlas>
    {
        public static string Separator = "_";

        public void Add(SpriteAtlas spriteAtlas)
        {
            Sprite[] spriteArray = new Sprite[spriteAtlas.spriteCount];
            spriteAtlas.GetSprites(spriteArray);
            foreach (Sprite sprite in spriteArray)
            {
                if (sprite == null)
                {
                    continue;
                }
                string name = sprite.name;
                string key = name.Substring(0, name.LastIndexOf(Separator));
                Atlas atlas;
                if (!TryGetValue(key,out atlas))
                {
                    atlas = new Atlas();
                    Add(key, atlas);
                }
                atlas.Add(name, sprite);
            }
        }

        public void Add(SpriteAtlas[] spriteAtlasArray)
        {
            foreach (SpriteAtlas spriteAtlas in spriteAtlasArray)
            {
                Add(spriteAtlas);
            }
        }
    }

    
}
