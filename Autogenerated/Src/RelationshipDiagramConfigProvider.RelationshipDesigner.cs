namespace BPMSoft.Configuration.RelationshipDesigner
{
	using System;
	using BPMSoft.Core.Factories;

	public class DiagramConfiguration
	{
		public EntityConfiguration FirstLevelConfig {
			get; set;
		}
		public EntityConfiguration SecondLevelConfig {
			get; set;
		}
	}

	public class EntityConfiguration
	{
		public Guid SchemaUId {
			get; set;
		}
		public string DisplayValueColumn {
			get; set;
		}

		public string ImageColumn {
			get; set;
		}
	}

	public interface IRelationshipDiagramConfigProvider
	{
		DiagramConfiguration GetConfiguration();
	}

	[DefaultBinding(typeof(IRelationshipDiagramConfigProvider))]
	public class RelationshipDiagramConfigProvider : IRelationshipDiagramConfigProvider
	{
		public DiagramConfiguration GetConfiguration() {
			return new DiagramConfiguration {
				FirstLevelConfig = new EntityConfiguration {
					SchemaUId = Guid.Parse("25D7C1AB-1DE0-4501-B402-02E0E5A72D6E"), //account
					DisplayValueColumn = "Name",
					ImageColumn = "AccountLogoId"
				},
				SecondLevelConfig = new EntityConfiguration {
					SchemaUId = Guid.Parse("16BE3651-8FE2-4159-8DD0-A803D4683DD3"), //contact
					DisplayValueColumn = "Name",
					ImageColumn = "PhotoId"
				}
			};
		}
	}
}

