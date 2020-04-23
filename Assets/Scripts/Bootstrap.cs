using Buildings;
using Buildings.BuildingButton;
using Resources;
using TMPro;
using UnityEngine;

public class Bootstrap : MonoBehaviour {
    // TODO: Move to Buildings Bootstrap
    [SerializeField] private BuildingButtonReferenceHolder buildingButtonReferencePrefab;
    [SerializeField] private Transform buildingButtonParent;

    // TODO: Move this to Resource Bootstrap
    [SerializeField] private TextMeshProUGUI resourcePrefab;
    [SerializeField] private Transform resourceParent;

    private void Start() {
        GameSave gameSave = DataLoader.LoadOrCreateGame(); // TODO: Change function name. It is misleading

        ResourceManager resourceManager = new ResourceManager(gameSave.resources);
        ResourceVisual resourceVisual = new ResourceVisual(resourceManager, resourcePrefab, resourceParent);

        // TODO: Remove having a copy. Best would be to have it static all the way
        BuildingEffectManager buildingEffectManager = new BuildingEffectManager(resourceManager);

        BuildingManager buildingManager = new BuildingManager(gameSave.buildings, resourceManager);
        BuildingVisual buildingVisual = new BuildingVisual(buildingManager, resourceManager,
                                                           buildingButtonReferencePrefab, buildingButtonParent);
    }
}