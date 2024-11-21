define("ColumnTypedDestinationViewModel", ["ColumnDestinationViewModel"], function() {
	Ext.define("BPMSoft.configuration.ColumnTypedDestinationViewModel", {
		alternateClassName: "BPMSoft.ColumnTypedDestinationViewModel",
		extend: "BPMSoft.ColumnDestinationViewModel",

		// region Methods: Private

		/**
		 * Returns property value bu its name.
		 * @private
		 * @param {String} propertyName Property name.
		 * @return {String} Property value.
		 */
		getPropertyValue: function(propertyName) {
			var properties = this.get("Properties");
			var matchingProperties = BPMSoft.where(properties, {
				Key: propertyName
			});
			var matchingProperty = matchingProperties.pop();
			return matchingProperty.Value;
		},

		// endregion

		// region Methods: Protected

		/**
		 * Returns attribute column value name.
		 * @protected
		 * @return {String} Attribute column value name.
		 */
		getAttributeColumnValueName: function() {
			return this.getPropertyValue("AttributeColumnValueName");
		},

		// endregion

		//region Methods: Public

		/**
		 * @inheritdoc
		 * @overridden
		 */
		getSerializableObject: function() {
			var serializableObject = this.callParent(arguments);
			var type = this.get("Type");
			var attributes = serializableObject.attributes = [];
			attributes.push({
				Key: this.getAttributeColumnValueName(),
				Value: type.value
			});
			return serializableObject;
		},

		/**
		 * Returns index.
		 * @return {String} Index.
		 */
		getIndex: function() {
			return this.getPropertyValue("Index");
		}

		//endregion
	});
});
