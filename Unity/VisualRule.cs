using System.Collections.Generic;

[System.Serializable]
public class VisualRule
{
    public string id;
    public string description;
    public VisualCondition ifCondition;
    public List<VisualRequirement> thenRequirements;
    public string message;
}

[System.Serializable]
public class VisualCondition
{
    public string parameter;
    public string comparator;  // "eq", "gt", "lt", etc.
    public string value;       // can be string, bool, or number (parsed at runtime)
}

[System.Serializable]
public class VisualRequirement
{
    public string property;
    public string expectedValue;
}
