using System;
using UnityEngine;
namespace Scripts.Items
{
    public class Item : IDisposable
    {
        protected GameObject Instance;
        protected ScriptableObject Data;
        protected readonly Transform Parent;
        protected virtual string PrefabName => "";
        public Item(ScriptableObject data, Transform parent)
        {
            Data = data;
            Parent = parent;
            Load();
        }

        protected virtual void Load()
        {
            if (Data == null)
                return;
            Instance = ResourceHelper.InstantiatePrefab(PrefabName, Parent);
            Instance.transform.localScale = Vector3.one;
        }
        public virtual void Dispose()
        {
            if (Instance != null)
            {
                UnityEngine.Object.Destroy(Instance);
                Instance = null;
            }
        }

        protected virtual void OnClick()
        {
        }

    }
}
