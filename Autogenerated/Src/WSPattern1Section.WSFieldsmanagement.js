define("WSPattern1Section", [], function() {
	return {
		entitySchemaName: "WSPattern",
		details: /**SCHEMA_DETAILS*/{}/**SCHEMA_DETAILS*/,
		diff: /**SCHEMA_DIFF*/[]/**SCHEMA_DIFF*/,
		methods: {
			getActiveViewCaption: function() {
				if (this.get("Resources.Strings.Caption")) {
					return this.get("Resources.Strings.Caption");
				} else {
					return this.callParent(arguments);
				}
			},
			
			initAddRecordButtonParameters: function() {
				this.callParent(arguments);
				if (this.get("Resources.Strings.AddRecordButtonCaption")){
					this.set("AddRecordButtonCaption", this.get("Resources.Strings.AddRecordButtonCaption"));
				}
			},
		}
	};
});
