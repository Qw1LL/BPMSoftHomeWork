  /**
  * View model for string parameter item in container list.
  */
define("StringParameterListItemViewModel", ["StringParameterListItemViewModelResources",
        "BaseParameterListItemViewModel"],
    function(resources) {
        /**
        * @class BPMSoft.configuration.StringParameterListItemViewModel
        */
        Ext.define("BPMSoft.configuration.StringParameterListItemViewModel", {
        extend: "BPMSoft.BaseParameterListItemViewModel",
        alternateClassName: "BPMSoft.StringParameterListItemViewModel",

        /**
         * @inheritdoc BPMSoft.BaseParameterListItemViewModel#onGetMacros
         * @override
         */
        onGetMacros: function(macros) {
            this.$Value = this.$Value ? this.$Value + macros : macros;
        },

        /**
         * @inheritdoc BPMSoft.BaseParameterListItemViewModel#getValueMenuItems
         * @override
         */
        getValueMenuItems: function() {
            var items = this.callParent();
            items.removeByKey("InputValue");
            items.add("ContactName", new BPMSoft.BaseViewModel( {
                values: {
                    Id: "ContactName",
                    Caption: resources.localizableStrings.ContactName,
                    ImageConfig: this.getImage(resources.localizableImages.ContactIcon),
                    MarkerValue: "ContactName",
                    Click: "$onSelectContactNameMacros"
                }
            }));
            items.add("DateTimeMacros", new BPMSoft.BaseViewModel( {
                values: {
                    Id: "DateTimeMacros",
                    Caption: resources.localizableStrings.DateTimeMacro,
                    ImageConfig: this.getImage(resources.localizableImages.CalendarIcon),
                    MarkerValue: "DateTimeMacros",
                    Click: "$loadDateTimeMacrosPage"
                }
            }));
            return items;
        },

        /**
         * Handles contact name macros selected.
         * @protected
         */
        onSelectContactNameMacros: function() {
            var macros = this.formatMacrosColumn("Name");
            this.onGetMacros(macros);
        }

    });
    return BPMSoft.BooleanParameterListItemViewModel;
});
