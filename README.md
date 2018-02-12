# template-builder

The purpose of this project is to help someone that needs to built quickly some kind of prototype.

Intentionally this application was built to support the following elements:
* Textbox
* Multifields
* Tabs
* Combobox
* Checkbox

There are a lot of works that need to be done, feel free to fork it :).

# How to use?
```
dotnet InteraceBuilder.Console.dll my-input.json my-output.html
```

# Examples
```json
{
  "title" : "Search Component",
  "controls" : [{
        "type" : "textbox",
        "label" : "My Field 1",
        "defaultValue" : "Hey, this is a textbox!",
        "hint" : "Fill this textbox with the right value!"
    },
    {
          "type" : "textbox",
          "label" : "My Field 2",
          "defaultValue" : "Hey, this is a textbox 2!",
          "hint" : "Fill this textbox with the right value!"
    },
    {
          "type" : "textbox",
          "label" : "My Field 3",
          "hint" : "Fill this textbox with the right value!"
    }
  ]
}
```

![Example 1](https://github.com/thiagosanches/template-builder/blob/master/Help/example1.PNG)

```json
{
  "title" : "Testing Component",
  "tabs" : [{
      "name" : "General",
      "controls" : [{
          "type" : "textbox",
          "label" : "My Field 1",
          "defaultValue" : "textbox",
          "hint" : "Fill this textbox with the right value!"
        }
      ]
    },
    {
      "name" : "My Tab",
      "controls" : [{
          "type" : "textbox",
          "label" : "My Field 1",
          "defaultValue" : "textbox",
          "hint" : "Fill this textbox with the right value!"
        },
        {
          "type" : "multifield",
          "label" : "My multifield",
          "hint" : "Fill this multifield with the right value!",
          "controls" : [{
              "type" : "textbox",
              "label" : "My field",
              "defaultValue" : "",
              "hint" : "Example: 123"
            }
          ]
        }
      ]
    }
  ]
}
```

![Example 2](https://github.com/thiagosanches/template-builder/blob/master/Help/example2.PNG)
