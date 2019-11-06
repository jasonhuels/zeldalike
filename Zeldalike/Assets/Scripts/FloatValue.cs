using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "Float Value", order = 1)]
public class FloatValue : ScriptableObject, ISerializationCallbackReceiver
{
	public string prefabName;
    public float initialValue;
    [HideInInspector]
    public float RunTimeValue;
    

	public int numberOfPrefabsToCreate;
	public Vector3[] spawnPoints;

    public void OnAfterDeserialize()
    {
        RunTimeValue = initialValue;
    }

    public void OnBeforeSerialize()
    { 
    }
}