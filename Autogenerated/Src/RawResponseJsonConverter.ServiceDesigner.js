define("RawResponseJsonConverter", ["RawConverter", "RawJsonConverter"],
	function(RawConverter) {
		Ext.define("BPMSoft.services.RawResponseJsonConverter", {
			alternateClassName: "BPMSoft.RawResponseJsonConverter",
			extend: "BPMSoft.RawJsonConverter",

			//region Methods: Public

			/**
			 * @inheritdoc BPMSoft.RawJsonConverter#convert
			 * @override
			 */
			convert: function() {
				this.rawType = RawConverter.RESPONSE;
				const result = this.callParent(arguments);
				result[this.sectionResponse] = result[this.sectionRequest];
				delete result[this.sectionRequest];
				return result;
			}

			//endregion

		});

		return BPMSoft.RawResponseJsonConverter;
});
