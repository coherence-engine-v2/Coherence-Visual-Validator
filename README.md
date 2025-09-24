# Coherence Visual Validator (LoC-V)

A visual logic validator for Unity, powered by the Logic of Coherence (LoC) framework.

---

## 📐 Rule Format (`VisualRuleSet.json`)

```json
{
  "parameter": "isVisible",
  "comparator": "eq",
  "value": "false"
}
```

Triggers `thenRequirements` like:

```json
{
  "property": "castsShadow",
  "expectedValue": "false"
}
```

### 🔁 Example Rule

```json
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
```

---

## 🎨 Supported Visual Properties

| Property        | What It Means                             |
|-----------------|--------------------------------------------|
| `isVisible`     | Is the object's renderer enabled?          |
| `castsShadow`   | Does the object cast real-time shadows?    |
| `materialColor` | The current material color of the object   |

You can expand this by adding your own properties in `GetVisualProperty()`.

---

## 🌟 Features

- Runtime visual coherence validation  
- JSON rule system (readable, editable, expandable)  
- Supports: `isVisible`, `castsShadow`, `materialColor`, etc.  
- Comparators: `eq`, `ne`, `gt`, `lt`, etc.  
- Extendable to:
  - Shader keywords
  - FX presence
  - Animator states
  - Camera effects

---

## 🧠 Based on the LoC Framework

This is a visual module for the broader Coherence Engine Stack, which includes:

- ✅ **Coherence Filter Engine** (Logic Layer)  
- 🔷 Coherence-Physics (future physical consistency layer)  
- 🔷 Coherence-AI (logic-driven NPC validation)

---

## 📄 License

Free for non-commercial evaluation.  
See `LICENSE-EVAL.txt` and `COMMERCIAL.md` for terms.

---

## 🛠️ Coming Soon

- Unity Inspector Overlay (to highlight visual violations in-scene)  
- Editor-time validation for artists and designers  
- Unreal Engine version (mirror of this validator)

---

## 👋 Contact

Built by **@NailerCole**  
Powered by 🧠 Logic of Coherence (LoC)  
📧 mailercole@gmail.com

---

## 📚 Foundational Research

This project builds on the Logic of Coherence (LoC) framework:

- [https://doi.org/10.5281/zenodo.17193463](https://doi.org/10.5281/zenodo.17193463)  
- [https://doi.org/10.5281/zenodo.17194960](https://doi.org/10.5281/zenodo.17194960)  
- [https://doi.org/10.5281/zenodo.17194978](https://doi.org/10.5281/zenodo.17194978)

---
