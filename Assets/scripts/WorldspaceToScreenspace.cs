using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WorldspaceToScreenspace : MonoBehaviour
{

    //RectTransform rectTransform = null;
	[SerializeField] Transform target = null;

	[SerializeField]
	Canvas canvas;
    Vector3[] positions = new Vector3[4];

    //Vector3 positions;
    public static Vector2[] pos = new Vector2[4]{Vector2.zero, Vector2.zero, Vector2.zero, Vector2.zero};
        
	void Awake()
	{
		//rectTransform = GetComponent<RectTransform> ();
		canvas = GetComponent<Graphic> ().canvas;
	}

	void Update ()
	{
		Vector3[] screenPos = new Vector3[4];
		var uiCamera = Camera.main;
		var worldCamera = Camera.main;
		var canvasRect = canvas.GetComponent<RectTransform> ();

        positions[0].y = target.position.y + 3;
        positions[0].z = target.position.z + 3;
        positions[1].y = target.position.y - 3;
        positions[1].z = target.position.z + 3;
        positions[2].y = target.position.y + 3;
        positions[2].z = target.position.z - 3;
        positions[3].y = target.position.y - 3;
        positions[3].z = target.position.z - 3;
        
        for(int i = 0; i < 4; i ++){
            positions[i].x = target.position.x;
            screenPos[i] = RectTransformUtility.WorldToScreenPoint (worldCamera, positions[i]);
            RectTransformUtility.ScreenPointToLocalPointInRectangle(canvasRect, screenPos[i], uiCamera, out pos[i]);
        }
		
		
		//rectTransform.localPosition = pos[0];
        
	}
}
