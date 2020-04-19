using System;

namespace Buildings {
    [Serializable]
    public class Building {
        private int amount;
        private BuildingCost[] costs;
        private string description;
        private BuildingEffect[] effects;
        private bool enabled;
        private string name;

        public Action onBuild;
        public Action onCostUpdated;
        public Action onEffectsUpdated;
        private bool unlocked;

        public Building(string name, string description, BuildingCost[] costs, BuildingEffect[] effects, int amount = 0,
                        bool enabled = true, bool unlocked = false) {
            this.name = name;
            this.description = description;
            this.costs = costs;
            this.effects = effects;
            this.amount = amount;
            this.enabled = enabled;
            this.unlocked = unlocked;
        }

        public void Build(int amount = 1) {
            this.amount += amount;
            ApplyBuildingEffects();
            onBuild?.Invoke();
        }

        public void Remove(int amount = 1) {
            this.amount -= amount;
            RemoveBuildingEffects();
            onBuild?.Invoke();
        }

        public void Unlock() {
            unlocked = true;
            onBuild?.Invoke();
        }

        public void SetEnabled(bool enabled) {
            this.enabled = enabled;
            onBuild?.Invoke();
        }

        public void SetCost(BuildingCost[] costs) {
            this.costs = costs;
            onCostUpdated?.Invoke();
        }

        public void SetEffects(BuildingEffect[] effects) {
            this.effects = effects;
            onEffectsUpdated?.Invoke();
        }

        public string GetName() {
            return name;
        }

        public string GetDescription() {
            return description;
        }

        public BuildingCost[] GetCosts() {
            return costs;
        }

        public BuildingEffect[] GetEffects() {
            return effects;
        }

        public int GetAmount() {
            return amount;
        }

        public bool IsEnabled() {
            return enabled;
        }

        public bool IsUnlocked() {
            return unlocked;
        }

        private void ApplyBuildingEffects() {
            BuildingEffectManager.Instance.ApplyEffects(effects);
        }

        private void RemoveBuildingEffects() {
            BuildingEffectManager.Instance.RemoveEffects(effects);
        }
    }
}