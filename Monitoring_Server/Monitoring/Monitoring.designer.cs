﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18444
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Monitoring
{
	using System.Data.Linq;
	using System.Data.Linq.Mapping;
	using System.Data;
	using System.Collections.Generic;
	using System.Reflection;
	using System.Linq;
	using System.Linq.Expressions;
	using System.ComponentModel;
	using System;
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="Monitoring")]
	public partial class MonitoringDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void InsertFakeData(FakeData instance);
    partial void UpdateFakeData(FakeData instance);
    partial void DeleteFakeData(FakeData instance);
    #endregion
		
		public MonitoringDataContext() : 
				base(global::System.Configuration.ConfigurationManager.ConnectionStrings["MonitoringConnectionString"].ConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public MonitoringDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public MonitoringDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public MonitoringDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public MonitoringDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<FakeData> FakeDatas
		{
			get
			{
				return this.GetTable<FakeData>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.FakeData")]
	public partial class FakeData : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _Id;
		
		private string _Metric;
		
		private System.Nullable<double> _Value;
		
		private System.Nullable<System.DateTime> _EventDt;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdChanging(int value);
    partial void OnIdChanged();
    partial void OnMetricChanging(string value);
    partial void OnMetricChanged();
    partial void OnValueChanging(System.Nullable<double> value);
    partial void OnValueChanged();
    partial void OnEventDtChanging(System.Nullable<System.DateTime> value);
    partial void OnEventDtChanged();
    #endregion
		
		public FakeData()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Id", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int Id
		{
			get
			{
				return this._Id;
			}
			set
			{
				if ((this._Id != value))
				{
					this.OnIdChanging(value);
					this.SendPropertyChanging();
					this._Id = value;
					this.SendPropertyChanged("Id");
					this.OnIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Metric", DbType="NVarChar(100)")]
		public string Metric
		{
			get
			{
				return this._Metric;
			}
			set
			{
				if ((this._Metric != value))
				{
					this.OnMetricChanging(value);
					this.SendPropertyChanging();
					this._Metric = value;
					this.SendPropertyChanged("Metric");
					this.OnMetricChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Value", DbType="Float")]
		public System.Nullable<double> Value
		{
			get
			{
				return this._Value;
			}
			set
			{
				if ((this._Value != value))
				{
					this.OnValueChanging(value);
					this.SendPropertyChanging();
					this._Value = value;
					this.SendPropertyChanged("Value");
					this.OnValueChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_EventDt", DbType="DateTime")]
		public System.Nullable<System.DateTime> EventDt
		{
			get
			{
				return this._EventDt;
			}
			set
			{
				if ((this._EventDt != value))
				{
					this.OnEventDtChanging(value);
					this.SendPropertyChanging();
					this._EventDt = value;
					this.SendPropertyChanged("EventDt");
					this.OnEventDtChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
}
#pragma warning restore 1591
