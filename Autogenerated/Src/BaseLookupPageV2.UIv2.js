define("BaseLookupPageV2", ["ConfigurationEnums"], function() {
	return {
		messages: {},
		attributes: {
			/**
			 * @deprecated Will be removed in the future releases.
			 */
			GridData: {dataValueType: BPMSoft.DataValueType.COLLECTION},

			/**
			 * @deprecated Will be removed in the future releases.
			 */
			ActiveRow: {dataValueType: BPMSoft.DataValueType.GUID},

			/**
			 * @deprecated Will be removed in the future releases.
			 */
			IsGridEmpty: {dataValueType: BPMSoft.DataValueType.BOOLEAN},

			/**
			 * @deprecated Will be removed in the future releases.
			 */
			ShowGridMask: {dataValueType: BPMSoft.DataValueType.BOOLEAN},

			/**
			 * @deprecated Will be removed in the future releases.
			 */
			IsGridLoading: {dataValueType: BPMSoft.DataValueType.BOOLEAN},

			/**
			 * @deprecated Will be removed in the future releases.
			 */
			MultiSelect: {dataValueType: BPMSoft.DataValueType.BOOLEAN},

			/**
			 * @deprecated Will be removed in the future releases.
			 */
			SelectedRows: {dataValueType: BPMSoft.DataValueType.COLLECTION},

			/**
			 * @deprecated Will be removed in the future releases.
			 */
			RowCount: {dataValueType: BPMSoft.DataValueType.INTEGER},

			/**
			 * @deprecated Will be removed in the future releases.
			 */
			IsPageable: {dataValueType: BPMSoft.DataValueType.BOOLEAN},

			/**
			 * @deprecated Will be removed in the future releases.
			 */
			IsClearGridData: {dataValueType: BPMSoft.DataValueType.BOOLEAN},

			/**
			 * @deprecated Will be removed in the future releases.
			 */
			SortColumns: {dataValueType: BPMSoft.DataValueType.COLLECTION},

			searchColumn: {dataValueType: BPMSoft.DataValueType.LOOKUP},
			//LookupCaption

			LookupInfo: {dataValueType: BPMSoft.DataValueType.CUSTOM_OBJECT}
		},
		methods: {
			/**
			 * @deprecated Will be removed in the future releases.
			 */
			init: BPMSoft.abstractFn,

			/**
			 * @deprecated Will be removed in the future releases.
			 */
			initModelValues: BPMSoft.abstractFn,

			/**
			 * @deprecated Will be removed in the future releases.
			 */
			subscribeSandboxEvents: BPMSoft.abstractFn,

			/**
			 * @deprecated Will be removed in the future releases.
			 */
			subscribeCardModuleResponse: BPMSoft.abstractFn,

			/**
			 * @deprecated Will be removed in the future releases.
			 */
			onCardModuleResponse: BPMSoft.abstractFn,

			/**
			 * @deprecated Will be removed in the future releases.
			 */
			getResultItem: BPMSoft.abstractFn,

			/**
			 * @deprecated Will be removed in the future releases.
			 */
			getChainCardModuleSandboxId: BPMSoft.abstractFn,

			/**
			 * @deprecated Will be removed in the future releases.
			 */
			onRender: BPMSoft.abstractFn,

			/**
			 * @deprecated Will be removed in the future releases.
			 */
			getGridData: BPMSoft.abstractFn,

			/**
			 * @deprecated Will be removed in the future releases.
			 */
			select: BPMSoft.abstractFn,

			/**
			 * @deprecated Will be removed in the future releases.
			 */
			initLookupCaption: BPMSoft.abstractFn,

			/**
			 * @deprecated Will be removed in the future releases.
			 */
			getSchemaColumns: BPMSoft.abstractFn,

			/**
			 * @deprecated Will be removed in the future releases.
			 */
			needLoadData: BPMSoft.abstractFn,

			/**
			 * @deprecated Will be removed in the future releases.
			 */
			isValidColumnDataValueType: BPMSoft.abstractFn,

			/**
			 * @deprecated Will be removed in the future releases.
			 */
			selectResult: BPMSoft.abstractFn,

			/**
			 * @deprecated Will be removed in the future releases.
			 */
			initGridData: BPMSoft.abstractFn,

			/**
			 * @deprecated Will be removed in the future releases.
			 */
			cancel: BPMSoft.abstractFn,

			/**
			 * @deprecated Will be removed in the future releases.
			 */
			close: BPMSoft.abstractFn,

			/**
			 * @deprecated Will be removed in the future releases.
			 */
			addRecord: BPMSoft.abstractFn,

			/**
			 * @deprecated Will be removed in the future releases.
			 */
			editRecord: BPMSoft.abstractFn,

			/**
			 * @deprecated Will be removed in the future releases.
			 */
			copyRecord: BPMSoft.abstractFn,

			/**
			 * @deprecated Will be removed in the future releases.
			 */
			openCard: BPMSoft.abstractFn,

			/**
			 * @deprecated Will be removed in the future releases.
			 */
			onSearchButtonClick: BPMSoft.abstractFn,

			/**
			 * @deprecated Will be removed in the future releases.
			 */
			openGridSettings: BPMSoft.abstractFn,

			/**
			 * @deprecated Will be removed in the future releases.
			 */
			getHistoryStateInfo: BPMSoft.abstractFn,

			/**
			 * @deprecated Will be removed in the future releases.
			 */
			getProfileKey: BPMSoft.abstractFn,

			/**
			 * @deprecated Will be removed in the future releases.
			 */
			getFilters: BPMSoft.abstractFn
		},
		diff: /**SCHEMA_DIFF*/[]/**SCHEMA_DIFF*/
	};
});
