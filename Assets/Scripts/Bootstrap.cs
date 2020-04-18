using Buildings;
using Resources;
using TMPro;
using UnityEngine;

public class Bootstrap : MonoBehaviour {
    // TODO: Move this to Resource Bootstrap
    [SerializeField] private TextMeshProUGUI resourcePrefab;
    [SerializeField] private Transform resourceParent;

    // TODO: Move to Buildings Bootstrap
    [SerializeField] private BuildingButton buildingButtonPrefab;
    [SerializeField] private Transform buildingButtonParent;

    private void Start() {
        // GameSave gameSave = DataLoader.LoadOrCreateGame();
        GameSave gameSave = new GameSave(new ResourceManager(new[] {new Resource("Food", 0, 10, 0.1f, true)}),
                                         new BuildingManager(new Building[0]));

        ResourceVisual resourceVisual = new ResourceVisual(gameSave.GetResourceManager, resourcePrefab, resourceParent);

        // TODO: Remove having a copy. Best would be to have it static all the way
        BuildingEffectManager buildingEffectManager = new BuildingEffectManager(gameSave.GetResourceManager);

        BuildingVisual buildingVisual = new BuildingVisual(gameSave.GetBuildingManager, gameSave.GetResourceManager,
                                                           buildingButtonPrefab, buildingButtonParent);
    }
}