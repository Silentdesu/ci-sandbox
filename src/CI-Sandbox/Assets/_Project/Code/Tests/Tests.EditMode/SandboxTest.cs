using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

namespace Project
{
    public class SandboxTest
    {
        [Test]
        public void WhenLoadSandboxScene_ThenShouldBeListFilledWithGameObjects()
        {
            // arrange
            var gos = new List<GameObject>();
            var scenePath = AssetDatabase.FindAssets("t:Scene", new[] { "Assets" })
                .Select(AssetDatabase.GUIDToAssetPath).ToArray();
            var scene = EditorSceneManager.OpenScene(scenePath[0]);
            
            // act
            gos = Object.FindObjectsOfType<GameObject>().ToList();

            EditorSceneManager.CloseScene(scene, removeScene: true);
            
            // assert
            gos.Should().NotBeEmpty();
        }
    }
}
