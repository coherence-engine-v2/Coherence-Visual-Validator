using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class VisualRuleEvaluator : MonoBehaviour
{
    public string ruleFileName = "VisualRuleSet.json";

    private List<VisualRule> rules;

    void Start()
    {
        LoadRules();
        EvaluateRules();
    }

    void LoadRules()
    {
        string path = Path.Combine(Application.streamingAssetsPath, ruleFileName);
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            VisualRuleSet ruleSet = JsonUtility.FromJson<VisualRuleSet>(json);
            rules = ruleSet.rules;
            Debug.Log($"[Coherence/Visual] Loaded {rules.Count} visual rules.");
        }
        else
        {
            Debug.LogWarning($"[Coherence/Visual] Rule file not found at {path}");
        }
    }

    void EvaluateRules()
    {
        if (rules == null) return;

        GameObject[] allObjects = FindObjectsOfType<GameObject>();

        foreach (GameObject obj in allObjects)
        {
            foreach (VisualRule rule in rules)
            {
                if (EvaluateCondition(obj, rule.ifCondition))
                {
                    foreach (VisualRequirement req in rule.thenRequirements)
                    {
                        string actual = GetVisualProperty(obj, req.property);
                        if (actual != req.expectedValue)
                        {
                            Debug.LogWarning($"[Coherence/Visual FAIL] Rule: {rule.id} → {rule.message} | Object: {obj.name}");
                        }
                    }
                }
            }
        }
    }

    bool EvaluateCondition(GameObject obj, VisualCondition condition)
    {
        string val = GetVisualProperty(obj, condition.parameter);
        switch (condition.comparator)
        {
            case "eq": return val == condition.value;
            case "ne": return val != condition.value;
            case "gt":
                if (float.TryParse(val, out float v1) && float.TryParse(condition.value, out float v2))
                    return v1 > v2;
                break;
            case "lt":
                if (float.TryParse(val, out float v3) && float.TryParse(condition.value, out float v4))
                    return v3 < v4;
                break;
        }
        return false;
    }

    string GetVisualProperty(GameObject obj, string property)
    {
        switch (property)
        {
            case "isVisible":
                Renderer renderer = obj.GetComponent<Renderer>();
                return (renderer != null && renderer.enabled).ToString().ToLower();

            case "castsShadow":
                Renderer r = obj.GetComponent<Renderer>();
                return (r != null && r.shadowCastingMode != UnityEngine.Rendering.ShadowCastingMode.Off).ToString().ToLower();

            case "materialColor":
                Renderer rend = obj.GetComponent<Renderer>();
                return (rend != null) ? rend.material.color.ToString() : "null";

            // Add more properties as needed
            default:
                return "undefined";
        }
    }
}

[System.Serializable]
public class VisualRuleSet
{
    public List<VisualRule> rules;
}
