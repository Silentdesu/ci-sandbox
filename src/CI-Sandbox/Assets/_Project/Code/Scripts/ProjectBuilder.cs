using UnityEditor;

namespace Project
{
    public static class ProjectBuilder
    {
        [MenuItem("Tools/Build/💻Windows", priority = 0)]
        public static void BuildPC() =>
            BuildPipeline.BuildPlayer(
                new BuildPlayerOptions()
                {
                    target = BuildTarget.StandaloneWindows64,
                    locationPathName = "../../artifacts/PC/project.exe",
                    scenes = new[] { "Assets/_Project/Level/Scenes/Sandbox.unity" }
                }
            );

        [MenuItem("Tools/Build/🤖Android")]
        public static void BuildAndroid() =>
            BuildPipeline.BuildPlayer(
                new BuildPlayerOptions()
                {
                    target = BuildTarget.Android,
                    locationPathName = "../../artifacts/Android/project.apk",
                    scenes = new[] { "Assets/_Project/Level/Scenes/Sandbox.unity" }
                }
            );
    }
}