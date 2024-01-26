/* MIT License
Copyright (c) 2016 RedBlueGames
*/

using UnityEditor;
using UnityEngine;
using UnityEditor.Build.Reporting;
using System.IO;

public class BuildTool : MonoBehaviour
{
	private const string GAME_NAME = "GGJ24_LettuceStudios";
	[MenuItem("Build/Log Version")]
	public static string Log()
	{
		var v = Git.BuildVersion;
		Debug.Log("Version: " + v);
		return v;
	}
	
	[MenuItem("Build/Build with Version")]
	public static void Build()
	{
		string buildVersion = Git.BuildVersion;
		
		if(string.IsNullOrEmpty(buildVersion))
		{
			Debug.LogError("Error when retriving git version");
			return;
		}
		
		PlayerSettings.bundleVersion = buildVersion;

		string[] scenesToBuild = EditorBuildSettingsScene.GetActiveSceneList(EditorBuildSettings.scenes);
		BuildTarget buildTarget = EditorUserBuildSettings.activeBuildTarget;
		
		string buildPath = 
			"Builds" + Path.DirectorySeparatorChar 
			+ buildTarget + Path.DirectorySeparatorChar 
			+ PlayerSettings.bundleVersion + Path.DirectorySeparatorChar 
			+ GAME_NAME;
			
		BuildOptions buildOptions = BuildOptions.None;

		BuildPlayerOptions buildPlayerOptions = new BuildPlayerOptions
		{
			scenes = scenesToBuild,
			locationPathName = buildPath,
			target = buildTarget,
			options = buildOptions
		};
		

		BuildReport report = BuildPipeline.BuildPlayer(buildPlayerOptions);
		BuildSummary summary = report.summary;

		if (summary.result == BuildResult.Succeeded)
		{
			Debug.Log("Build succeeded: " + summary.totalSize + " bytes");
		}

		if (summary.result == BuildResult.Failed)
		{
			Debug.Log("Build failed");
		}
	}
}