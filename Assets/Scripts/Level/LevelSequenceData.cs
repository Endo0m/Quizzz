using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelSequenceData", menuName = "Quiz/Level Sequence Data")]
public class LevelSequenceData : ScriptableObject
{
    public LevelSettings[] Levels;
}