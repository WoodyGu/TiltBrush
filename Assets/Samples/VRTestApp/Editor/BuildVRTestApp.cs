// "WaveVR SDK
// © 2017 HTC Corporation. All Rights Reserved.
//
// Unless otherwise required by copyright law and practice,
// upon the execution of HTC SDK license agreement,
// HTC grants you access to and use of the WaveVR SDK(s).
// You shall fully comply with all of HTC’s SDK license agreement terms and
// conditions signed by you and all SDK and API requirements,
// specifications, and documentation provided by HTC to You."

using UnityEngine;
using UnityEditor;

public class BuildVRTestApp
{
    private static void GeneralSettings()
    {
        PlayerSettings.Android.bundleVersionCode = 1;
        PlayerSettings.bundleVersion = "2.0.0";
        PlayerSettings.companyName = "HTC Corp.";
        PlayerSettings.defaultInterfaceOrientation = UIOrientation.LandscapeLeft;
        PlayerSettings.Android.minSdkVersion = AndroidSdkVersions.AndroidApiLevel22;
    }

    [UnityEditor.MenuItem("WaveVR/Build Android APK/Build wvr_unity_vrtestapp.apk")]
    static void BuildApk()
    {
        BuildApk(null, false);
    }

    [UnityEditor.MenuItem("WaveVR/Build Android APK/Build+Run wvr_unity_vrtestapp.apk")]
    static void BuildAndRunApk()
    {
        BuildApk(null, true);
    }

    public static void BuildApk(string destPath, bool run)
    {
        string[] levels = {
            "Assets/Samples/VRTestApp/scenes/VRTestApp.unity",
            "Assets/Samples/SeaOfCube/scenes/Main.unity",
            "Assets/Samples/SeaOfCube/scenes/Main_Help.unity",
            "Assets/Samples/SeaOfCube/scenes/SeaOfCubeWithTwoHead.unity",
            "Assets/Samples/SeaOfCube/scenes/SeaOfCubeWithTwoHead_Help.unity",
            "Assets/Samples/CameraTexture_Test/scenes/CameraTexture_Test.unity",
            "Assets/Samples/PermissionMgr_Test/scenes/PermissionMgr_Test.unity",
            "Assets/Samples/MotionController_Test/Scenes/MotionController_Test.unity",
            "Assets/Samples/ControllerInputMode_Test/ControllerInputMode_Test.unity",
            "Assets/Samples/ControllerInputModule_Test/scenes/VRInputModule_Test.unity",
            "Assets/Samples/ControllerInputModule_Test/scenes/MouseInputModule_Test.unity",
            "Assets/Samples/InAppRecenter_Test/scene/InAppRecenter.unity",
            "Assets/Samples/Battery_Test/Scenes/Battery_Test.unity",
            "Assets/Samples/PassengerMode_Test/scenes/PassengerMode_Test.unity",
            "Assets/Samples/InteractionMode_Test/scene/InteractionMode_Test.unity",
            "Assets/Samples/Resource2_Test/Scenes/Resource_Test1.unity",
            "Assets/Samples/Resource2_Test/Scenes/Resource_Test1_Help.unity",
            "Assets/Samples/Resource2_Test/Scenes/Resource_Test2.unity",
            "Assets/Samples/Resource2_Test/Scenes/Resource_Test2_Help.unity",
            "Assets/Samples/ScreenShot_Test/Scenes/ScreenShot_Test.unity",
            "Assets/Samples/RenderModel_Test/scenes/RenderModel_test.unity",
            "Assets/Samples/RenderModel_Test/scenes/RenderModel_scene2.unity",
            "Assets/Samples/RenderModel_Test/scenes/RenderModel_test_Help.unity",
            "Assets/Samples/ControllerInstanceMgr_Test/scenes/ControllerInstanceSence_test1.unity",
            "Assets/Samples/ControllerInstanceMgr_Test/scenes/ControllerInstanceSence_test2.unity",
            "Assets/Samples/ControllerInstanceMgr_Test/scenes/ControllerInstanceSence_test1_Help.unity",
            "Assets/Samples/ControllerTips_Test/Scenes/ControllerTips_Test.unity",
            "Assets/Samples/ControllerTips_Test/Scenes/ControllerTips_Test2.unity",
            "Assets/Samples/ControllerTips_Test/Scenes/ControllerTips_Test_Help.unity",
            "Assets/Samples/RenderMask_Test/Scene/RenderMask_Test.unity",
            "Assets/Samples/Teleport_Test/Scenes/Teleport_Test.unity",
            "Assets/Samples/Button_Test/Scenes/Button_Test.unity"
        };
        BuildApkInner(destPath, run, levels);
    }

