using System;

namespace Buildings {
    [Serializable]
    public class Building {
        private string name;
        private string description;
        private BuildingCost[] costs;
        private BuildingEffect[] effects;
        private int amount;
        private bool enabled;
        private bool unlocked;

        public Action onBuild;
        public Action onCostUpdated;
        public Action onEffectsUpdated;
        public Action<bool> onEnable;
        public Action onUnlock;

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
            onUnlock?.Invoke();
        }

        public void SetEnabled(bool enabled) {
            this.enabled = enabled;
            onEnable?.Invoke(enabled);
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