using UnityEditor;
using UnityEngine;
using System;
using System.IO;

namespace MiniUnityChan
{

class View
{
	UnityEngine.Object[] sprites;
	public View(string spriteName)
	{
		LoadSprite(spriteName);
	}

	private void LoadSprite(string spriteName)
	{
		var spritePath = new Uri(Directory.GetFiles(Application.dataPath, spriteName, SearchOption.AllDirectories)[0]);
		var projectRootPath = new Uri(Application.dataPath);
		var relativeUri = projectRootPath.MakeRelativeUri(spritePath);
		sprites = AssetDatabase.LoadAllAssetRepresentationsAtPath(relativeUri.ToString());
	}

	public Sprite CurrentSprite
	{
		get
		{
			return (Sprite)sprites[2];
		}
	}
}

}
