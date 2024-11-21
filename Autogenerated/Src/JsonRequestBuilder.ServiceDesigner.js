define("JsonRequestBuilder", ["JsonServiceMetaDataConverter"], function() {
	return {
		attributes: {
			SetupResponseParameters: { value: false }
		},
		methods: {

			//region Methods: Protected

			/**
			 * Returns method json structure.
			 * @returns {Object} Json structure.
			 * @protected
			 */
			prepareMethodJsonStructure: function(body) {
				return { request: { body: body } };
			},

			/**
			 * @inheritdoc BPMSoft.ServiceMethodBuilder#parseMethod
			 * @override
			 */
			parseMethod: function() {
				var result;
				var body = Ext.JSON.decode(this.$InputData, true);
				if (body) {
					var parsedJson = this.prepareMethodJsonStructure(body);
					var jsonToParametersConverter = this.Ext.create("BPMSoft.JsonServiceMetaDataConverter", {
						codePrefix: BPMSoft.ServiceSchemaManager.schemaNamePrefix
					});
					result = jsonToParametersConverter.convert(parsedJson);
				}
				return result;
			},

			/**
			 * @inheritdoc BPMSoft.ServiceMethodBuilder#getMergeOptions
			 * @override
			 */
			getMergeOptions: function() {
				return {
					skipUri: true,
					skipHttpMethodType: false
				};
			}

			//endregion

		}
	};
});
