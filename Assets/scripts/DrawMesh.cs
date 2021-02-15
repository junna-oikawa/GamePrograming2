using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(CanvasRenderer))]
[RequireComponent(typeof(RectTransform))]

public class DrawMesh : Graphic
{
    // Start is called before the first frame update
    Vector2[] pos = new Vector2[4];
    bool flag = false;
    Vector3 test = new Vector3();
    void Update(){
        if(MainCursolCanvas.cursolFlag){
            SetVerticesDirty();
        }
        
    }
    
    protected override void OnPopulateMesh(VertexHelper vh)
    {   
        vh.Clear();
        //vh.AddTriangle(0,1,2);
        for(int i = 0; i < 4; i ++){
            pos[i] = WorldspaceToScreenspace.pos[i];
        }

        // UIVertex:各頂点の情報
        var v0 = new UIVertex();
        //v0.position = pos[0];
        v0.position = pos[0];
        //Debug.Log(pos[3]);
        // 修正箇所 : 色情報追加
        v0.color = new Color32(255, 0, 255, 100);
        var v1 = new UIVertex();
        v1.position = pos[1];
        // 修正箇所 : 色情報追加
        v1.color = new Color32(255, 255, 255, 100);
        var v2 = new UIVertex();
        v2.position = pos[2];
        // 修正箇所 : 色情報追加
        v2.color = new Color32(255, 255, 0, 100);
        var v3 = new UIVertex();
        v3.position = pos[3];
        // 修正箇所 : 色情報追加
        v3.color = new Color32(255, 255, 0, 100);
        // 頂点情報を渡す
        vh.AddVert(v0);
        vh.AddVert(v1);
        vh.AddVert(v2);
        vh.AddVert(v3);
        vh.AddTriangle(0,1,2);
        vh.AddTriangle(1,3,2);
    }

    private void AddVert(VertexHelper vh, Vector2 pos)
    {
        var vert = UIVertex.simpleVert;
        vert.position = pos;
        vert.color = color;
        vh.AddVert(vert);
    }
}
