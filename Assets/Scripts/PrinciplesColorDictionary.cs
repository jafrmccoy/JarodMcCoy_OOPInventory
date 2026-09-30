using System.Collections.Generic;
using UnityEngine;

public class PrinciplesColorDictionary : MonoBehaviour
{
    [SerializeField]
    private Dictionary<string, Color> _principleColors = new Dictionary<string, Color>();

    public static IReadOnlyDictionary<string, Color> PrincipleColors { get; private set; }

    private void Awake()
    {
        PrincipleColors = _principleColors;
    }
}
