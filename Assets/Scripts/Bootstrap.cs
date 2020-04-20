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
        GameSave gameSave = new GameSave(new ResourceData(new[] {
                                                 new Resource("Food", 0, 10, 0, true), 
                                                 new Resource("Wood")
                                         }),
                                         new BuildingData(new[] {
                                                 new Building("Farm", "Produces food", new BuildingCost[0],
                                                              new BuildingEffect[] {
                                                                      new IncreaseProduction(0, 1)}, 0, true, true),
                                                 new Building("Sawmill", "Produces wood", new BuildingCost[0],
                                                              new BuildingEffect[0])
                                         }));

        ResourceManager resourceManager = new ResourceManager(gameSave.resourceData);
        ResourceVisual resourceVisual = new ResourceVisual(resourceManager, resourcePrefab, resourceParent);

        // TODO: Remove having a copy. Best would be to have it static all the way
        BuildingEffectManager buildingEffectManager = new BuildingEffectManager(resourceManager);

        BuildingManager buildingManager = new BuildingManager(gameSave.buildingData);
        BuildingVisual buildingVisual = new BuildingVisual(buildingManager, resourceManager,
                                                           buildingButtonReferencePrefab, buildingButtonParent);
    }
}