define("BulkEmailTargetDetailV2",
		function() {
			return {
				entitySchemaName: "VwBulkEmailTarget",
				methods: {
					/**
					 * ########## ######### ###### ########## ######.
					 * @overridden
					 */
					getAddRecordButtonVisible: function() {
						return false;
					},

					/**
					 * @inheritdoc BPMSoft.BaseGridDetailV2#getEditRecordMenuItem
					 * @overridden
					 */
					getEditRecordMenuItem: BPMSoft.emptyFn,

					/**
					 * @inheritdoc BPMSoft.BaseGridDetailV2#getDeleteRecordMenuItem
					 * @overridden
					 */
					getDeleteRecordMenuItem: BPMSoft.emptyFn,

					/**
					 * @inheritdoc BPMSoft.BaseGridDetailV2#getCopyRecordMenuItem
					 * @overridden
					 */
					getCopyRecordMenuItem: BPMSoft.emptyFn
				},
				diff: [
					{
						"operation": "merge",
						"name": "DataGrid",
						"values": {
							type: "listed",
							listedConfig: {
								name: "DataGridListedConfig",
								items: [
									{
										name: "ContactListedGridColumn",
										bindTo: "Contact",
										position: {
											column: 1,
											colSpan: 8
										},
										type: BPMSoft.GridCellType.TITLE
									},
									{
										name: "EmailAddressListedGridColumn",
										bindTo: "EmailAddress",
										position: {
											column: 9,
											colSpan: 6
										}
									},
									{
										name: "ResponseListedGridColumn",
										bindTo: "BulkEmailResponse",
										position: {
											column: 15,
											colSpan: 4
										}
									},
									{
										name: "OpensListedGridColumn",
										bindTo: "Opens",
										position: {
											column: 19,
											colSpan: 3
										}
									},
									{
										name: "ClicksListedGridColumn",
										bindTo: "Clicks",
										position: {
											column: 22,
											colSpan: 3
										}
									}
								]
							},
							tiledConfig: {
								name: "DataGridTiledConfig",
								grid: {
									columns: 24,
									rows: 2
								},
								items: [
									{
										name: "ContactTiledGridColumn",
										bindTo: "Contact",
										position: {
											row: 1,
											column: 1,
											colSpan: 11
										},
										type: BPMSoft.GridCellType.TITLE
									},
									{
										name: "EmailAddressTiledGridColumn",
										bindTo: "EmailAddress",
										position: {
											row: 1,
											column: 13,
											colSpan: 11
										}
									},
									{
										name: "ResponseTiledGridColumn",
										bindTo: "BulkEmailResponse",
										position: {
											row: 2,
											column: 1,
											colSpan: 11
										}
									},
									{
										name: "OpensTiledGridColumn",
										bindTo: "Opens",
										position: {
											row: 2,
											column: 13,
											colSpan: 6
										}
									},
									{
										name: "ClicksTiledGridColumn",
										bindTo: "Clicks",
										position: {
											row: 2,
											column: 19,
											colSpan: 6
										}
									}
								]
							}
						}
					}
				]
			};
		}
);
