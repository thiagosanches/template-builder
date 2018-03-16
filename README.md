# Template Builder

The purpose of this project is to help someone that needs to build quickly some kind of prototype.

Intentionally this application was built to support the following elements:
* Textbox
* MultiFields
* Tabs
* Combobox
* Checkbox
* Color Picker
* Image
* Path Field
* Fieldset

It's easy to support a new element, you have to follow the existing structure to add it and change the Factory to know that there is a new element that could be used.

## Getting Started

These instructions will get you a copy of the project up and running on your local machine for development and testing purposes.

### Prerequisites

* .NET Core 2.0 SDK

### Building

`git clone https://github.com/thiagosanches/template-builder.git`

`cd template-builder`

`dotnet build`

## Running

```
dotnet InteraceBuilder.Console.dll my-input.json my-output.html
```

## Running the tests

I didn't have enough time to work on it, but as soon as I can I'll add some unit tests.

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

## Contributing
Feel free to fork it and contribute :)

## Built With
* [Bootstrap 3.3](http://bootstrapdocs.com/v3.3.0/docs/getting-started/)
* [Microsoft Visual Studio 2017 Community](https://www.visualstudio.com/downloads/)
* [.NET Core 2.0 SDK](https://github.com/dotnet/core)

## Next steps
* Work on unit tests.
* Refactor the Factory and use some IoC/DI mechanism.
* Build a better documentation.
