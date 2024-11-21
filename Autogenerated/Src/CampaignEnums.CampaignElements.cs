namespace BPMSoft.Configuration
{

	#region Enum: StepCompletedCondition

	/// <summary>
	/// Condition that indicates the state of participants' active step copleted property for current transition.
	/// </summary>
	public enum StepCompletedCondition
	{
		/// <summary>
		/// Gets participants for which StepCompleted property is True.
		/// </summary>
		UseCompletedOnly = 0,

		/// <summary>
		/// Gets participants for which StepCompleted property is False.
		/// </summary>
		UseIncompletedOnly = 1,

		/// <summary>
		/// Gets all participants without any condition based on StepCompleted property.
		/// </summary>
		Any = 2
	}

	#endregion

	#region Enum: ConditionalSequenceFlowDelayUnit

	/// <summary>
	/// Delay units for <see cref="ConditionalSequenceFlowElement"/>.
	/// </summary>
	public enum ConditionalSequenceFlowDelayUnit
	{
		/// <summary>
		/// Delay in days.
		/// </summary>
		Days = 0,

		/// <summary>
		/// Delay in hours.
		/// </summary>
		Hours = 1
	}

	#endregion

}
