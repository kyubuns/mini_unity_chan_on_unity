using UnityEditor;
using UnityEngine;
using System;
using System.IO;
using System.Collections.Generic;

namespace MiniUnityChan
{

class View
{
	/*
	 * Settings
	 */
	static readonly string[] normalAnimation =
	{
		"UnityChan_footwork_0",
		"UnityChan_footwork_1",
		"UnityChan_footwork_2",
	};
	static readonly string[] playingAnimation =
	{
		"UnityChan_run_0",
		"UnityChan_run_1",
		"UnityChan_run_2",
		"UnityChan_run_3",
		"UnityChan_run_4",
		"UnityChan_run_5",
		"UnityChan_run_6",
		"UnityChan_run_7",
	};
	static readonly string[] compilingAnimation =
	{
		"UnityChan_jump_up_0",
		"UnityChan_jump_up_1",
	};
	static readonly string[] pausingAnimation =
	{
		"UnityChan_run_0",
	};
	static readonly double oneFrame = 0.4; // 1フレームの秒数

	// ===========
	
	Dictionary<string, Sprite> sprites;
	double switchTime = 0.0;
	string cachedSpriteName;

	public View(string spriteName)
	{
		LoadSprite(spriteName);
	}

	private void LoadSprite(string spriteName)
	{
		var spritePath = new Uri(Directory.GetFiles(Application.dataPath, spriteName, SearchOption.AllDirectories)[0]);
		var projectRootPath = new Uri(Application.dataPath);
		var relativeUri = projectRootPath.MakeRelativeUri(spritePath);
		var loadSprite = AssetDatabase.LoadAllAssetRepresentationsAtPath(relativeUri.ToString());

		sprites = new Dictionary<string, Sprite>();
		foreach(Sprite sprite in loadSprite) sprites[sprite.name] = sprite;
	}

	private string[] GetAnimation()
	{
		if(EditorApplication.isPlaying && EditorApplication.isPaused) return pausingAnimation;
		else if(EditorApplication.isPlaying)   return playingAnimation;
		else if(EditorApplication.isCompiling) return compilingAnimation;
		return normalAnimation;
	}

	private string CalcSpriteName(string[] animation)
	{
		var currentTime = EditorApplication.timeSinceStartup;
		var cachedSpriteIndex = Array.IndexOf(animation, cachedSpriteName);
		var containtsCachedSpriteName = (cachedSpriteIndex != -1);
		if((switchTime + oneFrame > currentTime) && containtsCachedSpriteName) return cachedSpriteName;

		if(containtsCachedSpriteName)
		{
			var index = cachedSpriteIndex + 1;
			if(index >= animation.Length) index -= animation.Length;
			cachedSpriteName = animation[index];
		}
		else
		{
			cachedSpriteName = animation[0];
		}
		switchTime = currentTime;
		return cachedSpriteName;
	}

	public Sprite CurrentSprite
	{
		get
		{
			return sprites[CalcSpriteName(GetAnimation())];
		}
	}
}

}
