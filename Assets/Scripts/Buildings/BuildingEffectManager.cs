using UnityEngine;
using Resources;

namespace Buildings {
    // TODO: I don't like how I did it here. Look more into how to write this better
    public class BuildingEffectManager {
        private readonly ResourceManager resourceManager;

        public BuildingEffectManager(ResourceManager resourceManager) {
            this.resourceManager = resourceManager;
        }

        public void ApplyEffects(BuildingEffect[] effects) {
            int length = effects.Length;

            for (int i = 0; i < length; i++) {
                BuildingEffectType buildingEffectType = effects[i].effectType;

                switch (buildingEffectType) {
                    case BuildingEffectType.None:
                        break;
                    case BuildingEffectType.UnlockResource:
                        resourceManager.UnlockResource(effects[i].resourceIndex);
                        break;
                    case BuildingEffectType.ProduceResource:
                        resourceManager.IncreaseProduction(effects[i].resourceIndex, effects[i].amount);
                        break;
                    case BuildingEffectType.ConsumeResource:
                        resourceManager.DecreaseProduction(effects[i].resourceIndex, effects[i].amount);
                        break;
                    case BuildingEffectType.IncreaseResourceProduction:
                        resourceManager.IncreaseProduction(effects[i].resourceIndex, effects[i].amount);
                        break;
                    case BuildingEffectType.DecreaseResourceProduction:
                        resourceManager.DecreaseProduction(effects[i].resourceIndex, effects[i].amount);
                        break;
                    case BuildingEffectType.DecreaseResourceConsumption:
                        resourceManager.IncreaseProduction(effects[i].resourceIndex, effects[i].amount);
                        break;
                    case BuildingEffectType.IncreasePopulation:
                        break;
                    case BuildingEffectType.IncreaseResourceStorage:
                        resourceManager.IncreaseStorage(effects[i].resourceIndex, effects[i].amount);
                        break;
                    case BuildingEffectType.BoostBuildingProduction: // TODO: Fill in later
                        break;
                    default:
                        Debug.LogError($"Wrong Building Effect Type is passed to BuildingEffectManager.ApplyEffects.");
                        break;
                }
            }
        }

        public void RemoveEffects(BuildingEffect[] effects) {
            int length = effects.Length;

            for (int i = 0; i < length; i++) {
                BuildingEffectType buildingEffectType = effects[i].effectType;

                switch (buildingEffectType) {
                    case BuildingEffectType.ProduceResource:
                        resourceManager.DecreaseProduction(effects[i].resourceIndex, effects[i].amount);
                        break;
                    case BuildingEffectType.ConsumeResource:
                        resourceManager.IncreaseProduction(effects[i].resourceIndex, effects[i].amount);
                        break;
                    case BuildingEffectType.IncreaseResourceProduction:
                        resourceManager.DecreaseProduction(effects[i].resourceIndex, effects[i].amount);
                        break;
                    case BuildingEffectType.DecreaseResourceProduction:
                        resourceManager.IncreaseProduction(effects[i].resourceIndex, effects[i].amount);
                        break;
                    case BuildingEffectType.DecreaseResourceConsumption:
                        resourceManager.DecreaseProduction(effects[i].resourceIndex, effects[i].amount);
                        break;
                    case BuildingEffectType.IncreasePopulation:
                        break;
                    case BuildingEffectType.IncreaseResourceStorage:
                        resourceManager.DecreaseStorage(effects[i].resourceIndex, effects[i].amount);
                        break;
                    case BuildingEffectType.BoostBuildingProduction: // TODO: Fill in later
                        break;
                    default:
                        Debug.LogError($"Wrong Building Effect Type is passed to BuildingEffectManager.RemoveEffects.");
                        break;
                }
            }
        }
    }
}