    // Independent this function because the command-line need run this eariler than buildApk to take effect.
    [UnityEditor.MenuItem("WaveVR/Build Android APK/Apply VRTestApp PlayerSettings", priority = 0)]
    static void ApplyVRTestAppPlayerSettings()
    {
        Debug.Log("ApplyVRTestAppPlayerSettings");

        GeneralSettings();

        PlayerSettings.productName = "VRTestApp";

#if UNITY_5_6_OR_NEWER
        PlayerSettings.SetApplicationIdentifier(BuildTargetGroup.Android, "com.vrm.unity.VRTestApp");
#else
        PlayerSettings.bundleIdentifier = "com.vrm.unity.VRTestApp";
#endif
        Texture2D icon = (Texture2D)AssetDatabase.LoadAssetAtPath("Assets/Samples/VRTestApp/Textures/test.png", typeof(Texture2D));
        if (icon == null)
            Debug.LogError("Fail to read app icon");

        Texture2D[] group = { icon, icon, icon, icon, icon, icon };

        PlayerSettings.SetIconsForTargetGroup(BuildTargetGroup.Android, group);
        PlayerSettings.gpuSkinning = false;
#if UNITY_2017_2_OR_NEWER
        PlayerSettings.SetMobileMTRendering(BuildTargetGroup.Android, true);
#else
        PlayerSettings.mobileMTRendering = true;
#endif
        PlayerSettings.graphicsJobs = true;

        // This can help check the Settings by text editor
        EditorSettings.serializationMode = SerializationMode.ForceText;

        // Enable VR support and singlepass
        WaveVR_Settings.SetVirtualRealitySupported(BuildTargetGroup.Android, true);
        var list = WaveVR_Settings.GetVirtualRealitySDKs(BuildTargetGroup.Android);
        if (!ArrayUtility.Contains<string>(list, "split"))
        {
            ArrayUtility.Insert<string>(ref list, 0, "split");
        }
        WaveVR_Settings.SetVirtualRealitySDKs(BuildTargetGroup.Android, list);
        PlayerSettings.stereoRenderingPath = StereoRenderingPath.SinglePass;
        var symbols = WaveVR_Settings.GetDefineSymbols(BuildTargetGroup.Android);
        WaveVR_Settings.SetSinglePassDefine(BuildTargetGroup.Android, true, symbols);

        // Force use GLES31
        PlayerSettings.SetUseDefaultGraphicsAPIs(BuildTarget.Android, false);
        UnityEngine.Rendering.GraphicsDeviceType[] apis = { UnityEngine.Rendering.GraphicsDeviceType.OpenGLES3 };
        PlayerSettings.SetGraphicsAPIs(BuildTarget.Android, apis);
        PlayerSettings.openGLRequireES31 = true;
        PlayerSettings.openGLRequireES31AEP = true;

#if UNITY_2018_1_OR_NEWER && EXPERIMENTAL_FEATURE
        // Force use IL2CPP
        PlayerSettings.SetScriptingBackend(BuildTargetGroup.Android, ScriptingImplementation.IL2CPP);
        PlayerSettings.scriptingRuntimeVersion = ScriptingRuntimeVersion.Latest;
        PlayerSettings.SetIl2CppCompilerConfiguration(BuildTargetGroup.Android, Il2CppCompilerConfiguration.Release);
        PlayerSettings.Android.targetArchitectures = AndroidArchitecture.ARMv7;
#endif

        PlayerSettings.Android.minSdkVersion = AndroidSdkVersions.AndroidApiLevel25;
        PlayerSettings.Android.targetSdkVersion = AndroidSdkVersions.AndroidApiLevel25;

        AssetDatabase.SaveAssets();
    }

    private static void BuildApkInner(string destPath, bool run, string[] levels)
    {
        var apkName = "wvr_unity_vrtestapp.apk";
        ApplyVRTestAppPlayerSettings();

        string outputFilePath = string.IsNullOrEmpty(destPath) ? apkName : destPath + "/" + apkName;
        BuildPipeline.BuildPlayer(levels, outputFilePath, BuildTarget.Android, run ? BuildOptions.AutoRunPlayer : BuildOptions.None);
    }
}
