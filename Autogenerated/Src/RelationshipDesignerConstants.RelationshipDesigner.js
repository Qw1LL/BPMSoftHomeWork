define("RelationshipDesignerConstants", [], function() {
	var connectionType = {
		Formal: "56d730bf-27f5-42d9-83df-183df2ec06a1",
		NotFormal: "6d1d2243-d4de-4d64-aab4-23eed4021a60"
	};
	var relationTypePosition = {
		Direct: "0048f78f-4a26-4fa0-806b-dce39965e551",
		Horizontal: "ac09ef67-6e34-4fee-9f36-b5bf771e3537",
		Reverse: "1eee8ed0-2615-4e32-946c-304e199fa8c7"
	};
	return {
		ConnectionType: connectionType,
		RelationTypePosition: relationTypePosition
	};
});
