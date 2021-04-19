using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Addressables.Badger.AssetReferences
{
    public class AssetRefObjectData : MonoBehaviour
    {
        [SerializeField] private AssetReference reference;
        [SerializeField] private List<AssetReference> references = new List<AssetReference>();
        [SerializeField] private List<GameObject> completedObjects = new List<GameObject>();

        private void Start()
        {
            references.Add(reference);

            StartCoroutine(LoadAndWaitUntilComplete());
        }

        private IEnumerator LoadAndWaitUntilComplete()
        {
            yield return AssetRefLoader.CreateAssetsAddToList(references, completedObjects);
        }
    }
}
