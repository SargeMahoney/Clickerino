using UnityEngine;


[CreateAssetMenu()]
public class ClickerSO : ScriptableObject
{

    public Transform prefab;
    public ClickerType ClickerType;
    public int Value;

}

public enum ClickerType
{
    Green,
    Red,
    Blue,
    Purple
}
