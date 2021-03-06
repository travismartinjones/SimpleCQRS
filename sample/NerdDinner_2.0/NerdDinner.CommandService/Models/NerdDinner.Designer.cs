﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Data.Objects;
using System.Data.Objects.DataClasses;
using System.Data.EntityClient;
using System.ComponentModel;
using System.Xml.Serialization;
using System.Runtime.Serialization;

[assembly: EdmSchemaAttribute()]

namespace NerdDinner.CommandService.Models
{
    #region Contexts
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    public partial class NerdDinnerEntities : ObjectContext
    {
        #region Constructors
    
        /// <summary>
        /// Initializes a new NerdDinnerEntities object using the connection string found in the 'NerdDinnerEntities' section of the application configuration file.
        /// </summary>
        public NerdDinnerEntities() : base("name=NerdDinnerEntities", "NerdDinnerEntities")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        /// <summary>
        /// Initialize a new NerdDinnerEntities object.
        /// </summary>
        public NerdDinnerEntities(string connectionString) : base(connectionString, "NerdDinnerEntities")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        /// <summary>
        /// Initialize a new NerdDinnerEntities object.
        /// </summary>
        public NerdDinnerEntities(EntityConnection connection) : base(connection, "NerdDinnerEntities")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        #endregion
    
        #region Partial Methods
    
        partial void OnContextCreated();
    
        #endregion
    
        #region ObjectSet Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        public ObjectSet<UserReadModel> UserReadModels
        {
            get
            {
                if ((_UserReadModels == null))
                {
                    _UserReadModels = base.CreateObjectSet<UserReadModel>("UserReadModels");
                }
                return _UserReadModels;
            }
        }
        private ObjectSet<UserReadModel> _UserReadModels;
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        public ObjectSet<DinnerReadModel> DinnerReadModels
        {
            get
            {
                if ((_DinnerReadModels == null))
                {
                    _DinnerReadModels = base.CreateObjectSet<DinnerReadModel>("DinnerReadModels");
                }
                return _DinnerReadModels;
            }
        }
        private ObjectSet<DinnerReadModel> _DinnerReadModels;
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        public ObjectSet<PopularDinnerReadModel> PopularDinnerReadModels
        {
            get
            {
                if ((_PopularDinnerReadModels == null))
                {
                    _PopularDinnerReadModels = base.CreateObjectSet<PopularDinnerReadModel>("PopularDinnerReadModels");
                }
                return _PopularDinnerReadModels;
            }
        }
        private ObjectSet<PopularDinnerReadModel> _PopularDinnerReadModels;
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        public ObjectSet<RsvpReadModel> RsvpReadModels
        {
            get
            {
                if ((_RsvpReadModels == null))
                {
                    _RsvpReadModels = base.CreateObjectSet<RsvpReadModel>("RsvpReadModels");
                }
                return _RsvpReadModels;
            }
        }
        private ObjectSet<RsvpReadModel> _RsvpReadModels;

        #endregion
        #region AddTo Methods
    
        /// <summary>
        /// Deprecated Method for adding a new object to the UserReadModels EntitySet. Consider using the .Add method of the associated ObjectSet&lt;T&gt; property instead.
        /// </summary>
        public void AddToUserReadModels(UserReadModel userReadModel)
        {
            base.AddObject("UserReadModels", userReadModel);
        }
    
        /// <summary>
        /// Deprecated Method for adding a new object to the DinnerReadModels EntitySet. Consider using the .Add method of the associated ObjectSet&lt;T&gt; property instead.
        /// </summary>
        public void AddToDinnerReadModels(DinnerReadModel dinnerReadModel)
        {
            base.AddObject("DinnerReadModels", dinnerReadModel);
        }
    
        /// <summary>
        /// Deprecated Method for adding a new object to the PopularDinnerReadModels EntitySet. Consider using the .Add method of the associated ObjectSet&lt;T&gt; property instead.
        /// </summary>
        public void AddToPopularDinnerReadModels(PopularDinnerReadModel popularDinnerReadModel)
        {
            base.AddObject("PopularDinnerReadModels", popularDinnerReadModel);
        }
    
        /// <summary>
        /// Deprecated Method for adding a new object to the RsvpReadModels EntitySet. Consider using the .Add method of the associated ObjectSet&lt;T&gt; property instead.
        /// </summary>
        public void AddToRsvpReadModels(RsvpReadModel rsvpReadModel)
        {
            base.AddObject("RsvpReadModels", rsvpReadModel);
        }

        #endregion
    }
    

