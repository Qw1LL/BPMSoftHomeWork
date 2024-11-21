define("FileDetailReadOnly", [],
		function() {
			return {
				diff:/**SCHEMA_DIFF*/[
					// Removes DragAndDrop container.
					{
						"operation": "remove",
						"name": "DragAndDrop Container"
					},
					// Removes "Add file" button.
					{
						"operation": "remove",
						"name": "AddRecordButton"
					},
					// Removes action button.
					{
						"operation": "remove",
						"name": "ActionsButton"
					},
					// Removes Tools button.
					{
						"operation": "remove",
						"name": "ToolsButton"
					}
				]/**SCHEMA_DIFF*/
			};
		}
);
