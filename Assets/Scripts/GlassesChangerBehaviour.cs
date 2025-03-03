using System.Collections.Generic;
using UnityEngine;

public class GlassesChangerBehaviour : MonoBehaviour
{
    [SerializeField] private GameObject glassesGroupPrefab; // Prefab de las gafas a asignar en el editor

    // Este método muestra las gafas según el índice que se pasa
    public void DisplayGlasses(int glassesIndex)
    {
        glassesGroupPrefab.transform.GetChild(glassesIndex).GetComponent<MeshRenderer>().enabled = true;

        Debug.Log("Enabling " + glassesGroupPrefab.transform.GetChild(glassesIndex).name);

        // Desactivamos las demás gafas
        for (int i = 0; i < glassesGroupPrefab.transform.childCount; i++)
        {
            if (i != glassesIndex)
            {
                Debug.Log("Enabling " + glassesGroupPrefab.transform.GetChild(i).name);
                glassesGroupPrefab.transform.GetChild(i).GetComponent<MeshRenderer>().enabled = false;
            }
        }
    }
}
