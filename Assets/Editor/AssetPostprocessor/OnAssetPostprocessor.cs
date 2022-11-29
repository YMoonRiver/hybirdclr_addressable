using UnityEditor;
using UnityEngine;
/// <summary>
/// ��Դ����Ԥ����
/// </summary>
public class OnAssetPostprocessor : AssetPostprocessor
{
    void OnPreprocessTexture()
    {
        TextureImporter textureImporter = (TextureImporter)assetImporter;
        
        if (textureImporter.assetPath.Contains("/UI/"))
        {
            Debug.LogWarning("UI");
            textureImporter.textureType = TextureImporterType.Sprite;
            textureImporter.mipmapEnabled = false;
            TextureImporterPlatformSettings textureImporterPlatformSettings = new TextureImporterPlatformSettings
            {
                name = "Standalone",
                maxTextureSize = 2048,
                format = TextureImporterFormat.RGBA32
            };
            textureImporter.SetPlatformTextureSettings(textureImporterPlatformSettings);
            textureImporterPlatformSettings = new TextureImporterPlatformSettings
            {
                name = "iPhone",
                maxTextureSize = 2048,
                format = TextureImporterFormat.RGBA32,
                overridden = true,
                compressionQuality = 100,
            };
            textureImporter.SetPlatformTextureSettings(textureImporterPlatformSettings);
            textureImporterPlatformSettings = new TextureImporterPlatformSettings
            {
                name = "Android",
                maxTextureSize = 2048,
                format = TextureImporterFormat.RGBA32,
                overridden = true,
            };
            textureImporter.SetPlatformTextureSettings(textureImporterPlatformSettings);
        }else if (textureImporter.assetPath.Contains("/RawImage/"))
        {
            textureImporter.textureType = TextureImporterType.Default;
            textureImporter.mipmapEnabled = true;
            TextureImporterPlatformSettings textureImporterPlatformSettings = new TextureImporterPlatformSettings
            {
                name = "Standalone",
                maxTextureSize = 2048,
                format = TextureImporterFormat.DXT5
            };
            textureImporter.SetPlatformTextureSettings(textureImporterPlatformSettings);
            textureImporterPlatformSettings = new TextureImporterPlatformSettings
            {
                name = "iPhone",
                maxTextureSize = 2048,
                format = TextureImporterFormat.ASTC_HDR_4x4,
                overridden = true,
            };
            textureImporter.SetPlatformTextureSettings(textureImporterPlatformSettings);
            textureImporterPlatformSettings = new TextureImporterPlatformSettings
            {
                name = "Android",
                maxTextureSize = 2048,
                format = TextureImporterFormat.ETC_RGB4,
                overridden = true,
            };
            textureImporter.SetPlatformTextureSettings(textureImporterPlatformSettings);
        }
    }

    static void OnPostprocessAllAssets(string[] importedAssets, string[] deletedAssets, string[] movedAssets, string[] movedFromAssetPaths)
    {
        foreach (var item in importedAssets)
        {
            Debug.LogFormat("�µ�����Դ��{0}", item);
        }

        foreach (var item in deletedAssets)
        {
            Debug.LogFormat("ɾ������Դ��{0}", item);
        }

        for (int i = 0; i < movedAssets.LongLength; i++)
        {
            Debug.LogFormat("�ƶ���Դ��Դ��from:{0} \nto:{1}", movedFromAssetPaths[i], movedAssets[i]);
        }
    }
}
