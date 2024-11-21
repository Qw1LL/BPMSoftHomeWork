namespace BPMSoft.Configuration
{
	using System;
	using System.Collections.Generic;

	#region Interface: IMultiOperationStrategy

	public interface IMultiOperationStrategy
	{
		/// <summary>
		/// Do operation on <paramref name="entityName"/> <paramref name="recordsId"/>.
		/// </summary>
		/// <param name="entityName">Name of entity.</param>
		/// <param name="recordsId">Unique identifiers.</param>
		void DoOperation(string entityName, List<Guid> recordsId);
	}

	#endregion

}
