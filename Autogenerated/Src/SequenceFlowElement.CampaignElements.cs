namespace BPMSoft.Configuration
{
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Drawing;
	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Campaign;
	using BPMSoft.Core.Campaign.Interfaces;
	using BPMSoft.Core.Process;

	#region Class: SequenceFlowElement

	[DesignModeProperty(Name = "SourceRefUId",
		UsageType = DesignModeUsageType.NotVisible, MetaPropertyName = SourceRefUIdPropertyName)]
	[DesignModeProperty(Name = "TargetRefUId",
		UsageType = DesignModeUsageType.NotVisible, MetaPropertyName = TargetRefUIdPropertyName)]
	[DesignModeProperty(Name = "FlowType", IsReadOnly = true,
		UsageType = DesignModeUsageType.None, MetaPropertyName = FlowTypePropertyName)]
	[DesignModeProperty(Name = "StrokeColor", MetaPropertyName = StrokeColorPropertyName,
		UsageType = DesignModeUsageType.None)]
	[DesignModeProperty(Name = "VisualType", IsReadOnly = true,
		UsageType = DesignModeUsageType.None, MetaPropertyName = VisualTypePropertyName)]
	[DesignModeProperty(Name = "SourceSequenceFlowPointLocalPosition",
		UsageType = DesignModeUsageType.NotVisible,
		MetaPropertyName = SourceSequenceFlowPointLocalPositionPropertyName)]
	[DesignModeProperty(Name = "TargetSequenceFlowPointLocalPosition",
		UsageType = DesignModeUsageType.NotVisible,
		MetaPropertyName = TargetSequenceFlowPointLocalPositionPropertyName)]
	[DesignModeProperty(Name = "CurveCenterPosition",
		UsageType = DesignModeUsageType.None, MetaPropertyName = CurveCenterPositionPropertyName)]
	[DesignModeProperty(Name = "PolylinePointPositions",
		UsageType = DesignModeUsageType.NotVisible, MetaPropertyName = PolylinePointPositionsPropertyName)]
	[DesignModeProperty(Name = "IsSynchronous",
		UsageType = DesignModeUsageType.NotVisible, MetaPropertyName = IsSynchronousPropertyName)]
	[DesignModeProperty(Name = "Priority",
		UsageType = DesignModeUsageType.NotVisible, MetaPropertyName = PriorityPropertyName)]
	[DesignModeProperty(Name = "StepCompletedCondition",
		UsageType = DesignModeUsageType.NotVisible, MetaPropertyName = StepCompletedConditionPropertyName)]
	[DesignModeProperty(Name = "SequenceFlowStartPointPosition",
		UsageType = DesignModeUsageType.NotVisible,
		MetaPropertyName = SequenceFlowStartPointPositionPropertyName)]
	[DesignModeProperty(Name = "SequenceFlowEndPointPosition",
		UsageType = DesignModeUsageType.NotVisible,
		MetaPropertyName = SequenceFlowEndPointPositionPropertyName)]
	public class SequenceFlowElement : CampaignSchemaElement, ITransitionPriority
	{

		#region Constants: Private

		private const string SourceRefUIdPropertyName = "SourceRefUId";
		private const string TargetRefUIdPropertyName = "TargetRefUId";
		private const string FlowTypePropertyName = "FlowType";
		private const string StrokeColorPropertyName = "StrokeColor";
		private const string VisualTypePropertyName = "VisualType";
		private const string SourceSequenceFlowPointLocalPositionPropertyName = "SourceSequenceFlowPointLocalPosition";
		private const string TargetSequenceFlowPointLocalPositionPropertyName = "TargetSequenceFlowPointLocalPosition";
		private const string CurveCenterPositionPropertyName = "CurveCenterPosition";
		private const string PolylinePointPositionsPropertyName = "PolylinePointPositions";
		private const string IsSynchronousPropertyName = "IsSynchronous";
		private const string PriorityPropertyName = "Priority";
		private const string StepCompletedConditionPropertyName = "StepCompletedCondition";
		private const string SequenceFlowStartPointPositionPropertyName = "SequenceFlowStartPointPosition";
		private const string SequenceFlowEndPointPositionPropertyName = "SequenceFlowEndPointPosition";

		#endregion

		#region Constructors: Public

		public SequenceFlowElement() {
			StepCompletedCondition = StepCompletedCondition.UseCompletedOnly;
			ElementType = CampaignSchemaElementType.Transition | CampaignSchemaElementType.Sessioned;
			StrokeColor = Color.FromArgb(0xff, 0x93, 0x95, 0x98);
		}

		/// <summary>
		/// Constructor of the clone.
		/// </summary>
		/// <param name="source">Instance of <see cref="SequenceFlowElement"/>.</param>
		public SequenceFlowElement(SequenceFlowElement source)
				: this(source, null, null) {
		}

		/// <summary>
		/// Constructor of the copy.
		/// </summary>
		/// <param name="source">Instance of <see cref="SequenceFlowElement"/>.</param>
		/// <param name="dictToRebind">Dictionary to rebind schema elements' ids.</param>
		/// <param name="parentSchema">Parent campaign schema.</param>
		public SequenceFlowElement(SequenceFlowElement source, Dictionary<Guid, Guid> dictToRebind,
				Core.Campaign.CampaignSchema parentSchema) : base(source, dictToRebind, parentSchema) {
			if (dictToRebind == null) {
				_sourceRefUId = source.SourceRefUId;
				_targetRefUId = source.TargetRefUId;
			} else {
				_sourceRefUId = dictToRebind[source.SourceRefUId];
				_targetRefUId = dictToRebind[source.TargetRefUId];
				_isSourceRefInitialized = false;
				_isTargetRefInitialized = false;
			}
			FlowType = source.FlowType;
			StrokeColor = source.StrokeColor;
			VisualType = source.VisualType;
			SourceSequenceFlowPointLocalPosition = source.SourceSequenceFlowPointLocalPosition;
			TargetSequenceFlowPointLocalPosition = source.TargetSequenceFlowPointLocalPosition;
			CurveCenterPosition = source.CurveCenterPosition;
			IsSynchronous = source.IsSynchronous;
			Priority = source.Priority;
			StepCompletedCondition = source.StepCompletedCondition;
			_polylinePointPositions = new Collection<Point>(source.PolylinePointPositions);
		}

		#endregion

		#region Properties: Protected

		/// <summary>
		/// Identifier of element action.
		/// </summary>
		protected override Guid Action {
			get {
				return CampaignConsts.CampaignLogTypeSequenceFlow;
			}
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Reference on the source element.
		/// </summary>
		private bool _isSourceRefInitialized;
		private CampaignSchemaElement _sourceRef;
		public CampaignSchemaElement SourceRef {
			get {
				if (_isSourceRefInitialized) {
					return _sourceRef;
				}
				_sourceRef = Guid.Empty.Equals(SourceRefUId) ? null :
					ParentSchema.GetBaseElementByUId(SourceRefUId);
				_isSourceRefInitialized = true;
				return _sourceRef;
			}
			set {
				if (_sourceRef == value) {
					return;
				}
				_sourceRef = value;
				_sourceRefUId = (_sourceRef == null) ? Guid.Empty : _sourceRef.UId;
				_isSourceRefInitialized = true;
			}
		}

		/// <summary>
		/// Reference on the target element.
		/// </summary>
		private bool _isTargetRefInitialized;
		private CampaignSchemaElement _targetRef;
		public CampaignSchemaElement TargetRef {
			get {
				if (_isTargetRefInitialized) {
					return _targetRef;
				}
				_targetRef = Guid.Empty.Equals(TargetRefUId) ? null :
					ParentSchema.GetBaseElementByUId(TargetRefUId);
				_isTargetRefInitialized = true;
				return _targetRef;
			}
			set {
				if (_targetRef == value) {
					return;
				}
				_targetRef = value;
				_targetRefUId = (_targetRef == null) ? Guid.Empty : _targetRef.UId;
				_isTargetRefInitialized = true;
			}
		}

		/// <summary>
		/// Unique identifier of the source element.
		/// </summary>
		private Guid _sourceRefUId;
		[MetaTypeProperty("{89498F96-54D2-4C34-8561-069E6C4AD8B3}")]
		public Guid SourceRefUId {
			get {
				return _sourceRefUId;
			}
			set {
				if (Equals(_sourceRefUId, value)) {
					return;
				}
				if (!Guid.Empty.Equals(_sourceRefUId)) {
					(ParentSchema.GetBaseElementByUId(SourceRefUId)).Outgoings.Remove(this);
				}
				_sourceRefUId = value;
				_isSourceRefInitialized = false;
				_sourceRef = null;
				if (_sourceRefUId.Equals(Guid.Empty)) {
					return;
				}
				CampaignSchemaElement sourceElement = ParentSchema.GetBaseElementByUId(_sourceRefUId);
				sourceElement.Outgoings.Add(this);
				Incomings.Clear();
				Incomings.Add(sourceElement);
			}
		}

		/// <summary>
		/// Unique identifier of the target element.
		/// </summary>
		private Guid _targetRefUId;
		[MetaTypeProperty("{47B6E840-A4AA-4AC0-97B4-B6E4122FE1D5}")]
		public Guid TargetRefUId {
			get {
				return _targetRefUId;
			}
			set {
				if (Equals(_targetRefUId, value)) {
					return;
				}
				if (!Guid.Empty.Equals(_targetRefUId)) {
					(ParentSchema.GetBaseElementByUId(_targetRefUId)).Incomings.Remove(this);
				}
				_targetRefUId = value;
				_isTargetRefInitialized = false;
				_targetRef = null;
				if (_targetRefUId.Equals(Guid.Empty)) {
					return;
				}
				CampaignSchemaElement targetElement = ParentSchema.GetBaseElementByUId(_targetRefUId);
				targetElement.Incomings.Add(this);
				Outgoings.Clear();
				Outgoings.Add(targetElement);
			}
		}

		/// <summary>
		/// Type of the sequence flow.
		/// </summary>
		[MetaTypeProperty("{923B256C-8932-458C-96DF-011874FA510B}")]
		public ProcessSchemaEditSequenceFlowType FlowType {
			get;
			set;
		}

		/// <summary>
		/// Sign for the synchronous transition.
		/// </summary>
		[MetaTypeProperty("{A6DCFA14-1AA5-499C-9A3E-6B2C60FCEFBF}")]
		public bool IsSynchronous {
			get;
			set;
		}

		/// <summary>
		/// Priority of the transition.
		/// </summary>
		[MetaTypeProperty("{E2F30603-5591-4431-8343-2F5658FD8789}")]
		public virtual int Priority {
			get;
			set;
		}

		/// <summary>
		/// Condition that indicates wich query condition to apply for StepCompleted property.
		/// </summary>
		[MetaTypeProperty("{1D77988B-63D4-4828-A695-F5ED5AEE4810}")]
		public StepCompletedCondition StepCompletedCondition {
			get;
			set;
		}

		/// <summary>
		/// Color of the line.
		/// </summary>
		[MetaTypeProperty("{7BCFF276-7F9C-47A9-900D-270BD4BA7D4B}")]
		public Color StrokeColor {
			get; set;
		}

		/// <summary>
		/// Visual type of the sequence flow.
		/// </summary>
		[MetaTypeProperty("{EED35DD8-AA4F-4C78-AD81-6C1278B8A68F}")]
		public ProcessSchemaSequenceFlowVisualType VisualType {
			get;
			set;
		}

		/// <summary>
		/// Position on the source element.
		/// </summary>
		[MetaTypeProperty("{EF1E721C-F77F-42CF-9824-9D32C9CFDB4C}")]
		public Point SourceSequenceFlowPointLocalPosition {
			get;
			set;
		}

		/// <summary>
		/// Position on the target element.
		/// </summary>
		[MetaTypeProperty("{434D9100-F963-4FE2-8FCA-4B3691E1FED1}")]
		public Point TargetSequenceFlowPointLocalPosition {
			get;
			set;
		}

		/// <summary>
		/// Position of the curve center.
		/// </summary>
		[MetaTypeProperty("{C3E8946E-B6E8-4EBA-B6F4-5DC788A038EB}")]
		public Point CurveCenterPosition {
			get;
			set;
		}

		/// <summary>
		/// Start point position for transition.
		/// </summary>
		[MetaTypeProperty("{A8221368-CF35-4D49-92E1-C6B58C41477D}")]
		public Point SequenceFlowStartPointPosition {
			get;
			set;
		}

		/// <summary>
		/// End point position for transition.
		/// </summary>
		[MetaTypeProperty("{3BC56237-3DB4-4A26-A644-200AB43EB9F4}")]
		public Point SequenceFlowEndPointPosition {
			get;
			set;
		}

		/// <summary>
		/// Positions of the polyline points.
		/// </summary>
		private Collection<Point> _polylinePointPositions;
		[MetaTypeProperty("{A596186B-75C6-4F4A-A137-CE6B1A3AE564}")]
		public Collection<Point> PolylinePointPositions {
			get {
				return _polylinePointPositions ??
					(_polylinePointPositions = new Collection<Point>());
			}
		}

		/// <summary>
		/// Sign for polyline points exist.
		/// </summary>
		public bool HasPolylinePointPositions {
			get {
				return (_polylinePointPositions != null) && (_polylinePointPositions.Count > 0);
			}
		}

		#endregion

		#region Methods: Protected

		/// <summary>
		/// Reads MetaData values to element properties.
		/// </summary>
		protected override void ApplyMetaDataValue(DataReader reader) {
			base.ApplyMetaDataValue(reader);
			switch (reader.CurrentName) {
				case SourceRefUIdPropertyName:
					SourceRefUId = reader.GetGuidValue();
					break;
				case TargetRefUIdPropertyName:
					TargetRefUId = reader.GetGuidValue();
					break;
				case FlowTypePropertyName:
					FlowType = reader.GetEnumValue<ProcessSchemaEditSequenceFlowType>();
					break;
				case StrokeColorPropertyName:
					StrokeColor = reader.GetValue<Color>();
					break;
				case VisualTypePropertyName:
					VisualType = reader.GetEnumValue<ProcessSchemaSequenceFlowVisualType>();
					break;
				case SourceSequenceFlowPointLocalPositionPropertyName:
					SourceSequenceFlowPointLocalPosition = reader.GetValue<Point>();
					break;
				case TargetSequenceFlowPointLocalPositionPropertyName:
					TargetSequenceFlowPointLocalPosition = reader.GetValue<Point>();
					break;
				case CurveCenterPositionPropertyName:
					CurveCenterPosition = reader.GetValue<Point>();
					break;
				case PolylinePointPositionsPropertyName:
					reader.ReadInto();
					_polylinePointPositions = reader.GetValue<Collection<Point>>();
					reader.ReadOut();
					break;
				case IsSynchronousPropertyName:
					IsSynchronous = reader.GetBoolValue();
					break;
				case StepCompletedConditionPropertyName:
					StepCompletedCondition = reader.GetEnumValue<StepCompletedCondition>();
					break;
				case PriorityPropertyName:
					Priority = reader.GetIntValue();
					break;
				case SequenceFlowStartPointPositionPropertyName:
					SequenceFlowStartPointPosition = reader.GetValue<Point>();
					break;
				case SequenceFlowEndPointPositionPropertyName:
					SequenceFlowEndPointPosition = reader.GetValue<Point>();
					break;
				default:
					break;
			}
		}

		/// <summary>
		/// Initializes transition flow element properties.
		/// </summary>
		protected void InitializeCampaignTransitionFlowElement(CampaignTransitionProcessElement element) {
			element.SourceItemId = SourceRefUId;
			element.TargetItemId = TargetRefUId;
			element.StepCompletedCondition = StepCompletedCondition;
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Writes meta data values.
		/// </summary>
		/// <param name="writer">Instance of the <see cref="DataWriter"/> type.</param>
		public override void WriteMetaData(DataWriter writer) {
			base.WriteMetaData(writer);
			writer.WriteValue(SourceRefUIdPropertyName, SourceRefUId, Guid.Empty);
			writer.WriteValue(TargetRefUIdPropertyName, TargetRefUId, Guid.Empty);
			writer.WriteValue(FlowTypePropertyName, FlowType, ProcessSchemaEditSequenceFlowType.Sequence);
			writer.WriteValue(StrokeColorPropertyName, typeof(Color), StrokeColor,
				Color.FromArgb(0xff, 0x93, 0x95, 0x98));
			writer.WriteValue(VisualTypePropertyName, ProcessSchemaSequenceFlowVisualType.AutoPolyline,
				ProcessSchemaSequenceFlowVisualType.Curve);
			writer.WriteValue(SourceSequenceFlowPointLocalPositionPropertyName, typeof(Point),
				SourceSequenceFlowPointLocalPosition, Point.Empty);
			writer.WriteValue(TargetSequenceFlowPointLocalPositionPropertyName, typeof(Point),
				TargetSequenceFlowPointLocalPosition, Point.Empty);
			writer.WriteValue(CurveCenterPositionPropertyName, typeof(Point), CurveCenterPosition, Point.Empty);
			writer.WriteValue(IsSynchronousPropertyName, IsSynchronous, false);
			writer.WriteValue(PriorityPropertyName, Priority, 0);
			writer.WriteValue(StepCompletedConditionPropertyName, StepCompletedCondition,
				StepCompletedCondition.UseCompletedOnly);
			writer.WriteValue(SequenceFlowStartPointPositionPropertyName, typeof(Point),
				SequenceFlowStartPointPosition, Point.Empty);
			writer.WriteValue(SequenceFlowEndPointPositionPropertyName, typeof(Point),
				SequenceFlowEndPointPosition, Point.Empty);
			if (HasPolylinePointPositions) {
				writer.WriteStartObject(PolylinePointPositionsPropertyName);
				writer.WriteValue(ProcessKeyWords.ItemCollectionPrefix, typeof(Collection<Point>),
					PolylinePointPositions, null);
				writer.WriteFinishObject();
			}
		}

		/// <summary>
		/// Creates a new instance that is a clone of the current instance.
		/// </summary>
		/// <returns>Cloned instance of the SequenceFlowElement.</returns>
		public override object Clone() {
			return new SequenceFlowElement(this);
		}

		/// <summary>
		/// Creates a new instance that is a copy of the current instance.
		/// </summary>
		/// <param name="dictToRebind">Dictionary to rebind schema elements' ids.</param>
		/// <param name="parentSchema">Parent campaign schema.</param>
		/// <returns>Copied instance of the SequenceFlowElement.</returns>
		public override object Copy(Dictionary<Guid, Guid> dictToRebind, Core.Campaign.CampaignSchema parentSchema) {
			return new SequenceFlowElement(this, dictToRebind, parentSchema);
		}

		/// <summary>
		/// Creates executable instance
		/// </summary>
		public override ProcessFlowElement CreateProcessFlowElement(UserConnection userConnection) {
			var executableElement = new CampaignTransitionProcessElement {
				UserConnection = userConnection
			};
			InitializeCampaignProcessFlowElement(executableElement);
			InitializeCampaignTransitionFlowElement(executableElement);
			return executableElement;
		}

		#endregion

	}

	#endregion

}

