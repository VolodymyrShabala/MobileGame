using Buildings;
using Buildings.BuildingButton;
using Buildings.BuildingEffects;
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
        // GameSave gameSave = DataLoader.LoadOrCreateGame();
        GameSave gameSave =
                new GameSave(new ResourceManager(new[] {new Resource("Food", 0, 10, 0, true), new Resource("Wood")}),
                             new BuildingManager(new[] {
                                     new Building("Farm", "Produces food", new BuildingCost[0],
                                                  new BuildingEffect[] {new IncreaseProduction(0, 0.1f)}, 0, true,
                                                  true),
                                     new Building("Sawmill", "Produces wood", new[] {new BuildingCost(0, 10)},
                                                  new BuildingEffect[] {new IncreaseProduction(1, 1)})
                             }));

        ResourceVisual resourceVisual = new ResourceVisual(gameSave.GetResourceManager, resourcePrefab, resourceParent);

        // TODO: Remove having a copy. Best would be to have it static all the way
        BuildingEffectManager buildingEffectManager = new BuildingEffectManager(gameSave.GetResourceManager);

        BuildingVisual buildingVisual = new BuildingVisual(gameSave.GetBuildingManager, gameSave.GetResourceManager,
                                                           buildingButtonReferencePrefab, buildingButtonParent);
    }
}