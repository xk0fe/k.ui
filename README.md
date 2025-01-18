# k.UI

[![License](https://img.shields.io/badge/license-Public%20Domain-lightgrey.svg)](LICENSE)
[![Unity](https://img.shields.io/badge/unity-6.0%2B-blue.svg)]()


Unity package for UI handling or whatever really

---

## 🚀 Purpose  

Make UI screens, open them and close. You can even... maybe later I will write this down not now for sure

---

## 📦 Features  

- none

---

## 🛠️ Installation  

Just copy paste URL into your Package Manager and install it.

## 📚 Examples

### Start
1) Create UI config SO -> Right click -> k -> UI -> UiConfig 
2) Create prefab of a Canvas that you will use for your UI. Moving EventSystem inside of it might be a good idea
3) Initialize UI system in code 
```csharp
public class Example : MonoBehaviour
{
    [SerializeField] private UiConfig _config;
    
    private void Awake()
    {
        Ui.Instance.Initialize(_config, new ViewFactory());
    }
}
```

### Make a View
1) Create script derived from ViewBase
```csharp
public class ExampleView : ViewBase
{
}
```
2) Attach script to your UI window prefab
3) Reference prefab in UiConfig
### Open a View
```csharp
Ui.Open<ExampleView>();
```
### Close a View
```csharp
Ui.Close<ExampleView>();
```

### Auto register your Views
If you are too lazy to drag and drop your views into UiConfig you can use Editor window that will do this work for you.

1) Navigate to top bar menu k -> UI -> UiAutoResolver
2) Reference target UiConfig
3) Press Resolve

It will add all the views that exist in the project. Even duplicates which might lead to unwated results. Do not create duplicates of the same type derived from ViewBase. Maybe later I will make it so it would at least spit out an error in case of duplicate but for now .... 


## 🧪 Samples
You can find samples in the Samples folder.
### InitialConfiguration
This sample shows how to initialize UI system and open a view.
### ServiceConfiguration
This one just helps me write less code. Requires k.Services package to work.