define("RawResponseBuilder", ["JsonServiceMetaDataConverter", "RawResponseJsonConverter"], function() {
	return {
		attributes: {
			SetupRequestParameters: {value: false},
			SetupResponseParameters: {value: true}
		},
		methods: {

			// region Methods: Protected

			/**
			 * @inheritdoc BPMSoft.ServiceMethodBuilder#getMergeOptions
			 * @override
			 */
			getMergeOptions: function() {
				return {
					skipUri: true,
					skipHttpMethodType: true
				};
			},

			/**
			 * @inheritdoc BPMSoft.ServiceMethodBuilder#parseMethod
			 * @override
			 */
			parseMethod: function() {
				var result;
				if (this.$InputData) {
					var rawToJsonConverter = this.Ext.create("BPMSoft.RawResponseJsonConverter");
					var json = rawToJsonConverter.convert(this.$InputData);
					if (json) {
						var jsonToParametersConverter = this.Ext.create("BPMSoft.JsonServiceMetaDataConverter", {
							codePrefix: BPMSoft.ServiceSchemaManager.schemaNamePrefix
						});
						result = jsonToParametersConverter.convert(json);
					}
				}
				return result;
			},

			/**
			 * @inheritdoc BPMSoft.ServiceMethodBuilder#getServiceBuilderTags
			 * @override
			 */
			getServiceBuilderTags: function() {
				return ["ServiceResponseMethodBuilder"];
			}

			// endregion

		}
	};
});
