define("BulkEmailEventLogSectionV2", function() {
    return {
        entitySchemaName: "BulkEmailEventLog",
        diff: /**SCHEMA_DIFF*/[
            {
                "operation": "remove",
                "name": "SeparateModeAddRecordButton"
            },
            {
                "operation": "remove",
                "name": "DataGridActiveRowOpenAction"
            },
            {
                "operation": "remove",
                "name": "DataGridActiveRowCopyAction"
            },
            {
                "operation": "remove",
                "name": "DataGridActiveRowDeleteAction"
            }
        ]/**SCHEMA_DIFF*/,
        messages: {},
        methods: {
            /**
             * @inheritdoc BPMSoft.BaseSectionV2#isVisibleDeleteAction
             * @overridden
             */
            isVisibleDeleteAction: function() {
                return false;
            },

            /**
             * @inheritdoc BPMSoft.BaseSectionV2#isVisibleDeleteAction
             * @overridden
             */
            getModuleCaption: function() {
                return this.get("Resources.Strings.Caption");
            }
        }
    };
});
