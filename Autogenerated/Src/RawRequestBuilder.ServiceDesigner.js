define("RawRequestBuilder", ["RawJsonConverter", "JsonServiceMetaDataConverter"], function() {
	return {
		methods: {

			// region Methods: Protected

			/**
			 * @inheritdoc BPMSoft.ServiceMethodBuilder#parseMethod
			 * @override
			 */
			parseMethod: function() {
				var result;
				if (this.$InputData) {
					var rawToJsonConverter = this.Ext.create("BPMSoft.RawJsonConverter");
					var json = rawToJsonConverter.convert(this.$InputData);
					if (json) {
						var jsonToParametersConverter = this.Ext.create("BPMSoft.JsonServiceMetaDataConverter", {
							codePrefix: BPMSoft.ServiceSchemaManager.schemaNamePrefix
						});
						result = jsonToParametersConverter.convert(json);
						this.prepareUri(result);
						this._prepareMethodType(result);
					}
				}
				return result;
			}

			// endregion

		}
	};
});
