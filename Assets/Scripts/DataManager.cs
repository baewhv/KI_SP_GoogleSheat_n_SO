using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public SheetData _monsterSheet;

    [SerializeField] private List<MonsterDataSO> _monsterDataList;
    private Dictionary<string, MonsterDataSO> _monsterDictionary = new();

    private void Awake() => InitMonsterDataToDictionary();

    void Start() => StartCoroutine(_monsterSheet.Load(SetMonsterDatas));

    public void SetMonsterDatas(char splitSymbol, string[] lines)
    {
        if(lines == null) return;

        for (int i = 3; i < lines.Length; i++)
        {
            string[] cols = lines[i].Split(splitSymbol);
            MonsterDataSO monster;

            if (_monsterDictionary.ContainsKey(cols[1]))
            {
                monster = _monsterDictionary[cols[1]];
            }
            else
            {
                monster = ScriptableObject.CreateInstance<MonsterDataSO>();
                monster.name = cols[1];
                _monsterDictionary.Add(cols[1], monster);
                Debug.LogWarning($"<color=yellow>MonsterSO 누락, {cols[1]} 추가 필요.</color>");
                _monsterDataList.Add(monster);
            }

        }
        
    }

    public void InitMonsterDataToDictionary()
    {
        _monsterDictionary = _monsterDataList.ToDictionary(mon => mon.name);
    }
}