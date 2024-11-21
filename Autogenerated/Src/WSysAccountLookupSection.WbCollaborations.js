define("WSysAccountLookupSection", [
  "ConfigurationEnums",
  "WbModuleHelper",
], function (ConfigurationEnums, WbModuleHelper) {
  return {
    /**
     * ######## ##### #######.
     * @protected
     * @overridden
     * @type {String}
     */
    entitySchemaName: "WSysAccount",
    methods: {
      //region Methods: Private

      /**
       * ####### ####### ###### ## ####### Wb.
       * @private
       * @param {Object} record ###### ######.
       */
      removeUser: function (record) {
        var login = record.get("Login");
        Ext.global.Wb.userRemove(
          login,
          WbModuleHelper.getHostName(),
          function (result) {
            if (result.status !== Ext.global.WbCommandResponseTypes.Success) {
              var response = result.response;
              this.error(response);
            }
          }.bind(this)
        );
      },

      //endregion

      //region Methods: Protected

      /**
       * @inheritdoc BaseSectionV2#initAddRecordButtonParameters
       * @overridden
       * TODO ###### ##### ####### ####### ######### SysModuleEditLcz ## ########## ######
       */
      initAddRecordButtonParameters: function () {
        this.callParent(arguments);
        this.set(
          "AddRecordButtonCaption",
          this.get("Resources.Strings.AddRecordButtonCaption")
        );
      },

      /**
       * @inheritdoc BPMSoft.BaseLookupConfigurationSection#addRecord
       * @overridden
       */
      addRecord: function () {
        var typeColumnValue = this.BPMSoft.GUID_EMPTY;
        var schemaName = this.getEditPageSchemaName(typeColumnValue);
        if (!schemaName) {
          return;
        }
        this.openCardInChain({
          schemaName: schemaName,
          operation: ConfigurationEnums.CardStateV2.ADD,
          moduleId: this.getChainCardModuleSandboxId(typeColumnValue),
          instanceConfig: {
            useSeparatedPageHeader: this.get("UseSeparatedPageHeader"),
          },
        });
      },

      /**
       * @inheritdoc BPMSoft.BaseLookupConfigurationSection#getModuleCaption
       * @overridden
       */
      getModuleCaption: function () {
        var historyState = this.sandbox.publish("GetHistoryState");
        var state = historyState.state;
        if (state && state.caption) {
          return state.caption;
        }
        return this.get("Resources.Strings.HeaderCaption");
      },

      /**
       * @inheritDoc BPMSoft.GridUtilitiesV2#onDeleteAccept
       * @overridden
       */
      onDeleteAccept: function () {
        var selectedItems = this.getSelectedItems();
        var gridData = this.getGridData();
        BPMSoft.each(
          selectedItems,
          function (item) {
            var record = gridData.get(item);
            if (!Ext.isEmpty(record)) {
              this.removeUser(record);
            }
          },
          this
        );
        this.callParent(arguments);
      },

      //endregion
    },
  };
});
