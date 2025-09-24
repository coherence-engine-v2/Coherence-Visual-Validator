# 🧠 Coherence Visual Validator (LoC-V)

*A Unity-based visual logic checker — built using the Logic of Coherence framework.*

This engine checks whether your game’s **rendered state** is visually consistent with the game’s **intended logical or physical state**.

> ⚠️ Detect impossible visuals like:
> - Invisible objects casting shadows
> - Bright materials in dark environments
> - Incorrect visual feedback for status flags (e.g., burning, wet, cloaked)

---

## 🎮 For Unity Developers

### ✅ How to Use
1. Clone or download this repo
2. Copy the `Unity/` folder into your Unity project's `Assets/` directory
3. Add the `StreamingAssets/VisualRuleSet.json` to your project
4. Attach `VisualRuleEvaluator.cs` to an empty GameObject in your scene
5. Play the scene — coherence errors are logged to the Console

---

### 🧩 Rule Format (VisualRuleSet.json)
```json
{
“parameter”: “isVisible”,
“comparator”: “eq”,
“value”: “false”
}
→ Triggers thenRequirements like:

{
  "property": "castsShadow",
  "expectedValue": "false"
}


---

🧪 Example Rule

{
  "id": "shadow-on-invisible-object",
  "description": "Invisible objects should not cast shadows.",
  "ifCondition": {
    "parameter": "isVisible",
    "comparator": "eq",
    "value": "false"
  },
  "thenRequirements": [
    {
      "property": "castsShadow",
      "expectedValue": "false"
    }
  ],
  "message": "Object is invisible but still casting a shadow."
}


---

📦 Features

Runtime visual coherence validation

JSON rule system (readable, editable, expandable)

Supports:

isVisible, castsShadow, materialColor, etc.

eq, ne, gt, lt comparators


Extendable to:

Shader keywords

FX presence

Animator states

Camera effects




---

🧠 Based on the LoC Framework

This is a visual module for the broader Coherence Engine Stack, which includes:

✅ Coherence Filter Engine (Logic Layer)

🔜 Coherence-Physics (future physical consistency layer)

🔜 Coherence-AI (logic-driven NPC validation)



---

📬 License

Free for non-commercial evaluation.
See LICENSE-EVAL.txt and COMMERCIAL.md for terms.

Contact: nailercole@gmail.com
DOI for original system: https://doi.org/10.5281/zenodo.17188615


---

🚀 Coming Soon

Unity Inspector Overlay (to highlight visual violations in-scene)

Editor-time validation for artists and designers

Unreal Engine version (mirror of this validator)



---

Built by @NailerCole | Powered by 🧠 Logic of Coherence (LoC)
