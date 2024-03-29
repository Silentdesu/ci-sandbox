#addin nuget:?package=Cake.Unity&version=0.9.0

var target = Argument("target", "Build-Android");

Task("Clean-Artifacts")
    .Does(() =>
{
    CleanDirectory($"./artifacts");
});

Task("Build-PC")
    .IsDependentOn("Clean-Artifacts")
    .Does(() =>
{
    UnityEditor(2022, 3,
        new UnityEditorArguments
        {
            BatchMode = true,
            Quit = true,
            ExecuteMethod = "Project.Editor.Builder.BuildPC",
            BuildTarget = BuildTarget.Win64,
            LogFile = "./artifacts/PC/build.log"
        }, new UnityEditorSettings
        {
            RealTimeLog = true
        });
});

Task("Build-Android")
    .IsDependentOn("Clean-Artifacts")
    .Does(() =>
{
    UnityEditor(2022, 3,
        new UnityEditorArguments
        {
            ProjectPath = "./src/CI-Sandbox",
            BatchMode = true,
            Quit = true,
            ExecuteMethod = "Project.Editor.Builder.BuildAndroid",
            BuildTarget = BuildTarget.Android,
            LogFile = "./artifacts/Android/build.log"
        }, new UnityEditorSettings
        {
            RealTimeLog = true
        });
});


RunTarget(target);