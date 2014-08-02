using UnityEditor;
using UnityEngine;
using System;

/*
[InitializeOnLoad]
class Hoge
{
	static Type hierarchyWindowType;
	static UnityEngine.Object[] allSprites;
	static EditorWindow hierarchyWindow;

	static Hoge()
	{
		var assembly = typeof(UnityEditor.EditorWindow).Assembly;
		hierarchyWindowType = assembly.GetType("UnityEditor.SceneHierarchyWindow");

		allSprites = AssetDatabase.LoadAllAssetRepresentationsAtPath("Assets/Macaroni/Editor/Image/UnityChan.png");
		GetHierarchyWindow();

		EditorApplication.hierarchyWindowItemOnGUI += HierarchyItem;
		EditorApplication.update += Update;
	}

	static void GetHierarchyWindow()
	{
		var hierarchyWindows = Resources.FindObjectsOfTypeAll(hierarchyWindowType);
		if(hierarchyWindows.Length == 0) return;
		hierarchyWindow = (EditorWindow)hierarchyWindows[0];
	}

	static void HierarchyItem(int instanceID, Rect selectionRect)
	{
		Draw();
	}

	static void Update()
	{
		EditorApplication.RepaintHierarchyWindow();
	}

	static int i = 0;
	static void Draw()
	{
		if(hierarchyWindow == null) return;

		// spriteの描画
		i++;
		int frame = (i/100)%3;
		var sprite = allSprites[2+frame] as Sprite;
		Debug.Log(sprite.name);

		Texture t = sprite.texture;
		Rect tr = sprite.textureRect;
		Rect r = new Rect(tr.x / t.width, tr.y / t.height, tr.width / t.width, tr.height / t.height );
		Rect position = new Rect(hierarchyWindow.position.width , hierarchyWindow.position.height - tr.height - 10 , -tr.width, tr.height);
		GUI.DrawTextureWithTexCoords(position, t, r);
		Debug.Log("draw");
	}
}
*/
