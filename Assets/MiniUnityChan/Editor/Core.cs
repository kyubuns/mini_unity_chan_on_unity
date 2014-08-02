using UnityEditor;
using UnityEngine;
using System;

namespace MiniUnityChan
{

[InitializeOnLoad]
class Core
{
	/*
	 * Settings
	 */
	static readonly string spriteName = "UnityChan.png";
	static readonly float offsetX = 0.0f;
	static readonly float offsetY = 10.0f;

	// ===========
	
	static EditorWindow hierarchyWindow;
	static View view;

	static Core()
	{
		view = new View(spriteName);
		EditorApplication.hierarchyWindowItemOnGUI += HierarchyItem;
		EditorApplication.update += Update;
	}

	static EditorWindow GetHierarchyWindow()
	{
		var assembly = typeof(UnityEditor.EditorWindow).Assembly;
		var hierarchyWindowType = assembly.GetType("UnityEditor.SceneHierarchyWindow");

		var hierarchyWindowList = Resources.FindObjectsOfTypeAll(hierarchyWindowType);
		if(hierarchyWindowList.Length == 0) return null;
		return (EditorWindow)hierarchyWindowList[0];
	}

	static void HierarchyItem(int instanceID, Rect selectionRect)
	{
		Draw();
	}

	static void Update()
	{
		EditorApplication.RepaintHierarchyWindow();
	}

	static void Draw()
	{
		if(hierarchyWindow == null)
		{
			hierarchyWindow = GetHierarchyWindow();
			if(hierarchyWindow == null) return;
		}

		// spriteの描画
		var sprite = view.CurrentSprite;
		if(sprite == null) return;

		Texture texture = sprite.texture;
		Rect textureRect = sprite.textureRect;
		Rect r = new Rect
			(
			 textureRect.x / texture.width,
			 textureRect.y / texture.height,
			 textureRect.width / texture.width,
			 textureRect.height / texture.height
			 );
		Rect position = new Rect
			(
			 hierarchyWindow.position.width - offsetX,
			 hierarchyWindow.position.height - textureRect.height - offsetY,
			 -textureRect.width,
			 textureRect.height
			);
		GUI.DrawTextureWithTexCoords(position, texture, r);
	}
}
}
