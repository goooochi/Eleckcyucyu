// FindTest.cs
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class FindTest : MonoBehaviour
{
    //[MenuItem("MyGame/Find")]
<<<<<<< HEAD
    public Texture ObjectTexture;
    public Material TargetMaterial;
    
    private void Awake()
    {
        
    }

=======
>>>>>>> develop
    void Start()
    {
        //TargetMaterial.SetTexture("_MainTex", ObjectTexture);
        //FindTestMenu();
        MaterialAssign();
    }

    private static void FindTestMenu()
    {
        // Photon フォルダ以下の Sprite ファイルを探してみるよ.
        string[] guids = AssetDatabase.FindAssets("17330", new string[] { "Assets/0_Shika/Bldg_materials/53394525_bldg_6677.fbm" });
        string[] paths = guids.Select(guid => AssetDatabase.GUIDToAssetPath(guid)).ToArray();
        Debug.Log($"検索結果:\n{string.Join("\n", paths)}");
    }

    static void MaterialAssign()
    {
        List<Material> mlist = new List<Material>();
        List<Texture2D> tlist = new List<Texture2D>();
        //List<Texture2D> outlist = new List<Texture2D>();


        //選択したフォルダの取得
        Object[] selectedAsset = Selection.GetFiltered(typeof(Object), SelectionMode.Assets);
        foreach (var sel in selectedAsset)
        {
            //Debug.Log(sel.name + " : " + sel.GetType());
            //選択したものがフォルダなら、フォルダ内にあるマテリアルとテクスチャを検索してリストに追加
            if ((sel.GetType().ToString() == "UnityEditor.DefaultAsset"))
            {
                var folder = (DefaultAsset)sel;
                var dirpath = AssetDatabase.GetAssetPath(folder);

                string[] diraug = { dirpath };
                //マテリアルに対する処理
                var mfiles = AssetDatabase.FindAssets("t:Material", diraug);
                foreach (var mf in mfiles)
                {
                    var mfpath = AssetDatabase.GUIDToAssetPath(mf);
                    var mfasset = AssetDatabase.LoadAllAssetsAtPath(mfpath);
                    foreach (var mfa in mfasset)
                    {
                        mlist.Add((Material)mfa);
                    }
                }
                //テクスチャに対する処理
                var tfiles = AssetDatabase.FindAssets("t:Texture2D", diraug);
                foreach (var tf in tfiles)
                {
                    var tfpath = AssetDatabase.GUIDToAssetPath(tf);
                    var tfasset = AssetDatabase.LoadAllAssetsAtPath(tfpath);
                    foreach (var tfa in tfasset)
                    {
                        tlist.Add((Texture2D)tfa);
                        //Debug.Log(tfa);
                    }
                }
            }
        }

        //Debug.Log("mlist : " + string.Join(",", mlist));
        //Debug.Log("tlist : " + string.Join(",", tlist));
        Debug.Log("mlist : " + mlist.Count);
        Debug.Log("tlist : " + tlist.Count);

        //マテリアルリストをfor文で回して名前の種類によって処理を分ける
        //foreach (var mat in mlist)
        //{
        //    foreach (var tex in tlist)
        //    {
        //        mat.SetTexture("_MainTex", null);
        //    }
        //}

        for (int i = 0; i < mlist.Count; i++)
        {
            mlist[i].SetTexture("_MainTex", tlist[i]);
        }
    }
}