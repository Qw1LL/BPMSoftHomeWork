[
  {
    "operation": "insert",
    "values": {
      "navigationConfig": {
        "showCloseDialog": true
      },
      "viewConfig": {
        "type": "AddScreen",
        "properties": {
          "title": "#ResourceString(NewCase)",
          "editCard": {
            "type": "CaseAddCard",
            "properties": {
              "controller": "$Case",
              "showInvalidDialog": false,
              "body": {
                "type": "Column",
                "properties": {
                  "scrollable": true,
                  "items": [
                    {
                      "type": "EditField",
                      "properties": {
                        "value": "$Category"
                      }
                    },
                    {
                      "type": "EditField",
                      "properties": {
                        "value": "$Symptoms",
                        "hint": "#ResourceString(SymptomsHint)",
                        "minLines": 5
                      }
                    }
                  ]
                }
              }
            }
          }
        }
      },
      "actions": {
        "onSave": {
          "type": "ControllerEvent",
          "config": {
            "controllerName": "Case",
            "event": "Save"
          }
        },
        "onCancel": {
          "type": "ControllerEvent",
          "config": {
            "controllerName": "Case",
            "event": "Cancel"
          }
        }
      },
      "controllers": {
        "Case": {
          "type": "CaseAddCardController",
          "model": {
            "type": "CaseEntityModel",
            "config": {
              "entityName": "Case",
              "id": "recordId",
              "columns": [
                {
                  "expression": {
                    "columnPath": "Id",
                    "expressionType": 0
                  }
                },
                {
                  "expression": {
                    "columnPath": "Category",
                    "expressionType": 0
                  }
                },
                {
                  "expression": {
                    "columnPath": "Symptoms",
                    "expressionType": 0
                  }
                }
              ]
            }
          },
          "config": {
            "businessRules": {
              "Category": {
                "CategoryRequirementRule": {
                  "uId": "d3993817-f2e8-4b14-8616-e6eeefd25f1a",
                  "enabled": true,
                  "removed": false,
                  "ruleType": 0,
                  "property": 2,
                  "logical": 1,
                  "conditions": [
                    {
                      "comparisonType": 3,
                      "leftExpression": {
                        "type": 1,
                        "attribute": "Category"
                      },
                      "rightExpression": {
                        "type": 0,
                        "value": null,
                        "dataValueType": 1
                      }
                    }
                  ]
                }
              }
            }
          }
        }
      }
    }
  }
]