using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEditor;  // Required for AssetDatabase
using View;
using Utilities;

public class BoardSpaceTests
{
    private GameObject colorPicker;
    private GameObject boardSpace;

    [SetUp]
    public void SetUpScene()
    {
        // Load prefabs using AssetDatabase
        colorPicker = Object.Instantiate(AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Prefabs/ColorPicker.prefab"));
        boardSpace = Object.Instantiate(AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Prefabs/BoardSpace.prefab"));
    }

    [TearDown]
    public void TearDownScene()
    {
        Object.Destroy(colorPicker);
        Object.Destroy(boardSpace);
    }

    [UnityTest]
    public IEnumerator TestSpaceStateChange()
    {
        MeshRenderer meshRenderer = boardSpace.GetComponent<MeshRenderer>(); 
        
        boardSpace.GetComponent<BoardSpace>().SpaceState = Utilities.GlobalConstants.SpaceStates.Empty;

        yield return null;

        Assert.IsFalse(meshRenderer.enabled, "Problem with setting space to Empty.");

        boardSpace.GetComponent<BoardSpace>().SpaceState = Utilities.GlobalConstants.SpaceStates.Highlighted;

        yield return null;

        Assert.IsTrue(meshRenderer.enabled, "Problem with setting space to Highlighted");
        Assert.IsTrue(meshRenderer.materials[0].color == Utilities.ColorPicker.Instance.HighlightColor, "Problem with setting space to Highlighted");

        boardSpace.GetComponent<BoardSpace>().SpaceState = Utilities.GlobalConstants.SpaceStates.Player2Piece;

        yield return null;

        Assert.IsTrue(meshRenderer.enabled, "Problem with setting space to Player2Piece");
        Assert.IsTrue(meshRenderer.materials[0].color == Utilities.ColorPicker.Instance.Player2Color, "Problem with setting space to Player2Piece");

        boardSpace.GetComponent<BoardSpace>().SpaceState = Utilities.GlobalConstants.SpaceStates.Player5Piece;

        yield return null;

        Assert.IsTrue(meshRenderer.enabled, "Problem with setting space to Player5Piece");
        Assert.IsTrue(meshRenderer.materials[0].color == Utilities.ColorPicker.Instance.Player5Color, "Problem with setting space to Player5Piece");
    }
}
