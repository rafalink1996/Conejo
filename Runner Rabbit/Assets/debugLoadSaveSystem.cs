using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class debugLoadSaveSystem : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI DebugLoadText;
    // Start is called before the first frame update
    void Start()
    {
        DebugLoadText.text = GameStats.stats.debugLoad;
    }

}