    #endregion
    
    #region Entities
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="NerdDinnerModel", Name="DinnerReadModel")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class DinnerReadModel : EntityObject
    {
        #region Factory Method
    
        /// <summary>
        /// Create a new DinnerReadModel object.
        /// </summary>
        /// <param name="dinnerId">Initial value of the DinnerId property.</param>
        /// <param name="title">Initial value of the Title property.</param>
        /// <param name="eventDate">Initial value of the EventDate property.</param>
        /// <param name="description">Initial value of the Description property.</param>
        public static DinnerReadModel CreateDinnerReadModel(global::System.Guid dinnerId, global::System.String title, global::System.DateTime eventDate, global::System.String description)
        {
            DinnerReadModel dinnerReadModel = new DinnerReadModel();
            dinnerReadModel.DinnerId = dinnerId;
            dinnerReadModel.Title = title;
            dinnerReadModel.EventDate = eventDate;
            dinnerReadModel.Description = description;
            return dinnerReadModel;
        }

        #endregion
        #region Primitive Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Guid DinnerId
        {
            get
            {
                return _DinnerId;
            }
            set
            {
                if (_DinnerId != value)
                {
                    OnDinnerIdChanging(value);
                    ReportPropertyChanging("DinnerId");
                    _DinnerId = StructuralObject.SetValidValue(value);
                    ReportPropertyChanged("DinnerId");
                    OnDinnerIdChanged();
                }
            }
        }
        private global::System.Guid _DinnerId;
        partial void OnDinnerIdChanging(global::System.Guid value);
        partial void OnDinnerIdChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String Title
        {
            get
            {
                return _Title;
            }
            set
            {
                OnTitleChanging(value);
                ReportPropertyChanging("Title");
                _Title = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("Title");
                OnTitleChanged();
            }
        }
        private global::System.String _Title;
        partial void OnTitleChanging(global::System.String value);
        partial void OnTitleChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.DateTime EventDate
        {
            get
            {
                return _EventDate;
            }
            set
            {
                OnEventDateChanging(value);
                ReportPropertyChanging("EventDate");
                _EventDate = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("EventDate");
                OnEventDateChanged();
            }
        }
        private global::System.DateTime _EventDate;
        partial void OnEventDateChanging(global::System.DateTime value);
        partial void OnEventDateChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String Description
        {
            get
            {
                return _Description;
            }
            set
            {
                OnDescriptionChanging(value);
                ReportPropertyChanging("Description");
                _Description = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("Description");
                OnDescriptionChanged();
            }
        }
        private global::System.String _Description;
        partial void OnDescriptionChanging(global::System.String value);
        partial void OnDescriptionChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<global::System.Guid> HostedById
        {
            get
            {
                return _HostedById;
            }
            set
            {
                OnHostedByIdChanging(value);
                ReportPropertyChanging("HostedById");
                _HostedById = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("HostedById");
                OnHostedByIdChanged();
            }
        }
        private Nullable<global::System.Guid> _HostedById;
        partial void OnHostedByIdChanging(Nullable<global::System.Guid> value);
        partial void OnHostedByIdChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String HostedBy
        {
            get
            {
                return _HostedBy;
            }
            set
            {
                OnHostedByChanging(value);
                ReportPropertyChanging("HostedBy");
                _HostedBy = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("HostedBy");
                OnHostedByChanged();
            }
        }
        private global::System.String _HostedBy;
        partial void OnHostedByChanging(global::System.String value);
        partial void OnHostedByChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String ContactPhone
        {
            get
            {
                return _ContactPhone;
            }
            set
            {
                OnContactPhoneChanging(value);
                ReportPropertyChanging("ContactPhone");
                _ContactPhone = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("ContactPhone");
                OnContactPhoneChanged();
            }
        }
        private global::System.String _ContactPhone;
        partial void OnContactPhoneChanging(global::System.String value);
        partial void OnContactPhoneChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String Address
        {
            get
            {
                return _Address;
            }
            set
            {
                OnAddressChanging(value);
                ReportPropertyChanging("Address");
                _Address = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("Address");
                OnAddressChanged();
            }
        }
        private global::System.String _Address;
        partial void OnAddressChanging(global::System.String value);
        partial void OnAddressChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String Country
        {
            get
            {
                return _Country;
            }
            set
            {
                OnCountryChanging(value);
                ReportPropertyChanging("Country");
                _Country = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("Country");
                OnCountryChanged();
            }
        }
        private global::System.String _Country;
        partial void OnCountryChanging(global::System.String value);
        partial void OnCountryChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<global::System.Double> Latitude
        {
            get
            {
                return _Latitude;
            }
            set
            {
                OnLatitudeChanging(value);
                ReportPropertyChanging("Latitude");
                _Latitude = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("Latitude");
                OnLatitudeChanged();
            }
        }
        private Nullable<global::System.Double> _Latitude;
        partial void OnLatitudeChanging(Nullable<global::System.Double> value);
        partial void OnLatitudeChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<global::System.Double> Longitude
        {
            get
            {
                return _Longitude;
            }
            set
            {
                OnLongitudeChanging(value);
                ReportPropertyChanging("Longitude");
                _Longitude = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("Longitude");
                OnLongitudeChanged();
            }
        }
        private Nullable<global::System.Double> _Longitude;
        partial void OnLongitudeChanging(Nullable<global::System.Double> value);
        partial void OnLongitudeChanged();

        #endregion
    
    }
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="NerdDinnerModel", Name="PopularDinnerReadModel")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class PopularDinnerReadModel : EntityObject
    {
        #region Factory Method
    
        /// <summary>
        /// Create a new PopularDinnerReadModel object.
        /// </summary>
        /// <param name="dinnerId">Initial value of the DinnerId property.</param>
        /// <param name="title">Initial value of the Title property.</param>
        /// <param name="eventDate">Initial value of the EventDate property.</param>
        /// <param name="description">Initial value of the Description property.</param>
        public static PopularDinnerReadModel CreatePopularDinnerReadModel(global::System.Guid dinnerId, global::System.String title, global::System.DateTime eventDate, global::System.String description)
        {
            PopularDinnerReadModel popularDinnerReadModel = new PopularDinnerReadModel();
            popularDinnerReadModel.DinnerId = dinnerId;
            popularDinnerReadModel.Title = title;
            popularDinnerReadModel.EventDate = eventDate;
            popularDinnerReadModel.Description = description;
            return popularDinnerReadModel;
        }

        #endregion
        #region Primitive Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Guid DinnerId
        {
            get
            {
                return _DinnerId;
            }
            set
            {
                if (_DinnerId != value)
                {
                    OnDinnerIdChanging(value);
                    ReportPropertyChanging("DinnerId");
                    _DinnerId = StructuralObject.SetValidValue(value);
                    ReportPropertyChanged("DinnerId");
                    OnDinnerIdChanged();
                }
            }
        }
        private global::System.Guid _DinnerId;
        partial void OnDinnerIdChanging(global::System.Guid value);
        partial void OnDinnerIdChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String Title
        {
            get
            {
                return _Title;
            }
            set
            {
                OnTitleChanging(value);
                ReportPropertyChanging("Title");
                _Title = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("Title");
                OnTitleChanged();
            }
        }
        private global::System.String _Title;
        partial void OnTitleChanging(global::System.String value);
        partial void OnTitleChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.DateTime EventDate
        {
            get
            {
                return _EventDate;
            }
            set
            {
                OnEventDateChanging(value);
                ReportPropertyChanging("EventDate");
                _EventDate = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("EventDate");
                OnEventDateChanged();
            }
        }
        private global::System.DateTime _EventDate;
        partial void OnEventDateChanging(global::System.DateTime value);
        partial void OnEventDateChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String Description
        {
            get
            {
                return _Description;
            }
            set
            {
                OnDescriptionChanging(value);
                ReportPropertyChanging("Description");
                _Description = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("Description");
                OnDescriptionChanged();
            }
        }
        private global::System.String _Description;
        partial void OnDescriptionChanging(global::System.String value);
        partial void OnDescriptionChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<global::System.Guid> HostedById
        {
            get
            {
                return _HostedById;
            }
            set
            {
                OnHostedByIdChanging(value);
                ReportPropertyChanging("HostedById");
                _HostedById = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("HostedById");
                OnHostedByIdChanged();
            }
        }
        private Nullable<global::System.Guid> _HostedById;
        partial void OnHostedByIdChanging(Nullable<global::System.Guid> value);
        partial void OnHostedByIdChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String HostedBy
        {
            get
            {
                return _HostedBy;
            }
            set
            {
                OnHostedByChanging(value);
                ReportPropertyChanging("HostedBy");
                _HostedBy = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("HostedBy");
                OnHostedByChanged();
            }
        }
        private global::System.String _HostedBy;
        partial void OnHostedByChanging(global::System.String value);
        partial void OnHostedByChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String ContactPhone
        {
            get
            {
                return _ContactPhone;
            }
            set
            {
                OnContactPhoneChanging(value);
                ReportPropertyChanging("ContactPhone");
                _ContactPhone = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("ContactPhone");
                OnContactPhoneChanged();
            }
        }
        private global::System.String _ContactPhone;
        partial void OnContactPhoneChanging(global::System.String value);
        partial void OnContactPhoneChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String Address
        {
            get
            {
                return _Address;
            }
            set
            {
                OnAddressChanging(value);
                ReportPropertyChanging("Address");
                _Address = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("Address");
                OnAddressChanged();
            }
        }
        private global::System.String _Address;
        partial void OnAddressChanging(global::System.String value);
        partial void OnAddressChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String Country
        {
            get
            {
                return _Country;
            }
            set
            {
                OnCountryChanging(value);
                ReportPropertyChanging("Country");
                _Country = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("Country");
                OnCountryChanged();
            }
        }
        private global::System.String _Country;
        partial void OnCountryChanging(global::System.String value);
        partial void OnCountryChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<global::System.Double> Latitude
        {
            get
            {
                return _Latitude;
            }
            set
            {
                OnLatitudeChanging(value);
                ReportPropertyChanging("Latitude");
                _Latitude = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("Latitude");
                OnLatitudeChanged();
            }
        }
        private Nullable<global::System.Double> _Latitude;
        partial void OnLatitudeChanging(Nullable<global::System.Double> value);
        partial void OnLatitudeChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<global::System.Double> Longitude
        {
            get
            {
                return _Longitude;
            }
            set
            {
                OnLongitudeChanging(value);
                ReportPropertyChanging("Longitude");
                _Longitude = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("Longitude");
                OnLongitudeChanged();
            }
        }
        private Nullable<global::System.Double> _Longitude;
        partial void OnLongitudeChanging(Nullable<global::System.Double> value);
        partial void OnLongitudeChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<global::System.Int32> RsvpCount
        {
            get
            {
                return _RsvpCount;
            }
            set
            {
                OnRsvpCountChanging(value);
                ReportPropertyChanging("RsvpCount");
                _RsvpCount = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("RsvpCount");
                OnRsvpCountChanged();
            }
        }
        private Nullable<global::System.Int32> _RsvpCount;
        partial void OnRsvpCountChanging(Nullable<global::System.Int32> value);
        partial void OnRsvpCountChanged();

        #endregion
    
    }
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="NerdDinnerModel", Name="RsvpReadModel")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class RsvpReadModel : EntityObject
    {
        #region Factory Method
    
        /// <summary>
        /// Create a new RsvpReadModel object.
        /// </summary>
        /// <param name="dinnerId">Initial value of the DinnerId property.</param>
        /// <param name="attendeeId">Initial value of the AttendeeId property.</param>
        /// <param name="attendeeName">Initial value of the AttendeeName property.</param>
        public static RsvpReadModel CreateRsvpReadModel(global::System.Guid dinnerId, global::System.Guid attendeeId, global::System.String attendeeName)
        {
            RsvpReadModel rsvpReadModel = new RsvpReadModel();
            rsvpReadModel.DinnerId = dinnerId;
            rsvpReadModel.AttendeeId = attendeeId;
            rsvpReadModel.AttendeeName = attendeeName;
            return rsvpReadModel;
        }

        #endregion
        #region Primitive Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Guid DinnerId
        {
            get
            {
                return _DinnerId;
            }
            set
            {
                if (_DinnerId != value)
                {
                    OnDinnerIdChanging(value);
                    ReportPropertyChanging("DinnerId");
                    _DinnerId = StructuralObject.SetValidValue(value);
                    ReportPropertyChanged("DinnerId");
                    OnDinnerIdChanged();
                }
            }
        }
        private global::System.Guid _DinnerId;
        partial void OnDinnerIdChanging(global::System.Guid value);
        partial void OnDinnerIdChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Guid AttendeeId
        {
            get
            {
                return _AttendeeId;
            }
            set
            {
                if (_AttendeeId != value)
                {
                    OnAttendeeIdChanging(value);
                    ReportPropertyChanging("AttendeeId");
                    _AttendeeId = StructuralObject.SetValidValue(value);
                    ReportPropertyChanged("AttendeeId");
                    OnAttendeeIdChanged();
                }
            }
        }
        private global::System.Guid _AttendeeId;
        partial void OnAttendeeIdChanging(global::System.Guid value);
        partial void OnAttendeeIdChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String AttendeeName
        {
            get
            {
                return _AttendeeName;
            }
            set
            {
                OnAttendeeNameChanging(value);
                ReportPropertyChanging("AttendeeName");
                _AttendeeName = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("AttendeeName");
                OnAttendeeNameChanged();
            }
        }
        private global::System.String _AttendeeName;
        partial void OnAttendeeNameChanging(global::System.String value);
        partial void OnAttendeeNameChanged();

        #endregion
    
    }
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="NerdDinnerModel", Name="UserReadModel")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class UserReadModel : EntityObject
    {
        #region Factory Method
    
        /// <summary>
        /// Create a new UserReadModel object.
        /// </summary>
        /// <param name="userId">Initial value of the UserId property.</param>
        /// <param name="userName">Initial value of the UserName property.</param>
        /// <param name="password">Initial value of the Password property.</param>
        /// <param name="email">Initial value of the Email property.</param>
        /// <param name="canonicalUsername">Initial value of the CanonicalUsername property.</param>
        public static UserReadModel CreateUserReadModel(global::System.Guid userId, global::System.String userName, global::System.String password, global::System.String email, global::System.String canonicalUsername)
        {
            UserReadModel userReadModel = new UserReadModel();
            userReadModel.UserId = userId;
            userReadModel.UserName = userName;
            userReadModel.Password = password;
            userReadModel.Email = email;
            userReadModel.CanonicalUsername = canonicalUsername;
            return userReadModel;
        }

        #endregion
        #region Primitive Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Guid UserId
        {
            get
            {
                return _UserId;
            }
            set
            {
                if (_UserId != value)
                {
                    OnUserIdChanging(value);
                    ReportPropertyChanging("UserId");
                    _UserId = StructuralObject.SetValidValue(value);
                    ReportPropertyChanged("UserId");
                    OnUserIdChanged();
                }
            }
        }
        private global::System.Guid _UserId;
        partial void OnUserIdChanging(global::System.Guid value);
        partial void OnUserIdChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String UserName
        {
            get
            {
                return _UserName;
            }
            set
            {
                OnUserNameChanging(value);
                ReportPropertyChanging("UserName");
                _UserName = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("UserName");
                OnUserNameChanged();
            }
        }
        private global::System.String _UserName;
        partial void OnUserNameChanging(global::System.String value);
        partial void OnUserNameChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String Password
        {
            get
            {
                return _Password;
            }
            set
            {
                OnPasswordChanging(value);
                ReportPropertyChanging("Password");
                _Password = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("Password");
                OnPasswordChanged();
            }
        }
        private global::System.String _Password;
        partial void OnPasswordChanging(global::System.String value);
        partial void OnPasswordChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String Email
        {
            get
            {
                return _Email;
            }
            set
            {
                OnEmailChanging(value);
                ReportPropertyChanging("Email");
                _Email = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("Email");
                OnEmailChanged();
            }
        }
        private global::System.String _Email;
        partial void OnEmailChanging(global::System.String value);
        partial void OnEmailChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String CanonicalUsername
        {
            get
            {
                return _CanonicalUsername;
            }
            set
            {
                OnCanonicalUsernameChanging(value);
                ReportPropertyChanging("CanonicalUsername");
                _CanonicalUsername = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("CanonicalUsername");
                OnCanonicalUsernameChanged();
            }
        }
        private global::System.String _CanonicalUsername;
        partial void OnCanonicalUsernameChanging(global::System.String value);
        partial void OnCanonicalUsernameChanged();

        #endregion
    
    }

    #endregion
    
}
