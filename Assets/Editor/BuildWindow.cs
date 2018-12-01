using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class TestWindow : EditorWindow
{
    [MenuItem("Tools/Build AssetBundles")]
    private static void Open()
    {
        TestWindow test = GetWindow<TestWindow>();
        test.Show();
    }

    private void OnGUI()
    {
        EditorGUILayout.BeginVertical();

        EditorGUILayout.BeginHorizontal();
        GUILayout.Label("打包规则");
        GUILayout.Label("输出目录");
        EditorGUILayout.EndHorizontal();

        var rules = BuildManager.GetBuildRules();
        foreach (var item in rules)
        {
            EditorGUILayout.BeginHorizontal();

            var strPatten = "/";
            foreach (var patten in item.pattens)
            {
                strPatten += "*" + patten + ",";
            }
            GUILayout.TextField(item.inPut + strPatten);

            GUILayout.TextField(item.outPut);

            EditorGUILayout.EndHorizontal();
        }

        GUILayout.Label("");

        EditorGUILayout.BeginHorizontal();
        if (GUILayout.Button("Mark"))
        {
            Mark();
        }

        if (GUILayout.Button("ReloadRole"))
        {
            BuildManager.GetBuildRules(true);
        }

        EditorGUILayout.EndHorizontal();

        if (GUILayout.Button("Build"))
        {
            Build();
        }

        EditorGUILayout.EndVertical();
    }

    private static void Mark()
    {
        var rules = BuildManager.GetBuildRules();
        foreach (var rule in rules)
        {
            var path = Application.dataPath + "/Resources/" + rule.inPut;
            var files = BuildManager.GetAllFiles(path, rule.pattens);

            foreach (var file in files)
            {
                var filePath = "Assets/Resources/" + rule.inPut + "/" + file;
                var importer = AssetImporter.GetAtPath(filePath);
                if (importer != null)
                {
                    importer.assetBundleName = file.Split('.')[0];
                }
            }

            Debug.Log("[BuildManager] Mark Asstebundle success!");
        }
    }

    private static void Build()
    {
        BuildPipeline.BuildAssetBundles(@"E:\Unity2017Work\Lemon\Lemon_assetsdata\model",
          BuildAssetBundleOptions.ChunkBasedCompression, BuildTarget.StandaloneWindows64);

        Debug.Log("[BuildManager] Build Asstebundle success!");
    }
}
