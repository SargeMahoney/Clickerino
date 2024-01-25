using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ILevel
{
    public string GetLevelName();
    public List<ClickerSO> CreateClickerList(List<ClickerSO> AllowedSceneClickersList, int totalPositions);
}
