﻿namespace BPMSoft.Configuration.FileImport
{
	using BPMSoft.Core;

	/// <summary>
	/// Represents method for create columns aggregator
	/// </summary>
	public interface IColumnsAggregatorFactory
	{
		/// <summary>
		/// Create columns aggregator
		/// </summary>
		/// <param name="userConnection"></param>
		/// <returns><see cref="INonPersistentColumnsAggregator"/></returns>
		IColumnsAggregatorAdapter GetColumnsAggregator(UserConnection userConnection);
	}
}
