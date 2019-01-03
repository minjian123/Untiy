using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class SpriteAtlasManager: MonoBehaviour
{
    private static System.Action<string, Action<SpriteAtlas>> atlasRequested;

    void Awake()
    {
        // 注册事件
        SpriteAtlasManager.atlasRequested += OnAtlasRequested;
    }

    private void OnAtlasRequested(string tag, Action<SpriteAtlas> action)
    {
        // 加载纹理集
        // unity2017.1版本：当收到回调后必须立刻用纹理集填充
        // SpriteAtlas atlas = LoadAtlas(tag);
        // action(atlas);
        // 2018.2.1f1版本：可以异步加载纹理集，只需向action回调填充纹理集就可以了
        // 当纹理集没有被填充前，Image等组件将显示为默认的白色纹理
        // 一旦纹理填充后，Image等组件将自动显示为正确的纹理
        StartCoroutine(DoLoadAsset(action, tag));
    }

    private IEnumerator DoLoadAsset(Action<SpriteAtlas> action, string tag)
    {
        yield return new WaitForSeconds(3);
        var ab = AssetBundle.LoadFromFileAsync(getpath(tag));
        yield return ab;

        print("DoloadAsset frame:" + Time.frameCount);
        var sa = ab.assetBundle.LoadAsset<SpriteAtlas>(tag);
        print("sa: " + sa);
        action(sa);
    }

    private string getpath(string tag)
    {
        throw new NotImplementedException();
    }
}
