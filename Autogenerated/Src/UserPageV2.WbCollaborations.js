define("UserPageV2", [
  "UserPageV2Resources",
  "ConfigurationConstants",
  "WbConfigurationConstants",
  "WbModuleHelper",
], function (
  resources,
  ConfigurationConstants,
  WbConfigurationConstants,
  WbModuleHelper
) {
  return {
    attributes: {
      /**
       * ##### ############ Wb.
       * @type {String}
       */
      WbNumber: {
        dataValueType: BPMSoft.DataValueType.TEXT,
        type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
        value: "",
      },

      /**
       * ####### ########## ############ Wb.
       * @type {Boolean}
       */
      IsWbUserCreated: {
        dataValueType: BPMSoft.DataValueType.BOOLEAN,
        type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
        value: false,
      },
    },
    methods: {
      /**
       * ######### ############# ########## ######.
       * @overridden
       * @param {Object} response ######### ############## ###### #######.
       * @param {Object} config ################ ######.
       * @param {Boolean} callParentOnSaved ####### ########## ############# ########## ######
       * ###### # ############ ########.
       */
      onSaved: function (response, config, callParentOnSaved) {
        var connectionType = this.get("ConnectionType");
        var isConnected = BPMSoft.CtiModel.get("IsConnected");
        if (
          !this.isNewMode() ||
          Ext.isEmpty(Ext.global.Wb) ||
          callParentOnSaved ||
          !isConnected ||
          connectionType !==
            ConfigurationConstants.SysAdminUnit.ConnectionType.AllEmployees
        ) {
          this.callParent(arguments);
          return;
        }
        this.setWbNumber(this.onSaved.bind(this, response, config, true));
      },

      /**
       * ######### ##### ####### ###### Wb.
       * @private
       * @param {Function} callback ####### ######### ######.
       */
      setWbNumber: function (callback) {
        var query = this.getContactInnerPhoneQuery();
        query.getEntityCollection(function (response) {
          if (!response.success) {
            callback();
            return;
          }
          if (!response.collection.isEmpty()) {
            var contactCommunication = response.collection.getByIndex(0);
            this.set("WbNumber", contactCommunication.get("Number"));
            this.createWbAccount(callback);
          } else {
            this.setLastWbNumber(callback);
          }
        }, this);
      },

      /**
       * ######### ###### ### ####### ###### ######## ##### ######## # ##### "########## #######".
       * @private
       * @returns {BPMSoft.EntitySchemaQuery} ########## ######### EntitySchemaQuery.
       */
      getContactInnerPhoneQuery: function () {
        var query = Ext.create("BPMSoft.EntitySchemaQuery", {
          rootSchemaName: "ContactCommunication",
        });
        query.addColumn("Number");
        query.filters.addItem(
          BPMSoft.createColumnFilterWithParameter(
            BPMSoft.ComparisonType.EQUAL,
            "Contact",
            this.get("Contact").value
          )
        );
        query.filters.addItem(
          BPMSoft.createColumnFilterWithParameter(
            BPMSoft.ComparisonType.EQUAL,
            "CommunicationType",
            ConfigurationConstants.CommunicationTypes.InnerPhone
          )
        );
        return query;
      },

      /**
       * ####### ####### ###### Wb.
       * @private
       * @param {Function} callback ####### ######### ######.
       */
      createWbAccount: function (callback) {
        var WbNumber = this.get("WbNumber");
        Ext.global.Wb.userCreate(
          "admin",
          WbNumber,
          WbNumber,
          WbModuleHelper.getHostName(),
          this.onWbAccountCreated.bind(this, callback)
        );
      },

      /**
       * ####### ######## ##### ### ########## ########.
       * @private
       * @param {Function} callback ####### ######### ######.
       */
      createContactCommunication: function (callback) {
        var insert = Ext.create("BPMSoft.InsertQuery", {
          rootSchemaName: "ContactCommunication",
        });
        insert.setParameterValue(
          "Contact",
          this.get("Contact").value,
          BPMSoft.DataValueType.GUID
        );
        var WbNumber = this.get("WbNumber");
        insert.setParameterValue(
          "Number",
          WbNumber,
          BPMSoft.DataValueType.TEXT
        );
        insert.setParameterValue(
          "CommunicationType",
          ConfigurationConstants.CommunicationTypes.InnerPhone,
          BPMSoft.DataValueType.GUID
        );
        insert.execute(callback, this);
      },

      /**
       * ######### ##### ##### ####### ###### Wb.
       * @private
       * @param {Function} callback ####### ######### ######.
       */
      setLastWbNumber: function (callback) {
        var requestConfig = {
          serviceName: "SysSettingsService",
          methodName: "GetIncrementValueVsMask",
          data: {
            sysSettingName: "WSysAccountLastNumber",
            sysSettingMaskName: "WSysAccountCodeMask",
          },
        };
        this.callService(
          requestConfig,
          function (response) {
            this.set("WbNumber", response.GetIncrementValueVsMaskResult);
            this.createContactCommunication(
              this.createWbAccount.bind(this, callback)
            );
          },
          this
        );
      },

      /**
       * ######### ######### ########## ####### ###### Wb.
       * @private
       * @param {Function} callback ####### ######### ######.
       * @param {Object} result ######### ########## ####### ###### Wb.
       */
      onWbAccountCreated: function (callback, result) {
        if (result.status !== Ext.global.WbCommandResponseTypes.Success) {
          var response = result.response;
          this.error(response);
          if (
            !response ||
            response.response !==
              WbConfigurationConstants.WbErrorCode.UserAlreadyExists
          ) {
            BPMSoft.utils.showInformation(
              resources.localizableStrings.WbUserErrorCreationMessage,
              callback
            );
            return;
          }
        }
        this.createWbUser(callback);
      },

      /**
       * ####### # bpmcrm ############ Wb.
       * @param {Function} callback ####### ######### ######.
       * @private
       */
      createWbUser: function (callback) {
        var insert = Ext.create("BPMSoft.InsertQuery", {
          rootSchemaName: "WSysAccount",
        });
        insert.setParameterValue(
          "Contact",
          this.get("Contact").value,
          BPMSoft.DataValueType.GUID
        );
        var WbNumber = this.get("WbNumber");
        insert.setParameterValue("Login", WbNumber, BPMSoft.DataValueType.TEXT);
        insert.setParameterValue(
          "Password",
          WbNumber,
          BPMSoft.DataValueType.TEXT
        );
        insert.setParameterValue(
          "Role",
          WbConfigurationConstants.WSysAccountRole.Administrator,
          BPMSoft.DataValueType.GUID
        );
        insert.execute(callback, this);
      },
    },
    details: /**SCHEMA_DETAILS*/ {} /**SCHEMA_DETAILS*/,
    diff: /**SCHEMA_DIFF*/ [] /**SCHEMA_DIFF*/,
  };
});
