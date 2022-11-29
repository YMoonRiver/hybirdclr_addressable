using System.IO;
using UnityEditor;
using UnityEditor.U2D;
using UnityEngine;
using UnityEngine.U2D;

/// <summary>
/// ѡ��ͼ���ļ���
/// </summary>
public class AutoSetAtlasContent : Editor
{
    [MenuItem("Tools/AutoSetAtlas _F3")]
    static void AutoSetAtlasContents()
    {
        var arr = Selection.GetFiltered(typeof(DefaultAsset), SelectionMode.Assets);
        string folder = AssetDatabase.GetAssetPath(arr[0]);
        DirectoryInfo dirInfo = new DirectoryInfo(folder);
        if (!Directory.Exists(folder))
        {
            Debug.LogError("������Ŀ¼");
            return;
        }
        string _texturePath = folder;
        string atlasName = dirInfo.Name;
        string _atlasPath = $"Assets/Addressable/Res/Atlas/{atlasName}.spriteatlas";

        SpriteAtlas atlas = new SpriteAtlas();
        // ���ò��� �ɸ�����Ŀ���������������
        SpriteAtlasPackingSettings packSetting = new SpriteAtlasPackingSettings()
        {
            blockOffset = 1,
            enableRotation = false,
            enableTightPacking = false,
            padding = 2,
        };
        atlas.SetPackingSettings(packSetting);

        SpriteAtlasTextureSettings textureSetting = new SpriteAtlasTextureSettings()
        {
            readable = false,
            generateMipMaps = false,
            sRGB = true,
            filterMode = FilterMode.Bilinear,
        };
        atlas.SetTextureSettings(textureSetting);

        TextureImporterPlatformSettings textureImporterPlatformSettings = new TextureImporterPlatformSettings
        {
            name = "Standalone",
            maxTextureSize = 2048,
            format = TextureImporterFormat.DXT5
        };
        atlas.SetPlatformSettings(textureImporterPlatformSettings);
        textureImporterPlatformSettings = new TextureImporterPlatformSettings
        {
            name = "iPhone",
            maxTextureSize = 2048,
            format = TextureImporterFormat.ASTC_HDR_4x4,
            overridden = true,
        };
        atlas.SetPlatformSettings(textureImporterPlatformSettings);
        textureImporterPlatformSettings = new TextureImporterPlatformSettings
        {
            name = "Android",
            maxTextureSize = 2048,
            format = TextureImporterFormat.ETC2_RGBA8,
            overridden = true,
        };
        atlas.SetPlatformSettings(textureImporterPlatformSettings);

        AssetDatabase.CreateAsset(atlas, _atlasPath);

        //// 1������ļ�
        //DirectoryInfo dir = new DirectoryInfo(_texturePath);
        //// ������ʹ�õ���pngͼƬ���Ѿ�����Sprite������
        //FileInfo[] files = dir.GetFiles("*.png");
        //foreach (FileInfo file in files)
        //{
        //    atlas.Add(new[] { AssetDatabase.LoadAssetAtPath<Sprite>($"{_texturePath}/{file.Name}") });
        //}

        // 2������ļ���
        Object obj = AssetDatabase.LoadAssetAtPath(_texturePath, typeof(Object));
        atlas.Add(new[] { obj });

        AssetDatabase.SaveAssets();
    }

    public static string FormatFilePath(string filePath)
    {
        var path = filePath.Replace('\\', '/');
        path = path.Replace("//", "/");
        return path;
    }
}