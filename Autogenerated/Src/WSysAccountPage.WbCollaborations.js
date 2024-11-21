define("WSysAccountPage", [
  "WSysAccountPageResources",
  "WbModuleHelper",
  "WbConfigurationConstants",
], function (resources, WbModuleHelper, WbConfigurationConstants) {
  return {
    entitySchemaName: "WSysAccount",
    attributes: {
      /**
       * ####### ########### ######### Wb.
       * @type {Boolean}
       */
      WbServerConnectEnabled: {
        dataValueType: this.BPMSoft.DataValueType.BOOLEAN,
        type: this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
        visible: false,
      },

      /**
       * #### ############.
       * @type {Object}
       */
      Role: {
        lookupListConfig: {
          columns: ["Code"],
        },
      },

      /**
       * ##### ############.
       * @type {String}
       */
      Login: {
        dataValueType: this.BPMSoft.DataValueType.TEXT,
        keyup: { bindTo: "validateLogin" },
      },

      /**
       * ####### ############.
       * @type {Object}
       */
      Contact: {
        dataValueType: this.BPMSoft.DataValueType.LOOKUP,
        lookupListConfig: {
          filter: function () {
            var filtersCollection = this.BPMSoft.createFilterGroup();
            filtersCollection.logicalOperation =
              this.BPMSoft.LogicalOperatorType.AND;
            filtersCollection.add(
              "SysAdminUnit",
              this.BPMSoft.createExistsFilter("[SysAdminUnit:Contact].Id")
            );
            filtersCollection.add(
              "WSysAccount",
              this.BPMSoft.createNotExistsFilter("[WSysAccount:Contact].Id")
            );
            return filtersCollection;
          },
        },
      },
    },
    methods: {
      //region Methods: Protected

      /**
       * @inheritdoc BasePageV2#initEntity
       * @overridden
       */
      initEntity: function () {
        this.callParent(arguments);
        var ctiModel = this.BPMSoft.CtiModel;
        this.set(
          "WbServerConnectEnabled",
          Ext.global.Wb && ctiModel && ctiModel.get("IsConnected")
        );
      },

      /**
       * ########## ########### ### ##### ###### Wb.
       * @protected
       * @return {Boolean}
       */
      isLoginEnabled: function () {
        return this.isNewMode() && this.get("WbServerConnectEnabled");
      },

      /**
       * ######### #### ####### ###### Wb.
       * @protected
       * @param {Function} callback ####### ######### ######.
       * @param {Object[]} errors ###### ###### ## #######.
       */
      updateRole: function (callback, errors) {
        var login = this.get("Login");
        var role = this.get("Role").Code;
        if (this.changedValues.Role) {
          Ext.global.Wb.userUpdate(
            login,
            WbModuleHelper.getHostName(),
            Ext.global.WbUserParamType.Role,
            role,
            function (result) {
              if (result.status !== Ext.global.WbCommandResponseTypes.Success) {
                errors.push(result.response);
              }
              callback(errors);
            }
          );
        } else {
          callback(errors);
        }
      },

      /**
       * ######### ###### ####### ###### Wb.
       * @protected
       * @param {Function} callback ####### ######### ######.
       * @param {Object[]} errors ###### ###### ## #######.
       */
      updatePassword: function (callback, errors) {
        if (this.changedValues.Password || this.changedValues.Password === "") {
          var login = this.get("Login");
          var password = this.get("Password");
          Ext.global.Wb.userUpdate(
            login,
            WbModuleHelper.getHostName(),
            Ext.global.WbUserParamType.Password,
            password,
            function (result) {
              if (result.status !== Ext.global.WbCommandResponseTypes.Success) {
                errors.push(result.response);
              }
              callback(errors);
            }
          );
        } else {
          callback(errors);
        }
      },

      /**
       * ####### ####### ###### ## ####### Wb.
       * @protected
       * @param {Function} callback ####### ######### ######.
       * @param {Object} callback.result ######### #######.
       * @param {Boolean} callback.result.success ####### ######### ##########.
       * @param {String} [callback.result.error] ######### ## ######.
       */
      createUser: function (callback) {
        var role = this.get("Role");
        var login = this.get("Login");
        var password = this.get("Password");
        Ext.global.Wb.userCreate(
          role ? role.Code : "",
          login,
          password,
          WbModuleHelper.getHostName(),
          function (result) {
            if (result.status !== Ext.global.WbCommandResponseTypes.Success) {
              var response = result.response;
              this.error(response);
              if (
                !response ||
                response.response !==
                  WbConfigurationConstants.WbErrorCode.UserAlreadyExists
              ) {
                callback({
                  success: false,
                  error:
                    resources.localizableStrings.WbUserErrorCreationMessage,
                });
                return;
              }
            }
            callback({
              success: true,
            });
          }.bind(this)
        );
      },

      /**
       * @inheritdoc BasePageV2#checkCanEditRight
       * @overridden
       */
      checkCanEditRight: function (callback, scope) {
        var validLogin = this.validateLogin();
        if (!this.validate() || !validLogin) {
          var msg = validLogin
            ? resources.localizableStrings.FillRequiredFieldsMessage
            : resources.localizableStrings.LoginValidationMessage;
          var resultObject = {
            success: false,
            message: msg,
          };
          callback.call(scope, resultObject);
          return;
        }
        var isNew = this.isNewMode();
        if (isNew) {
          var password = this.get("Password");
          this.set(
            "Password",
            Ext.isEmpty(password) ? this.get("Login") : password
          );
          this.createUser(function (result) {
            callback.call(scope, result);
          });
        } else {
          this.BPMSoft.chain(
            function (next) {
              var errors = [];
              next(errors);
            },
            this.updateRole,
            this.updatePassword,
            function (next, errors) {
              var resultObject = {
                success: errors.length === 0,
                message: this.getCombineErrorMessage(errors),
              };
              callback.call(scope, resultObject);
            },
            this
          );
        }
      },

      /**
       * ########## ######### ## #######.
       * @protected
       * @param {Object[]} errors ###### ###### ## #######.
       * @returns {String} C######## ## #######.
       */
      getCombineErrorMessage: function (errors) {
        var msg = "";
        errors.forEach(function (error, index) {
          if (index > 0) {
            msg += ", ";
          }
          msg += error.response;
        });
        return msg;
      },

      /**
       * ######### ############ ########## ###### ############.
       * @protected
       * @returns {Boolean} #### ##### ######### - true, ##### - false.
       */
      validateLogin: function () {
        var str = this.get("Login") || "";
        return !str.match(/\D/g);
      },

      /**
       * ########## ######### ###### ######### ########## ### ##### ####### ###### Wb.
       * @protected
       * @return {string}
       */
      getAuthControlGroupCaption: function () {
        var caption = this.get("Resources.Strings.AuthControlGroupCapton");
        var WbServerConnectEnabled = this.get("WbServerConnectEnabled");
        if (!WbServerConnectEnabled) {
          caption += this.Ext.String.format(
            " [{0}]",
            this.get("Resources.Strings.ServerNotConnectedCaption")
          );
        }
        return caption;
      },

      //endregion
    },
    details: /**SCHEMA_DETAILS*/ {} /**SCHEMA_DETAILS*/,
    diff: /**SCHEMA_DIFF*/ [
      {
        operation: "remove",
        name: "actions",
      },
      {
        operation: "remove",
        name: "ViewOptionsButton",
      },
      {
        operation: "insert",
        name: "Contact",
        parentName: "Header",
        propertyName: "items",
        values: {
          layout: {
            column: 0,
            colSpan: 24,
            row: 0,
          },
        },
      },
      {
        operation: "insert",
        parentName: "Header",
        name: "AuthControlGroup",
        propertyName: "items",
        values: {
          itemType: this.BPMSoft.ViewItemType.CONTROL_GROUP,
          caption: { bindTo: "getAuthControlGroupCaption" },
          items: [],
          layout: {
            column: 0,
            colSpan: 24,
            row: 1,
          },
        },
      },
      {
        operation: "insert",
        parentName: "AuthControlGroup",
        propertyName: "items",
        name: "Login",
        values: {
          enabled: { bindTo: "isLoginEnabled" },
          layout: {
            column: 0,
            colSpan: 24,
            row: 2,
          },
        },
      },
      {
        operation: "insert",
        parentName: "AuthControlGroup",
        propertyName: "items",
        name: "Password",
        values: {
          enabled: { bindTo: "WbServerConnectEnabled" },
          controlConfig: {
            protect: true,
          },
          layout: {
            column: 0,
            colSpan: 24,
            row: 3,
          },
        },
      },
      {
        operation: "insert",
        parentName: "AuthControlGroup",
        propertyName: "items",
        name: "Role",
        values: {
          contentType: this.BPMSoft.ContentType.ENUM,
          enabled: { bindTo: "WbServerConnectEnabled" },
          layout: {
            column: 0,
            colSpan: 24,
            row: 4,
          },
        },
      },
    ] /**SCHEMA_DIFF*/,
  };
});
