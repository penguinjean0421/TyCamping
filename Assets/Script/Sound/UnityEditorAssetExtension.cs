using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

namespace Default.Scripts.Extension
{
#if UNITY_EDITOR
    public static class UnityEditorAssetExtensions
    {
        /// <summary> ���� �ּ����κ��� Assets�� �����ϴ� ���� ��� ��� </summary>
        public static string GetLocalPath(this DefaultAsset @this)
        {
            var success =
                AssetDatabase.TryGetGUIDAndLocalFileIdentifier(@this, out var guid, out long _);

            if (success)
                return AssetDatabase.GUIDToAssetPath(guid);
            return null;
        }

        /// <summary> ���� �ּ����κ��� ���� ��� ��� </summary>
        public static string GetAbsolutePath(this DefaultAsset @this)
        {
            var path = GetLocalPath(@this);
            if (path == null)
                return null;

            path = path.Substring(path.IndexOf('/') + 1);
            return Application.dataPath + "/" + path;
        }

        /// <summary> ���� �ּ����κ��� DirectoryInfo ��ü ��� </summary>
        public static DirectoryInfo GetDirectoryInfo(this DefaultAsset @this)
        {
            var absPath = GetAbsolutePath(@this);
            return absPath != null ? new DirectoryInfo(absPath) : null;
        }

        public static List<T> LoadAllObjectsInFolder<T>(this DefaultAsset @this) where T : class
        {
            var assets = new List<T>();
            // ���� �� ��� �ڻ��� GUID �迭�� ������
            var assetGUIDs = AssetDatabase.FindAssets("", new[] { GetLocalPath(@this) });

            foreach (var guid in assetGUIDs)
            {
                // GUID�� ��η� ��ȯ
                var assetPath = AssetDatabase.GUIDToAssetPath(guid);
                // �ڻ��� Object Ÿ������ �ε�
                if (AssetDatabase.LoadAssetAtPath<Object>(assetPath) is T tmp) assets.Add(tmp);
            }

            return assets;
        }
    }
#endif
}