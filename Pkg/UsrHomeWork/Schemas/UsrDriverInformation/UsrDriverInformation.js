define("UsrDriverInformation", [], function() {
        return {
            entitySchemaName: "Contact",
            attributes: {
                "MasterColumnName": {
                    "type": BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
                    "dataValueType": BPMSoft.DataValueType.TEXT
                },
                "UsrFIO": {
                    "type": BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
                    "dataValueType": BPMSoft.DataValueType.TEXT,
                    "value": "",
                    "caption": "ФИО"
                },
                "UsrAccount": {
                    "type": BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
                    "dataValueType": BPMSoft.DataValueType.LOOKUP,
                    "value": "",
                    "caption": "Организация"
                },
                "UsrPhone": {
                    "type": BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
                    "dataValueType": BPMSoft.DataValueType.TEXT,
                    "value": "",
                    "caption": "Телефон"
                },
                "UsrMobilePhone": {
                    "type": BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
                    "dataValueType": BPMSoft.DataValueType.TEXT,
                    "value": "",
                    "caption": "Мобильный телефон"
                },
                "UsrEmail": {
                    "type": BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
                    "dataValueType": BPMSoft.DataValueType.TEXT,
                    "value": "",
                    "caption": "Email"
                }
            },
            messages: {
                "GetColumnsValues": {
                    mode: this.BPMSoft.MessageMode.PTP,
                    direction: this.BPMSoft.MessageDirectionType.PUBLISH
                },
                "UsrDiriverChangedMessage": {
                    mode: BPMSoft.MessageMode.PTP,
                    direction: BPMSoft.MessageDirectionType.SUBSCRIBE
                },
            },
            mixins: {},
            methods: {
                init: function(callback, scope) {
                    this.callParent([
                        function() {
                            this.subscribeSandboxEvents();
                            this.initUsrDiriverParameters();
                            this.Ext.callback(callback, scope, arguments);
                        }, this
                    ]);
                },
                subscribeSandboxEvents: function() {
                    this.sandbox.subscribe("UsrDiriverChangedMessage", this.onUsrDiriverChanged, this, [this.sandbox.id]);
                },
                onUsrDiriverChanged: function() {
                    this.initUsrDiriverParameters();
                },

                /**
                 * Initializes master column parameters.
                 * @protected
                 */
                initUsrDiriverParameters: function() {
                    const masterColumnName = this.get("MasterColumnName");
                    const masterColumnValue = this.sandbox.publish("GetColumnsValues", [masterColumnName], [this.sandbox.id]);
                    const account = masterColumnValue?.UsrDriver?.Account?.value;
                    const phone = masterColumnValue?.UsrDriver?.Phone;
                    const mobilePhone = masterColumnValue?.UsrDriver?.MobilePhone;
                    const email = masterColumnValue?.UsrDriver?.Email;
                    const name = masterColumnValue?.UsrDriver?.Name;

                    // this.set("UsrAccount", account); хз чо с этим делать, не сетается так(( 
                    this.set("UsrPhone", phone);
                    this.set("UsrMobilePhone", mobilePhone);
                    this.set("UsrEmail", email);
                    this.set("UsrFIO", name);
                },
            },
            diff: /**SCHEMA_DIFF*/[
                {
                    "operation": "remove",
                    "name": "ProfileHeaderValue"
                },
                {
                    "operation": "merge",
                    "name": "ProfileModuleContainer",
                    "values": {
                        "wrapClass": ["profile-module-container", "account-profile"]
                    }
                },
                {
                    "operation": "insert",
                    "name": "UsrFIO",
                    "parentName": "ProfileModuleContainer",
                    "propertyName": "items",
                    "values": {
                        "bindTo": "UsrFIO",
                        "enabled": false,
                        "layout": {
                            "column": 0,
                            "row": 1,
                            "colSpan": 24
                        }
                    }
                },
                {
                    "operation": "insert",
                    "name": "UsrAccount",
                    "parentName": "ProfileModuleContainer",
                    "propertyName": "items",
                    "values": {
                        "bindTo": "UsrAccount",
                        "enabled": false,
                        "layout": {
                            "column": 0,
                            "row": 2,
                            "colSpan": 24
                        }
                    }
                },
                {
                    "operation": "insert",
                    "name": "UsrPhone",
                    "parentName": "ProfileModuleContainer",
                    "propertyName": "items",
                    "values": {
                        "bindTo": "UsrPhone",
                        "enabled": false,
                        "layout": {
                            "column": 0,
                            "row": 3,
                            "colSpan": 24
                        }
                    }
                },
                {
                    "operation": "insert",
                    "name": "UsrMobilePhone",
                    "parentName": "ProfileModuleContainer",
                    "propertyName": "items",
                    "values": {
                        "bindTo": "UsrMobilePhone",
                        "enabled": false,
                        "layout": {
                            "column": 0,
                            "row": 4,
                            "colSpan": 24
                        }
                    }
                },
                {
                    "operation": "insert",
                    "name": "UsrEmail",
                    "parentName": "ProfileModuleContainer",
                    "propertyName": "items",
                    "values": {
                        "bindTo": "UsrEmail",
                        "enabled": false,
                        "layout": {
                            "column": 0,
                            "row": 5,
                            "colSpan": 24
                        }
                    }
                },
            ]/**SCHEMA_DIFF*/
        };
    }
);
